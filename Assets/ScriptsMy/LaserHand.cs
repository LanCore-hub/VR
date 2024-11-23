using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;

public class LaserHand : SteamVR_LaserPointer
{
    public GameObject redPointPrefab; // ������� �����
    private GameObject currentRedPoint; // ������� �����

    private bool isGrab;

    [Header("���������� �����")]
    public LineRenderer greenLaser; // ������ ���
    //public float beamLeagth = 5f; // ����� ����
    private LineRenderer currentBeam; // ���������� ��� �������� ����
    private GameObject point1;
    private GameObject point2;
    public bool isConnecting;
    public Button connectButton;
    public GameObject stickPrefab;
    private GameObject currentStick;

    [Header("�������� ����� � ����������")]
    public bool isDeleting;
    public Button deleteButton;

    public override void OnPointerIn(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Image>().color = Color.blue;
        }
    }

    public override void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("ButtonUI") || e.target.CompareTag("ButtonUIMap"))
        {
            e.target.GetComponent<Button>().onClick.Invoke();
        }

        if (e.target != null && e.target.CompareTag("Untagged") && !isGrab)
        {
            //currentBeam = Instantiate(greenLaser, GetLaserPosition(), UnityEngine.Quaternion.identity);
            //currentBeam.SetPosition(0, GetLaserPosition());
            //currentBeam.SetPosition(1, GetLaserPosition() + UnityEngine.Vector3.up * beamLeagth);
            Instantiate(redPointPrefab, GetLaserPosition(), UnityEngine.Quaternion.identity);
        }

        if (e.target.CompareTag("DeleteButton"))
        {
            isDeleting = !isDeleting;
            if (isDeleting)
            {
                deleteButton.GetComponent<Image>().color = Color.green;
            }
            else
            {
                deleteButton.GetComponent<Image>().color = Color.red;
            }
        }
        else if (isDeleting)
        {
            if (e.target.CompareTag("RedPoint") || e.target.CompareTag("Connection"))
            {
                Destroy(e.target.gameObject);
            }
            isDeleting = false;
            deleteButton.GetComponent<Image>().color = Color.red;
        }

        else if (e.target != null && e.target.CompareTag("ConnectButton"))
        {
            isConnecting = !isConnecting;
            if (isConnecting)
            {
                connectButton.GetComponent<Image>().color = Color.green;
            }
            else
            {
                connectButton.GetComponent<Image>().color = Color.red;
            }
        }
        else if (isConnecting && e.target.CompareTag("RedPoint"))
        {
            if (point1 == null)
            {
                point1 = e.target.gameObject;
            }
            else if (point2 == null)
            { 
                point2 = e.target.gameObject;

                if (point1 != point2)
                {
                    // �����
                    //currentBeam = Instantiate(greenLaser, GetLaserPosition(), UnityEngine.Quaternion.identity);
                    //currentBeam.SetPosition(0, point1.transform.position);
                    //currentBeam.SetPosition(1, point2.transform.position);

                    // �����
                    UnityEngine.Vector3 direction = point2.transform.position - point1.transform.position;
                    float distance = direction.magnitude;

                    currentStick = Instantiate(stickPrefab, point1.transform.position, UnityEngine.Quaternion.identity);
                    currentStick.transform.localScale = new UnityEngine.Vector3(0.1f, 0.1f, distance);
                    currentStick.transform.rotation = UnityEngine.Quaternion.LookRotation(direction);
                    currentStick.transform.position = point1.transform.position + direction / 2f;
                }
                point1 = null;
                point2 = null;
                isConnecting = false;
                connectButton.GetComponent <Image>().color = Color.red;
            }
        }

        // ���� ����� �������� �� �����, �� ��������� ������� ������ ��������� ������ ������� �����
        else if (e.target != null && e.target.CompareTag("RedPoint"))
        {
            isGrab = true;
            currentRedPoint = e.target.gameObject;
        }
        else if (isGrab) {
            currentRedPoint.transform.position = new UnityEngine.Vector3(currentRedPoint.transform.position.x, GetLaserPosition().y, currentRedPoint.transform.position.z);
            isGrab = false;
            currentRedPoint = null;
        }
    }

    public override void OnPointerOut(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Image>().color = Color.white;
        }
    }

    public UnityEngine.Vector3 GetLaserPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            return hit.point;
        }
        else
        {
            return transform.position + transform.forward * 100f;
        }
    }
}

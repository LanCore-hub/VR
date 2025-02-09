using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using Valve.VR;

public class LaserSight : MonoBehaviour
{
    public Color laserColor = Color.red;
    public float laserDistance = 100f;
    public float laserWidth = 0.1f;
    public GameObject bulletHolePrefab;
    public GameObject TextScore;
    public GameObject smoke;

    private LineRenderer lineRenderer;
    public GameObject rightHand;

    private SteamVR_Action_Boolean m_Trigger;
    private SteamVR_Behaviour_Pose m_Pose;

    private void Awake()
    {
        m_Trigger = SteamVR_Actions._default.InteractUI;

        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.startColor = laserColor;
        lineRenderer.endColor = laserColor;
    }

    void Update()
    {
        lineRenderer.enabled = true;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserDistance))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            if (rightHand.GetComponent<ActivateGunLaser>().fire)
            {
                GameObject bullet = Instantiate(bulletHolePrefab, hit.point, Quaternion.identity);
                rightHand.GetComponent<ActivateGunLaser>().fire = false;
                Destroy(bullet, 5f);

                if (hit.transform.CompareTag("4"))
                {
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Score: 4");
                }
                else if (hit.transform.CompareTag("5"))
                {
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Score: 5");
                }
                else if (hit.transform.CompareTag("6"))
                {
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Score: 6");
                }
                else if (hit.transform.CompareTag("7"))
                {
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Score: 7");
                }
                else if (hit.transform.CompareTag("8"))
                {
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Score: 8");
                }
                else if (hit.transform.CompareTag("9"))
                {
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Score: 9");
                }
                else if (hit.transform.CompareTag("10"))
                {
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Score: 10");
                }

                if (hit.transform.CompareTag("plate"))
                {
                    Destroy(bullet);
                    GameObject plateGameObject = hit.transform.gameObject;
                    GameObject Smoke = Instantiate(smoke, plateGameObject.transform.position, Quaternion.identity);
                    Destroy(Smoke, 10f);
                    Destroy(plateGameObject);
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * laserDistance);
        }
    }
}

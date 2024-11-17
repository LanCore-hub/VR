using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class ActiveLaserHand : MonoBehaviour
{
    public SteamVR_LaserPointer steamVR_Laser;
    private SteamVR_Action_Boolean m_Grip;

    private SteamVR_Behaviour_Pose m_Pose;
    private bool flag;
    public GameObject canvasCreateObejcts;

    private void Awake()
    {
        m_Grip = SteamVR_Actions._default.GrabGrip;

        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Start()
    {
        flag = false;
    }

    private void Update()
    {
        Transform childObject = transform.Find("New Game Object");
        if (m_Grip.GetStateDown(m_Pose.inputSource) && flag)
        {
            flag = false;
            steamVR_Laser.enabled = false;
            canvasCreateObejcts.SetActive(false);
            childObject.gameObject.SetActive(false);
        }

        else if (m_Grip.GetStateDown(m_Pose.inputSource) && !flag)
        {
            flag = true;
            steamVR_Laser.enabled = true;
            canvasCreateObejcts.SetActive(true);
            childObject.gameObject.SetActive(true);
        }
    }
}

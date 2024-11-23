using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActivateGunLaser : MonoBehaviour
{
    public GameObject laser;
    public bool laserEnable;

    private SteamVR_Action_Boolean m_Trigger;
    private SteamVR_Behaviour_Pose m_Pose;

    private void Awake()
    {
        m_Trigger = SteamVR_Actions._default.InteractUI;

        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Start()
    {
        laserEnable = false;
    }

    void Update()
    {
        if (m_Trigger.GetStateDown(m_Pose.inputSource))
        {
            laserEnable = !laserEnable;
        }

        if (laserEnable)
        {
            laser.GetComponent<LaserSight>().laserDistance = 100;
        }
        else
        {
            laser.GetComponent<LaserSight>().laserDistance = 0;
        }
    }
}

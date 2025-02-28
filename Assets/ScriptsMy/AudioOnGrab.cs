using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AudioOnGrab : MonoBehaviour
{
    private AudioSource kaskaAudioSource;
    private AudioSource ognetushitelAudioSource;
    private AudioSource spetsobuvAudioSource;
    private AudioSource VRAudioSource;
    private ParticleSystem ognetushitelParticleSystem;
    private bool isPlaying1;
    private bool isPlaying2;
    private bool isPlaying3;
    private bool isPlaying4;
    public bool koltso;

    private SteamVR_Action_Boolean m_Grip;
    private SteamVR_Behaviour_Pose m_Pose;

    private void Awake()
    {
        m_Grip = SteamVR_Actions._default.GrabGrip;

        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }


    void Start()
    {
        isPlaying1 = false;
        isPlaying2 = false;
        isPlaying3 = false;
        isPlaying4 = false;
        koltso = true;
    }

    void Update()
    {
        Transform kaskaObject = gameObject.transform.Find("kaska");
        if (kaskaObject != null && !isPlaying1) {
            kaskaAudioSource = kaskaObject.GetComponent<AudioSource>();
            kaskaAudioSource.Play();
            isPlaying1 = true;
        }
        else if (kaskaObject == null && isPlaying1)
        {
            kaskaAudioSource.Stop();
            isPlaying1 = false;
        }

        Transform ognetushitelObject = gameObject.transform.Find("ognetushitel");
        if (ognetushitelObject != null && ognetushitelObject.Find("koltso"))
            koltso = true;
        else if (ognetushitelObject != null) koltso = false;

        if (ognetushitelObject != null && !isPlaying2)
        {
            ognetushitelAudioSource = ognetushitelObject.GetComponent<AudioSource>();
            ognetushitelParticleSystem = ognetushitelObject.transform.Find("Particle System").GetComponent<ParticleSystem>();
            ognetushitelAudioSource.Play();
            isPlaying2 = true;
        }
        else if (ognetushitelObject != null && m_Grip.GetStateDown(m_Pose.inputSource) && koltso)
        {
            koltso = false;
            Destroy(ognetushitelObject.transform.Find("koltso").gameObject);
        }
        else if (ognetushitelObject != null && m_Grip.GetStateDown(m_Pose.inputSource) && !koltso)
        {
            GameObject ParticleSystem = ognetushitelObject.Find("Particle System").gameObject;
            ParticleSystem.SetActive(true);
            ParticleSystem.GetComponent<ParticleSystem>().Play();
        }
        else if (ognetushitelObject != null && m_Grip.GetStateUp(m_Pose.inputSource) && !koltso)
        {
            GameObject ParticleSystem = ognetushitelObject.transform.Find("Particle System").gameObject;
            ParticleSystem.GetComponent<ParticleSystem>().Stop(false);
        }
        else if (ognetushitelObject == null && isPlaying2)
        {
            ognetushitelAudioSource.Stop();
            ognetushitelParticleSystem.Stop(false);
            isPlaying2 = false;
        }

        Transform spetsobuvlObject = gameObject.transform.Find("spetsobuv");
        if (spetsobuvlObject != null && !isPlaying3)
        {
            spetsobuvAudioSource = spetsobuvlObject.GetComponent<AudioSource>();
            spetsobuvAudioSource.Play();
            isPlaying3 = true;
        }
        else if (spetsobuvlObject == null && isPlaying3)
        {
            spetsobuvAudioSource.Stop();
            isPlaying3 = false;
        }

        Transform VRObject = gameObject.transform.Find("VROch");
        if (VRObject != null && !isPlaying4)
        {
            VRAudioSource = VRObject.GetComponent<AudioSource>();
            VRAudioSource.Play();
            isPlaying4 = true;
        }
        else if (VRObject == null && isPlaying4)
        {
            VRAudioSource.Stop();
            isPlaying4 = false;
        }
    }
}

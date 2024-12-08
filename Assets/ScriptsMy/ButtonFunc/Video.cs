using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR.InteractionSystem;

public class Video : MonoBehaviour
{
    public HoverButton hoverButton;
    public VideoPlayer videoPlayer; // ������ �� Video Player
    private bool videoPlayed = false; // ���� ��� ������������ ���������������

    private void Start()
    {
        if (hoverButton == null || videoPlayer == null)
        {
            enabled = false;
            return;
        }
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void OnButtonDown(Hand hand)
    {
        if (!videoPlayed)
        {
            videoPlayer.Play();
            videoPlayed = true;
            // �������������� ��� ��� ��������� ���������� ����� (�����������):
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnVideoFinished(UnityEngine.Video.VideoPlayer vp)
    {
        videoPlayed = false; // ���������� ���� ����� ����������
        vp.loopPointReached -= OnVideoFinished; // ������� ����������
    }
}

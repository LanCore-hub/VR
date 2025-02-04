using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR.InteractionSystem;

public class Video : MonoBehaviour
{
    public GameObject GameObject;
    public HoverButton hoverButton;
    public VideoPlayer videoPlayer; // ������ �� Video Player
    private bool videoPlayed = false; // ���� ��� ������������ ���������������

    // ����������� ���������� ��� ������������ �������� ���������������� �����������
    private static VideoPlayer currentVideoPlayer;

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
        GameObject.SetActive(true);

        if (currentVideoPlayer != null && currentVideoPlayer != videoPlayer)
        {
            currentVideoPlayer.Stop();
            videoPlayed = false;
            currentVideoPlayer = null;
        }

        if (!videoPlayed)
        {
            videoPlayer.Play();
            videoPlayed = true;
            currentVideoPlayer = videoPlayer;
            // �������������� ��� ��� ��������� ���������� ����� (�����������):
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnVideoFinished(UnityEngine.Video.VideoPlayer vp)
    {
        videoPlayed = false; // ���������� ���� ����� ����������
        currentVideoPlayer = null;
        vp.loopPointReached -= OnVideoFinished; // ������� ����������
    }
}

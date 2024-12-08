using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR.InteractionSystem;

public class Video : MonoBehaviour
{
    public HoverButton hoverButton;
    public VideoPlayer videoPlayer; // Ссылка на Video Player
    private bool videoPlayed = false; // Флаг для отслеживания воспроизведения

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
            // Дополнительный код для обработки завершения видео (опционально):
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnVideoFinished(UnityEngine.Video.VideoPlayer vp)
    {
        videoPlayed = false; // Сбрасываем флаг после завершения
        vp.loopPointReached -= OnVideoFinished; // Убираем обработчик
    }
}

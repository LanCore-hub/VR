using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class ScreenCaptureScript : MonoBehaviour
{
    //private WebCamTexture webcamTexture;
    //void Start()
    //{
    //    // Получаем список доступных веб-камер
    //    WebCamDevice[] devices = WebCamTexture.devices;
    //    // Проверяем, есть ли доступные устройства
    //    if (devices.Length > 0)
    //    {
    //        // Создаем текстуру с первого доступного устройства
    //        webcamTexture = new WebCamTexture(devices[0].name);
    //        // Применяем текстуру к материалу объекта
    //        GetComponent<Renderer>().material.mainTexture = webcamTexture;
    //        // Запускаем захват видео
    //        webcamTexture.Play();
    //    }
    //    else
    //    {
    //        Debug.LogError("Нет доступных веб-камер.");
    //    }
    //}

    //void OnDisable()
    //{
    //    // Останавливаем захват видео при отключении объекта
    //    if (webcamTexture != null)
    //    {
    //        webcamTexture.Stop();
    //        webcamTexture = null;
    //    }
    //}
    //void OnDestroy()
    //{
    //    // Очищаем ресурсы при уничтожении скрипта
    //    if (webcamTexture != null)
    //    {
    //        webcamTexture.Stop();
    //        webcamTexture = null;
    //    }
    //}

    //--------------------------------------------------------------------------------------------------------------------

    //public GameObject cube; // Объект, на который будет нанесена текстура
    //private Texture2D screenTexture;
    //void Start()
    //{
    //    // Запускаем захват экрана каждую секунду
    //    InvokeRepeating("CaptureScreen", 0f, 1f);
    //}
    //void CaptureScreen()
    //{
    //    // Захватываем экран и получаем текстуру
    //    screenTexture = ScreenCapture.CaptureScreenshotAsTexture();
    //    // Применяем текстуру к кубу
    //    ApplyTextureToCube();
    //}
    //void ApplyTextureToCube()
    //{
    //    // Получаем материал куба
    //    Renderer cubeRenderer = cube.GetComponent<Renderer>();
    //    if (cubeRenderer != null)
    //    {
    //        // Создаем новый материал, если его нет
    //        if (cubeRenderer.material.mainTexture != screenTexture)
    //        {
    //            cubeRenderer.material = new Material(Shader.Find("Unlit/Texture"));
    //        }
    //        // Устанавливаем текстуру на материал
    //        cubeRenderer.material.mainTexture = screenTexture;
    //    }
    //}
    //void OnDisable()
    //{
    //    // Освобождаем текстуру при отключении
    //    if (screenTexture != null)
    //    {
    //        Destroy(screenTexture);
    //    }
    //}

    //--------------------------------------------------------------------------------------------------------------------------

    //public GameObject cube;
    //private Texture2D screenTexture;
    //void Start()
    //{
    //    // Инициализируем текстуру с разрешением экрана
    //    screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

    //    // Запускаем захват экрана каждую секунду
    //    InvokeRepeating("CaptureScreen", 0f, 0.02f);
    //}

    //void CaptureScreen()
    //{
    //    // Захватываем экран и получаем текстуру
    //    ScreenCapture.CaptureScreenshotIntoRenderTexture(RenderTexture.active);

    //    // Обновляем текстуру с помощью пикселей из RenderTexture
    //    UpdateTextureFromRenderTexture();

    //    // Применяем текстуру к кубу
    //    ApplyTextureToCube();
    //}
    //void UpdateTextureFromRenderTexture()
    //{
    //    // Создаем временный RenderTexture для захвата
    //    RenderTexture renderTexture = RenderTexture.active;

    //    // Сохраняем текущее состояние RenderTexture
    //    RenderTexture.active = renderTexture;
    //    // Копируем данные из RenderTexture в текстуру
    //    screenTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    //    screenTexture.Apply();
    //    // Восстанавливаем предыдущее состояние RenderTexture
    //    RenderTexture.active = null;
    //}
    //void ApplyTextureToCube()
    //{
    //    // Получаем материал куба
    //    Renderer cubeRenderer = cube.GetComponent<Renderer>();
    //    if (cubeRenderer != null)
    //    {
    //        // Создаем новый материал, если его нет
    //        if (cubeRenderer.material.mainTexture != screenTexture)
    //        {
    //            cubeRenderer.material = new Material(Shader.Find("Unlit/Texture"));
    //        }
    //        // Устанавливаем текстуру на материал
    //        cubeRenderer.material.mainTexture = screenTexture;
    //    }
    //}
    //void OnDisable()
    //{
    //    // Освобождаем текстуру при отключении
    //    if (screenTexture != null)
    //    {
    //        Destroy(screenTexture);
    //        screenTexture = null; // Устанавливаем в null для предотвращения случайного использования
    //    }
    //}

    //---------------------------------------------------------------------------------------------------
    
}
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
    //    // �������� ������ ��������� ���-�����
    //    WebCamDevice[] devices = WebCamTexture.devices;
    //    // ���������, ���� �� ��������� ����������
    //    if (devices.Length > 0)
    //    {
    //        // ������� �������� � ������� ���������� ����������
    //        webcamTexture = new WebCamTexture(devices[0].name);
    //        // ��������� �������� � ��������� �������
    //        GetComponent<Renderer>().material.mainTexture = webcamTexture;
    //        // ��������� ������ �����
    //        webcamTexture.Play();
    //    }
    //    else
    //    {
    //        Debug.LogError("��� ��������� ���-�����.");
    //    }
    //}

    //void OnDisable()
    //{
    //    // ������������� ������ ����� ��� ���������� �������
    //    if (webcamTexture != null)
    //    {
    //        webcamTexture.Stop();
    //        webcamTexture = null;
    //    }
    //}
    //void OnDestroy()
    //{
    //    // ������� ������� ��� ����������� �������
    //    if (webcamTexture != null)
    //    {
    //        webcamTexture.Stop();
    //        webcamTexture = null;
    //    }
    //}

    //--------------------------------------------------------------------------------------------------------------------

    //public GameObject cube; // ������, �� ������� ����� �������� ��������
    //private Texture2D screenTexture;
    //void Start()
    //{
    //    // ��������� ������ ������ ������ �������
    //    InvokeRepeating("CaptureScreen", 0f, 1f);
    //}
    //void CaptureScreen()
    //{
    //    // ����������� ����� � �������� ��������
    //    screenTexture = ScreenCapture.CaptureScreenshotAsTexture();
    //    // ��������� �������� � ����
    //    ApplyTextureToCube();
    //}
    //void ApplyTextureToCube()
    //{
    //    // �������� �������� ����
    //    Renderer cubeRenderer = cube.GetComponent<Renderer>();
    //    if (cubeRenderer != null)
    //    {
    //        // ������� ����� ��������, ���� ��� ���
    //        if (cubeRenderer.material.mainTexture != screenTexture)
    //        {
    //            cubeRenderer.material = new Material(Shader.Find("Unlit/Texture"));
    //        }
    //        // ������������� �������� �� ��������
    //        cubeRenderer.material.mainTexture = screenTexture;
    //    }
    //}
    //void OnDisable()
    //{
    //    // ����������� �������� ��� ����������
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
    //    // �������������� �������� � ����������� ������
    //    screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

    //    // ��������� ������ ������ ������ �������
    //    InvokeRepeating("CaptureScreen", 0f, 0.02f);
    //}

    //void CaptureScreen()
    //{
    //    // ����������� ����� � �������� ��������
    //    ScreenCapture.CaptureScreenshotIntoRenderTexture(RenderTexture.active);

    //    // ��������� �������� � ������� �������� �� RenderTexture
    //    UpdateTextureFromRenderTexture();

    //    // ��������� �������� � ����
    //    ApplyTextureToCube();
    //}
    //void UpdateTextureFromRenderTexture()
    //{
    //    // ������� ��������� RenderTexture ��� �������
    //    RenderTexture renderTexture = RenderTexture.active;

    //    // ��������� ������� ��������� RenderTexture
    //    RenderTexture.active = renderTexture;
    //    // �������� ������ �� RenderTexture � ��������
    //    screenTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    //    screenTexture.Apply();
    //    // ��������������� ���������� ��������� RenderTexture
    //    RenderTexture.active = null;
    //}
    //void ApplyTextureToCube()
    //{
    //    // �������� �������� ����
    //    Renderer cubeRenderer = cube.GetComponent<Renderer>();
    //    if (cubeRenderer != null)
    //    {
    //        // ������� ����� ��������, ���� ��� ���
    //        if (cubeRenderer.material.mainTexture != screenTexture)
    //        {
    //            cubeRenderer.material = new Material(Shader.Find("Unlit/Texture"));
    //        }
    //        // ������������� �������� �� ��������
    //        cubeRenderer.material.mainTexture = screenTexture;
    //    }
    //}
    //void OnDisable()
    //{
    //    // ����������� �������� ��� ����������
    //    if (screenTexture != null)
    //    {
    //        Destroy(screenTexture);
    //        screenTexture = null; // ������������� � null ��� �������������� ���������� �������������
    //    }
    //}

    //---------------------------------------------------------------------------------------------------
    
}
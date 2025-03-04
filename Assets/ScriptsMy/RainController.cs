using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public float minRainDuration = 60f; // ����������� ����������������� ����� (1 ������)
    public float maxRainDuration = 120f; // ������������ ����������������� ����� (2 ������)
    public float minStartDelay = 600f; // ����������� �������� ����� ������� ����� (20 �����)
    public float maxStartDelay = 1200f; // ������������ �������� ����� ������� ����� (40 �����)
    public float minDelayBetweenRains = 600f; // ����������� �������� ����� �������
    public float maxDelayBetweenRains = 1200f; // ������������ �������� ����� �������

    private RainScript rainScript;

    private void Start()
    {
        rainScript = GetComponent<RainScript>();

        // ��������� ������ ����� ����� ��������� ��������
        StartCoroutine(StartRainAfterDelay());
    }

    IEnumerator StartRainAfterDelay()
    {
        while (true) // ����������� ���� ��� ���������� ������
        {
            // ���� ��������� ����� �� minStartDelay �� maxStartDelay
            float initialDelay = Random.Range(minStartDelay, maxStartDelay);
            yield return new WaitForSeconds(initialDelay);

            // ��������� �����
            yield return StartCoroutine(ControlRain());

            // ���� ��������� ����� �� minDelayBetweenRains �� maxDelayBetweenRains ����� ��������� ������
            float delayBetweenRains = Random.Range(minDelayBetweenRains, maxDelayBetweenRains);
            yield return new WaitForSeconds(delayBetweenRains);
        }
    }

    IEnumerator ControlRain()
    {
        // ��������� ����������������� ����� �� minRainDuration �� maxRainDuration
        float rainDuration = Random.Range(minRainDuration, maxRainDuration);
        float elapsedTime = 0f;

        // ������ ����������� ������������� ����� �� 1
        while (elapsedTime < rainDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            rainScript.RainIntensity = Mathf.Lerp(0f, 1f, elapsedTime / (rainDuration / 2));
            yield return null;
        }

        // ������ ��������� ������������� ����� �� 0
        while (elapsedTime < rainDuration)
        {
            elapsedTime += Time.deltaTime;
            rainScript.RainIntensity = Mathf.Lerp(1f, 0f, (elapsedTime - rainDuration / 2) / (rainDuration / 2));
            yield return null;
        }

        // ��������, ��� ������������� ����� ����� 0 � �����
        rainScript.RainIntensity = 0f;
    }
}

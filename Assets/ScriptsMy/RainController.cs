using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public float minRainDuration = 60f; // Минимальная продолжительность дождя (1 минута)
    public float maxRainDuration = 120f; // Максимальная продолжительность дождя (2 минуты)
    public float minStartDelay = 600f; // Минимальная задержка перед началом дождя (20 минут)
    public float maxStartDelay = 1200f; // Максимальная задержка перед началом дождя (40 минут)
    public float minDelayBetweenRains = 600f; // Минимальная задержка между дождями
    public float maxDelayBetweenRains = 1200f; // Максимальная задержка между дождями

    private RainScript rainScript;

    private void Start()
    {
        rainScript = GetComponent<RainScript>();

        // Запускаем первый дождь после начальной задержки
        StartCoroutine(StartRainAfterDelay());
    }

    IEnumerator StartRainAfterDelay()
    {
        while (true) // Бесконечный цикл для повторения дождей
        {
            // Ждем случайное время от minStartDelay до maxStartDelay
            float initialDelay = Random.Range(minStartDelay, maxStartDelay);
            yield return new WaitForSeconds(initialDelay);

            // Запускаем дождь
            yield return StartCoroutine(ControlRain());

            // Ждем случайное время от minDelayBetweenRains до maxDelayBetweenRains перед следующим дождем
            float delayBetweenRains = Random.Range(minDelayBetweenRains, maxDelayBetweenRains);
            yield return new WaitForSeconds(delayBetweenRains);
        }
    }

    IEnumerator ControlRain()
    {
        // Случайная продолжительность дождя от minRainDuration до maxRainDuration
        float rainDuration = Random.Range(minRainDuration, maxRainDuration);
        float elapsedTime = 0f;

        // Плавно увеличиваем интенсивность дождя до 1
        while (elapsedTime < rainDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            rainScript.RainIntensity = Mathf.Lerp(0f, 1f, elapsedTime / (rainDuration / 2));
            yield return null;
        }

        // Плавно уменьшаем интенсивность дождя до 0
        while (elapsedTime < rainDuration)
        {
            elapsedTime += Time.deltaTime;
            rainScript.RainIntensity = Mathf.Lerp(1f, 0f, (elapsedTime - rainDuration / 2) / (rainDuration / 2));
            yield return null;
        }

        // Убедимся, что интенсивность дождя равна 0 в конце
        rainScript.RainIntensity = 0f;
    }
}

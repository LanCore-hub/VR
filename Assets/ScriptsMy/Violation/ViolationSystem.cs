using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class ViolationSystem : MonoBehaviour
{
    private int currentViolations = 0;
    public int maxViolations = 3;
    public ViolationEffect violationEffect;
    public AudioSource violationSound;

    public LoadScene loadScene;

    public void AddViolation()
    {
        currentViolations++;
        Debug.Log("Нарушение! Текущее количество: " + currentViolations);

        if (violationEffect != null)
        {
            violationSound.Play();
            violationEffect.TriggerFlash();
        }

        if (currentViolations >= maxViolations)
        {
            EnforceRules();
        }
    }

    public void EnforceRules()
    {
        Debug.Log("Превышено количество нарушений. Игрок отправлен читать правила.");
        loadScene.LoadSceneMethod("ReadRulesRoom");
    }

    public int GetCurrentViolations()
    {
        return currentViolations;
    }
}

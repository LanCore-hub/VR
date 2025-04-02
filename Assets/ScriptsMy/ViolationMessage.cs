using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViolationMessage : MonoBehaviour
{
    public static ViolationMessage Instance;

    public GameObject messagePanel;
    public float displayTime = 3f;

    private Coroutine currentMessageCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        messagePanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (currentMessageCoroutine != null)
        {
            StopCoroutine(currentMessageCoroutine);
        }
        messagePanel.GetComponent<TextMeshProUGUI>().text = message;
        messagePanel.SetActive(true);

        currentMessageCoroutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        messagePanel.SetActive(false);
        currentMessageCoroutine = null;
    }
}

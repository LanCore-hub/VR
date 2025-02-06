using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Valve.VR.InteractionSystem;

public class AudioBoardRules : MonoBehaviour
{
    public GameObject BoardRulesGameObject;
    public HoverButton hoverButton;
    private bool isPlaying;

    void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    void OnButtonDown(Hand hand)
    {
        if (!isPlaying)
        {
            isPlaying = true;
            BoardRulesGameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(EnableButtonAfterAudio());
        }
    }

    IEnumerator EnableButtonAfterAudio()
    {
        yield return new WaitForSeconds(BoardRulesGameObject.GetComponent<AudioSource>().clip.length);
        isPlaying = false;
    }
}

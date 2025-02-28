using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class CheckTeleport : MonoBehaviour
{
    public HoverButton hoverButton;
    public LoadScene loadScene;
    public string NameLoadScene;

    private void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void OnButtonDown(Hand hand)
    {
        loadScene.LoadSceneMethod(NameLoadScene);
    }
}
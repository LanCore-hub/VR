using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class CheckTeleport : MonoBehaviour
{
    public HoverButton hoverButton;
    public GameObject Player;
    public string NameSceneLoad;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void OnButtonDown(Hand hand)
    {
        Destroy(Player);
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.transform.parent == null && obj.scene.isLoaded)
            {
                Destroy(obj);
            }
        }
        SceneManager.LoadScene(NameSceneLoad);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneMethod(string NameSceneLoad)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Destroy(Player);
        GameObject[] objects = FindObjectsOfType<GameObject>();
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

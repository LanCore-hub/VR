using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunc : MonoBehaviour
{
    public GameObject prefab;
    public Transform pos;

    public Button buttonMap;
    public GameObject map;

    private List<GameObject> objects = new List<GameObject>();
    bool flag;

    public void CreateObject()
    {
        GameObject newObj = Instantiate(prefab, pos.position, pos.rotation);
        objects.Add(newObj);
    }

    public void DestroyObjects()
    {
        foreach (GameObject obj in objects) {
            Destroy(obj);
        }

        objects.Clear();
    }

    public void ViewMap()
    {
        if (flag)
        {
            buttonMap.GetComponent<Image>().color = Color.green;
            map.SetActive(true);
            flag = false;
        }
        else
        {
            buttonMap.GetComponent<Image>().color = Color.red;
            map.SetActive(false);
            flag = true;
        }
    }
}

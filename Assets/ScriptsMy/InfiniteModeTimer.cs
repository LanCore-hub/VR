using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteModeTimer : MonoBehaviour
{
    [SerializeField] private string NameLoadScene; // ��� ����� ��� ��������
    [SerializeField] private float timeToWait = 900f; // 15 ����� � ��������

    private void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(timeToWait);

        gameObject.GetComponent<LoadScene>().LoadSceneMethod(NameLoadScene);
    }
}

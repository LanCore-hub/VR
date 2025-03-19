using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LoadNormative3 : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    public HoverButton hoverButton;
    [SerializeField] private GameObject Teleport;
    [SerializeField] private GameObject TextScore;

    public bool isNormative3 = false;

    private void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void OnButtonDown(Hand hand)
    {
        isNormative3 = true;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = new Vector3(55.7869987f, 0.335999995f, 17.0970001f);
        Teleport.GetComponent<TeleportArea>().locked = true;
        gun.GetComponent<ActivateGunLaser>().AllAmmo = 60;
        TextScore.GetComponent<LaserSight>().AllScore = 0;
        TextScore.GetComponent<LaserSight>().AllScoreText.GetComponent<TextMeshProUGUI>().text = "ќбщий счЄт: " + TextScore.GetComponent<LaserSight>().AllScore.ToString();
    }
}

using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using Valve.VR;

public class LaserSight : MonoBehaviour
{
    public Color laserColor = Color.red;
    public float laserDistance = 100f;
    public float laserWidth = 0.1f;
    public GameObject bulletHolePrefab;
    public GameObject TextScore;
    public GameObject smoke;

    private LineRenderer lineRenderer;
    public GameObject rightHand;

    public AudioSource gunSound;
    private int AllScore;
    public GameObject AllScoreText;
    public GameObject DistanceText;

    private int AllPlaces;
    public GameObject ScorePlacesText;
    public GameObject DistancePlaceText;


    private SteamVR_Action_Boolean m_Trigger;
    private SteamVR_Behaviour_Pose m_Pose;

    public ViolationSystem violationSystem;
    private bool isViolationCooldown;
    private RainScript rainScript;

    private void Awake()
    {
        m_Trigger = SteamVR_Actions._default.InteractUI;

        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Start()
    {
        AllScore = 0;
        AllPlaces = 0;
        gunSound = gameObject.GetComponent<AudioSource>();

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.startColor = laserColor;
        lineRenderer.endColor = laserColor;

        rainScript = FindObjectOfType<RainScript>();
    }

    void Update()
    {
        lineRenderer.enabled = true;
        RaycastHit hit;

        bool laserHit = Physics.Raycast(transform.position, transform.forward, out hit, laserDistance);

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserHit ? hit.point : transform.position + transform.forward * laserDistance);

        if (rightHand.GetComponent<ActivateGunLaser>().fire)
        {
            if (!laserHit)
            {
                gunSound.Play();
                rightHand.GetComponent<ActivateGunLaser>().fire = false;
                violationSystem.AddViolation();
                return;
            }

            if (rainScript != null && rainScript.RainIntensity > 0)
            {
                violationSystem.AddViolation();
            }

            gunSound.Play();
            GameObject bullet = Instantiate(bulletHolePrefab, hit.point, Quaternion.identity);
            rightHand.GetComponent<ActivateGunLaser>().fire = false;
            Destroy(bullet, 5f);

            switch (hit.transform.tag)
            {
                case "4":
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Последний счёт: 4");
                    AllScore += 4;
                    DistanceText.GetComponent<TextMeshProUGUI>().text = "Дистанция: " + Vector3.Distance(transform.position, hit.point).ToString();
                    break;
                case "5":
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Последний счёт: 5");
                    AllScore += 5;
                    DistanceText.GetComponent<TextMeshProUGUI>().text = "Дистанция: " + Vector3.Distance(transform.position, hit.point).ToString();
                    break;
                case "6":
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Последний счёт: 6");
                    AllScore += 6;
                    DistanceText.GetComponent<TextMeshProUGUI>().text = "Дистанция: " + Vector3.Distance(transform.position, hit.point).ToString();
                    break;
                case "7":
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Последний счёт: 7");
                    AllScore += 7;
                    DistanceText.GetComponent<TextMeshProUGUI>().text = "Дистанция: " + Vector3.Distance(transform.position, hit.point).ToString();
                    break;
                case "8":
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Последний счёт: 8");
                    AllScore += 8;
                    DistanceText.GetComponent<TextMeshProUGUI>().text = "Дистанция: " + Vector3.Distance(transform.position, hit.point).ToString();
                    break;
                case "9":
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Последний счёт: 9");
                    AllScore += 9;
                    DistanceText.GetComponent<TextMeshProUGUI>().text = "Дистанция: " + Vector3.Distance(transform.position, hit.point).ToString();
                    break;
                case "10":
                    TextScore.GetComponent<TextMeshProUGUI>().SetText("Последний счёт: 10");
                    AllScore += 10;
                    DistanceText.GetComponent<TextMeshProUGUI>().text = "Дистанция: " + Vector3.Distance(transform.position, hit.point).ToString();
                    break;
                case "Score Clear":
                    AllScore = 0;
                    break;
                case "Score Clear Places":
                    AllPlaces = 0;
                    break;
                case "plate":
                    Destroy(bullet);
                    GameObject plateGameObject = hit.transform.gameObject;
                    GameObject Smoke = Instantiate(smoke, plateGameObject.transform.position, Quaternion.identity);
                    Destroy(Smoke, 8f);
                    Destroy(plateGameObject);
                    AllPlaces++;
                    DistancePlaceText.GetComponent<TextMeshProUGUI>().text = "Дистанция: " + Vector3.Distance(transform.position, hit.point).ToString();
                    break;
                case "Person":
                    violationSystem.AddViolation();
                    Destroy(hit.transform.gameObject);
                    break;
            }
            AllScoreText.GetComponent<TextMeshProUGUI>().text = "Общий счёт: " + AllScore.ToString();
            ScorePlacesText.GetComponent<TextMeshProUGUI>().text = "Тарелок сбито: " + AllPlaces.ToString();
        }
        else
        {
            if (laserHit && hit.transform.CompareTag("Person") && !isViolationCooldown)
            {
                StartCoroutine(TimeBetweenViolations());
            }
        }
    }

    IEnumerator TimeBetweenViolations()
    {
        isViolationCooldown = true;
        violationSystem.AddViolation();
        yield return new WaitForSeconds(5f);
        isViolationCooldown = false;
    }
}

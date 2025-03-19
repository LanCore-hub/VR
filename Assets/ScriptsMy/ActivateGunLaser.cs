using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ActivateGunLaser : MonoBehaviour
{
    public GameObject laser;
    public bool laserEnable;

    public bool fire;

    private SteamVR_Action_Boolean m_Trigger;
    private SteamVR_Action_Boolean reloadAction;
    private SteamVR_Action_Boolean uploadAction;
    private SteamVR_Behaviour_Pose m_Pose;

    [SerializeField] private int maxAmmo = 12;
    [SerializeField] private int currentAmmo;
    public int AllAmmo = 60;
    [SerializeField] private bool canReload = true;
    [SerializeField] private bool canUpload = true;
    [SerializeField] private bool isNormotive;

    [SerializeField] private bool infiniteAmmoMode = true;

    [SerializeField] private GameObject Magazin;
    private Vector3 magazinStart;
    private Vector3 magazinFinish;

    private bool isMoving = false;
    private float moveDuration = 0.5f; // Длительность перемещения

    [SerializeField] private AudioSource shelkSound;
    [SerializeField] GameObject Teleport;

    [SerializeField] private GameObject btn1;
    [SerializeField] private GameObject btn2;
    [SerializeField] private GameObject btn3;

    [SerializeField] private GameObject zvanie1;
    [SerializeField] private GameObject zvanie2;
    [SerializeField] private GameObject zvanie3;
    [SerializeField] private GameObject Gun;

    private void Awake()
    {
        m_Trigger = SteamVR_Actions._default.InteractUI;
        reloadAction = SteamVR_Actions._default.reload;
        uploadAction = SteamVR_Actions._default.upload;

        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Start()
    {
        laserEnable = false;
        fire = false;

        magazinStart = new Vector3(0.597259641f, -0.12053898f, 0);
        magazinFinish = new Vector3(0.9f, -1.242f, 0);
        isMoving = false;
    }

    void Update()
    {
        if (m_Trigger.GetStateDown(m_Pose.inputSource) && currentAmmo == 0 && !isMoving)
        {
            Debug.Log("Патронов нет");
        }

        if (m_Trigger.GetStateDown(m_Pose.inputSource) && currentAmmo > 0 && !isMoving)
        {
            StartCoroutine(Shoot());
        }

        if (reloadAction.GetStateDown(m_Pose.inputSource) && !isMoving && canReload && AllAmmo > 0)
        {
            if (infiniteAmmoMode)
            {
                if (currentAmmo != maxAmmo)
                {
                    StartCoroutine(MoveMagazin(magazinStart, magazinFinish));
                    Reload();
                }
            }
            else
            {
                if (currentAmmo != maxAmmo)
                {
                    StartCoroutine(MoveMagazin(magazinStart, magazinFinish));
                    Reload();
                }
            }
        }

        if (uploadAction.GetStateDown(m_Pose.inputSource) && !isMoving && canUpload && currentAmmo != 0)
        {
            StartCoroutine(MoveMagazin(magazinStart, magazinFinish));
            Unload();
        }

        if (isNormotive)
        {
            if (currentAmmo == 0 && AllAmmo == 0)
            {
                Teleport.GetComponent<TeleportArea>().locked = false;
            }
        }
    }

    public void Reload()
    {
        if (infiniteAmmoMode)
        {
            currentAmmo = maxAmmo;
            Debug.Log("Оружие перезаряжено. Патронов: " + currentAmmo + " (бесконечный режим)");
        }
        else
        {
            if (AllAmmo > 0) // Проверяем, есть ли патроны вне оружия
            {
                int b = maxAmmo - currentAmmo; // Свободное место в магазине
                if (b > 0) // Если есть свободное место
                {
                    int ammoToMove = Mathf.Min(b, AllAmmo); // Сколько патронов можно переместить
                    currentAmmo += ammoToMove; // Добавляем патроны в магазин
                    AllAmmo -= ammoToMove; // Убираем патроны из AllAmmo
                }
            }
            Debug.Log("Недостаточно патронов для перезарядки");
        }
    }

    // Метод для разрядки оружия
    public void Unload()
    {
        if (!infiniteAmmoMode)
        {
        }
        AllAmmo += currentAmmo;
        currentAmmo = 0;
        Debug.Log("Оружие разряжено. Патронов: " + currentAmmo);
    }

    private IEnumerator MoveMagazin(Vector3 startPos, Vector3 endPos)
    {
        isMoving = true;
        float elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            Magazin.transform.localPosition = Vector3.Lerp(startPos, endPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            Magazin.transform.localPosition = Vector3.Lerp(endPos, startPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Magazin.transform.localPosition = startPos;
        shelkSound.Play();
        isMoving = false;
    }

    private IEnumerator Shoot()
    {
        // Уменьшаем количество патронов
        currentAmmo--;
        fire = true;

        // Ждём, пока пуля достигнет цели (например, 0.1 секунды)
        yield return new WaitForSeconds(0.1f);

        // Проверяем, если патроны закончились, завершаем раунд
        if (currentAmmo == 0 && AllAmmo == 0)
        {
            FinishRound();
        }
    }

    private void FinishRound()
    {
        if (btn1.GetComponent<LoadNormative1>().isNormative1)
        {
            if (Gun.GetComponent<LaserSight>().AllScore >= 150 && Gun.GetComponent<LaserSight>().AllScore < 160)
            {
                zvanie1.GetComponent<TextMeshProUGUI>().SetText("I юн.");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 160 && Gun.GetComponent<LaserSight>().AllScore < 170)
            {
                zvanie1.GetComponent<TextMeshProUGUI>().SetText("III");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 170 && Gun.GetComponent<LaserSight>().AllScore < 182)
            {
                zvanie1.GetComponent<TextMeshProUGUI>().SetText("II");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 182)
            {
                zvanie1.GetComponent<TextMeshProUGUI>().SetText("I");
            }
            else
            {
                zvanie1.GetComponent<TextMeshProUGUI>().SetText("-");
            }
            btn1.GetComponent<LoadNormative1>().isNormative1 = false;
        }
        else if (btn2.GetComponent<LoadNormative2>().isNormative2)
        {
            if (Gun.GetComponent<LaserSight>().AllScore >= 352 && Gun.GetComponent<LaserSight>().AllScore < 364)
            {
                zvanie2.GetComponent<TextMeshProUGUI>().SetText("II");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 364 && Gun.GetComponent<LaserSight>().AllScore < 376)
            {
                zvanie2.GetComponent<TextMeshProUGUI>().SetText("I");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 376 && Gun.GetComponent<LaserSight>().AllScore < 386)
            {
                zvanie2.GetComponent<TextMeshProUGUI>().SetText("КМС");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 386)
            {
                zvanie2.GetComponent<TextMeshProUGUI>().SetText("МС");
            }
            else
            {
                zvanie2.GetComponent<TextMeshProUGUI>().SetText("-");
            }
            btn2.GetComponent<LoadNormative2>().isNormative2 = false;
        }
        else if (btn3.GetComponent<LoadNormative3>().isNormative3)
        {
            if (Gun.GetComponent<LaserSight>().AllScore >= 548 && Gun.GetComponent<LaserSight>().AllScore < 565)
            {
                zvanie3.GetComponent<TextMeshProUGUI>().SetText("I");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 565 && Gun.GetComponent<LaserSight>().AllScore < 580)
            {
                zvanie3.GetComponent<TextMeshProUGUI>().SetText("КМС");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 580 && Gun.GetComponent<LaserSight>().AllScore < 586)
            {
                zvanie3.GetComponent<TextMeshProUGUI>().SetText("МС");
            }
            else if (Gun.GetComponent<LaserSight>().AllScore >= 586)
            {
                zvanie3.GetComponent<TextMeshProUGUI>().SetText("МСМК");
            }
            else
            {
                zvanie3.GetComponent<TextMeshProUGUI>().SetText("-");
            }
            btn3.GetComponent<LoadNormative3>().isNormative3 = false;
        }
    }
}

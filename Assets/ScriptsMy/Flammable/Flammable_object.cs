using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable_object : MonoBehaviour
{
    public bool on_fire;
    ParticleSystem fire_FX;
    ParticleSystem smoke_FX;
    Material[] materials_AR;
    float color_time;
    bool change_color_ON;
    float change_color_speed = 0.0003f;
    float fire_OFF_delay = 20;
    float smoke_OFF_delay = 5;
    float destroy_delay = 5;
    int fire_points = 300; // ������� ������ ������ ������� �� ������ ��� ����������
    int initial_fire_points; // ��������� ���������� ����� ����������

    void Start()
    {
        fire_FX = GetComponent<ParticleSystem>();
        smoke_FX = transform.GetChild(0).GetComponent<ParticleSystem>();
        materials_AR = transform.parent.GetComponent<MeshRenderer>().materials; // ���� ��� ��������� �� ������������ �������
        if (on_fire) StartCoroutine("Ignition");
        fire_points = Random.Range(fire_points - fire_points / 2, fire_points + fire_points / 2); // ������� ���-�� ����� ���������� ��� ������� �������
        initial_fire_points = fire_points; // ��������� ��������� ���������� ����� ����������
    }

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "Flammable_object") // ���� ������� ���� ����������� � ������ ����������� ��������
        {
            if (!obj.transform.GetChild(0).GetComponent<Flammable_object>().on_fire) obj.transform.GetChild(0).GetComponent<Flammable_object>().Ignition_attempt();
        }
    }

    void Update()
    {
        if (on_fire)
        {
            color_time += Time.deltaTime * change_color_speed;
            foreach (Material mat in materials_AR) mat.color = Color.Lerp(mat.color, Color.black, color_time);
        }
    }

    public void Ignition_attempt() // ������� �������
    {
        fire_points--;
        if (fire_points == 0) StartCoroutine("Ignition");
    }

    public void Extinguish_attempt() // ������� �������
    {
        fire_points += 2;
        if (fire_points >= initial_fire_points)
        {
            StopCoroutine("Ignition");
            on_fire = false;
            fire_FX.Stop();
            smoke_FX.Stop();
            transform.parent.tag = "Flammable_object"; // ���������� ���, ����� ������ ����� ��� ���� �������
            transform.parent.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    IEnumerator Ignition() // ������
    {
        on_fire = true;
        transform.parent.tag = "Extinguish"; // ������� ���, ����� ������ �� ���� ������� �������
        transform.parent.gameObject.layer = LayerMask.NameToLayer("On_fire"); // ����� ������� ���� �� ����������������� � ����������� �������� �������
        fire_FX.Play(); // ����� ����������� � ������� �������� ��������
        yield return new WaitForSeconds(Random.Range(fire_OFF_delay - fire_OFF_delay / 2, fire_OFF_delay + fire_OFF_delay / 2));
        smoke_FX.transform.parent = fire_FX.transform.parent; // ������������ ��� �� �������� ���� � ��������, ����� �� ��������������� ������� ����
        fire_FX.Stop();
        transform.parent.tag = "Untagged";
        yield return new WaitForSeconds(Random.Range(smoke_OFF_delay - smoke_OFF_delay / 2, smoke_OFF_delay + smoke_OFF_delay / 2));
        smoke_FX.Stop();
        yield return new WaitForSeconds(destroy_delay);
        Destroy(gameObject);
    }
}
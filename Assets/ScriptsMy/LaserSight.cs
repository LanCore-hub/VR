using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserSight : MonoBehaviour
{
    public Color laserColor = Color.red;
    public float laserDistance = 100f;
    public float laserWidth = 0.1f;

    private LineRenderer lineRenderer;
    void Start()
    {
        // Создаём компонент LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.startColor = laserColor;
        lineRenderer.endColor = laserColor;
    }

    void Update()
    {
        lineRenderer.enabled = true;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserDistance))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * laserDistance);
        }
    }
}

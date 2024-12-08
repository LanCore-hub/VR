using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;

public class ABC : SteamVR_LaserPointer
{
    public override void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Button>().onClick.Invoke();
        }
    }

    public override void OnPointerOut(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("ButtonUI"))
        {
            e.target.GetComponent<Image>().color = Color.white;
        }
    }

    public UnityEngine.Vector3 GetLaserPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            return hit.point;
        }
        else
        {
            return transform.position + transform.forward * 100f;
        }
    }
}

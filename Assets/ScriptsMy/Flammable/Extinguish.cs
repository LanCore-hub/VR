using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguish : MonoBehaviour
{
    private void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "Extinguish")
        {
            if (obj.transform.GetChild(0).GetComponent<Flammable_object>().on_fire) obj.transform.GetChild(0).GetComponent<Flammable_object>().Extinguish_attempt();
        }
    }
}

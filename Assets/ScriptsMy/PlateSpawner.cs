using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject platePrefab;
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 5f;
    public float launchForce = 10f;
    public float minAngel;
    public float maxAngel;

    private void Start()
    {
        StartCoroutine(SpawnPlateCoroutine());
    }

    private IEnumerator SpawnPlateCoroutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            SpawnPlate();
        }
    }

    void SpawnPlate()
    {
        Quaternion fixedRotation = Quaternion.Euler(0, -90, 90);
        GameObject plate = Instantiate(platePrefab, transform.position, fixedRotation);
        Rigidbody rb = plate.GetComponent<Rigidbody>();
        float randomAngle = Random.Range(minAngel, maxAngel);

        Quaternion rotation = Quaternion.Euler(randomAngle, 0, 0);
        Vector3 launchDirection = rotation * transform.forward;
        rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);

        Destroy(plate, 10f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform[] waypoints;

    private void Start()
    {
        StartCoroutine(SpawnObjectWithDelay());
    }

    private IEnumerator SpawnObjectWithDelay()
    {
        while (true)
        {
            float delay = Random.Range(2f, 5f);

            yield return new WaitForSeconds(delay);

            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

            PersonScript personScript = spawnedObject.GetComponent<PersonScript>();
            if (personScript != null)
            {
                personScript.SetWaypoints(waypoints);
            }
        }
    }
}

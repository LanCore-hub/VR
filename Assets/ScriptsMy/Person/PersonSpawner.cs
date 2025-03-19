using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject objectToSpawn1;
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
            float delay = Random.Range(20f, 50f);

            yield return new WaitForSeconds(delay);

            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        GameObject objectToSpawnRandom = Random.Range(0, 2) == 0 ? objectToSpawn : objectToSpawn1;
        if (objectToSpawn != null && spawnPoint != null)
        {
            GameObject spawnedObject = Instantiate(objectToSpawnRandom, spawnPoint.position, spawnPoint.rotation);

            PersonScript personScript = spawnedObject.GetComponent<PersonScript>();
            if (personScript != null)
            {
                personScript.SetWaypoints(waypoints);
            }
        }
    }
}

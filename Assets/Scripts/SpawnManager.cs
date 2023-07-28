using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float spawnRange = 10f;
    public int maxEnemies = 10;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    public GameObject Dummy;

    void Start()
    {
        // Call a method to start spawning enemies at regular intervals
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
            {
                Vector3 spawnPosition = Random.insideUnitSphere * spawnRange;
                spawnPosition.y = 0f; // Set the y position to 0 or the desired height above the ground
                Instantiate(Dummy, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(2f); // Adjust the spawn interval as needed
        }
    }
}

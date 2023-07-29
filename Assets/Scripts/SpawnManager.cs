using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Dummy;
    public int maxEnemies = 60;
    public float spawnInterval = 0.1f;
    public MazeGenerator mazeGenerator; // Reference to the MazeGenerator script

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                Debug.Log(spawnPosition);

                // Spawn the enemy at the calculated spawn position
                Instantiate(Dummy, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval); // Adjust the spawn interval as needed
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Get a random MazeCell from the maze grid
        MazeCell randomCell = mazeGenerator.GetRandomMazeCell();

        // Calculate the center position of the MazeCell for enemy spawning
        Vector3 spawnPosition = new Vector3(randomCell.transform.position.x, 0f, randomCell.transform.position.z);

        return spawnPosition;
    }
}

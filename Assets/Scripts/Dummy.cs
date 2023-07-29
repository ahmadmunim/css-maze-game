using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public MazeGenerator mazeGenerator; // Reference to the MazeGenerator script

    public float moveSpeed = 1f;
    private MazeCell[] mazeCells; // An array to store maze cells for the enemy to move between
    private int targetIndex = 0;

    void Start()
    {
        mazeCells = new MazeCell[2]; // Create an array to store two maze cells

        // Get random maze cells from the MazeGenerator and store them in the mazeCells array
        mazeCells[0] = mazeGenerator.GetRandomMazeCell();
        mazeCells[1] = mazeGenerator.GetRandomMazeCell();

        // Start by moving towards the first maze cell
        targetIndex = 0;
    }

    void Update()
    {
        // Check if there are any maze cells defined
        if (mazeCells.Length == 0)
        {
            Debug.LogError("No maze cells assigned to the enemy!");
            return;
        }

        // Get the direction towards the current target maze cell
        Vector3 targetDirection = mazeCells[targetIndex].transform.position - transform.position;
        targetDirection.y = 0f; // Ignore any vertical component

        // Check if the enemy has reached the current target maze cell
        if (targetDirection.magnitude <= 0.1f)
        {
            // Switch the target index to the other maze cell
            targetIndex = (targetIndex + 1) % mazeCells.Length;
        }

        // Move the enemy towards the current target maze cell
        Vector3 moveAmount = targetDirection.normalized * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount, Space.World);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1f;
    

    void start() {
    }

    void Update()
    {
        // Calculate the movement amount based on the prefab's forward direction
        // Vector3 moveAmount = transform.forward * moveSpeed * Time.deltaTime;
        // // Move the prefab
        // transform.Translate(moveAmount, Space.World);
    }
}


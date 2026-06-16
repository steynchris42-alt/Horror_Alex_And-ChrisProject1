using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement_Simple : MonoBehaviour
{
    Rigidbody rbod;
   

    void Start()
    {
        rbod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbod.AddForce(Vector3.up * 5, ForceMode.Impulse); // Add an upward force to the player's Rigidbody when the space key is pressed
        }

        if (Input.GetKey(KeyCode.D))
        {
            rbod.linearVelocity = new Vector3(6f, rbod.linearVelocity.y , rbod.linearVelocity.z);

        }

        if (Input.GetKey(KeyCode.A))
        {
            rbod.linearVelocity = new Vector3(-6f, rbod.linearVelocity.y, rbod.linearVelocity.z);

        }

        if (Input.GetKey(KeyCode.W))
        {
            rbod.linearVelocity = new Vector3(rbod.linearVelocity.x, rbod.linearVelocity.y, 6f);

        }

        if (Input.GetKey(KeyCode.S))
        {
            rbod.linearVelocity = new Vector3(rbod.linearVelocity.x, rbod.linearVelocity.y, -6f);

        }

    }
}

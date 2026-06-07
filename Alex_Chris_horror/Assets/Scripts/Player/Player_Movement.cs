using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    Rigidbody RigBod;
    public Camera player_cam;
    Vector3 MoveDir = new Vector3(0, 0, 0);

    public float MoveSpeed = 10.0f;

    void Start()
    {
        RigBod = GetComponent<Rigidbody>();

    }
    void Update()
    {
        //Converting the transform rotations of camera and player to floats so that they can be used together easier.
        float CamRotateX = player_cam.transform.rotation.eulerAngles.x;
        float Transform_RotateX = transform.rotation.eulerAngles.x;

        float CamRotateY = player_cam.transform.rotation.eulerAngles.y;
        float Transform_RotateY = transform.rotation.eulerAngles.x;

        float CamRotateZ = player_cam.transform.rotation.eulerAngles.z;
        float Transform_RotateZ = transform.rotation.eulerAngles.z;

        Transform_RotateX = CamRotateX;
        Transform_RotateY = CamRotateY;
        Transform_RotateZ = CamRotateZ;
        //setting the players rotation to the rotation of the camera.
        transform.rotation = Quaternion.Euler(CamRotateX, 0, CamRotateZ);

        ///WASD cheacks
       Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
        {
        
            return;
        }
        else
        {
            MoveDir = Vector3.zero; // resetting the Direction to 0 at the start of each cheack to avoid force stacking.

            if (keyboard.wKey.isPressed)
            {
                MoveDir.z += 1;
            }
            if (keyboard.aKey.isPressed)
            {
                MoveDir.x -= 1;
            }
            if (keyboard.sKey.isPressed)
            {
                MoveDir.z -= 1;
                
            }
            if (keyboard.dKey.isPressed)
            {
                MoveDir.x += 1;
             
            }
        }
      
    }
    public void FixedUpdate()
    {
        //Creating a force that is applied in the correct directions
       Vector3 Velocity_Norm = MoveDir.normalized;
       Vector3 Velocity_All = (transform.forward * Velocity_Norm.z + transform.right * Velocity_Norm.x) *  MoveSpeed;   
        
        //Adding the force vector to the RigidBody using the velocityChange ForceMode.
       RigBod.AddForce(Velocity_All , ForceMode.VelocityChange);
        
    }

 
}

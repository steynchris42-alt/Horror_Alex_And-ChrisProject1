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
        float CamRotateX = player_cam.transform.rotation.eulerAngles.x;
        float Transform_RotateX = transform.rotation.eulerAngles.x;

        float CamRotateY = player_cam.transform.rotation.eulerAngles.y;
        float Transform_RotateY = transform.rotation.eulerAngles.x;

        Transform_RotateX = CamRotateX;
        Transform_RotateY = CamRotateY;

              Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
        {
            return;
        }
     
        else
        {
            MoveDir = Vector3.zero;
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
        Vector3 Velocity_Norm = MoveDir.normalized * MoveSpeed;
       
           RigBod.AddForce(Velocity_Norm , ForceMode.Force);
        
    }

 
}

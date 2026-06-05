using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    Rigidbody RigBod;

    public Vector3 XAxis = new Vector3(1.0f,0.0f,0.0f);
    public Vector3 YAxis = new Vector3(0.0f, 1.0f, 0.0f);
    public Vector3 ZAxis = new Vector3(0.0f, 0.0f, 0.1f);

    public float DirX = 0.0f;
    public float DirY = 0.0f;
    public float DirZ = 0.0f;

    public float MoveSpeed = 5.0f;


    void Start()
    {
        RigBod = GetComponent<Rigidbody>();

    }
    void Update()
    {

        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
        {
            return;
        }
        else
        {
         if (keyboard.wKey.isPressed)
            {
                transform.position += ZAxis * MoveSpeed;
                Debug.Log("W");
            }
            if (keyboard.aKey.isPressed)
            {
                transform.position -= XAxis;
            }
            if (keyboard.sKey.isPressed)
            {
                transform.position -= ZAxis;
            }
            if (keyboard.dKey.isPressed)
            {
                transform.position += XAxis;
            }

        }
      
    }
    public void FixedUpdate()
    {
        ZAxis = ZAxis * MoveSpeed;
        RigBod.AddForce(ZAxis * MoveSpeed, ForceMode.Force);
     
    }

 
}

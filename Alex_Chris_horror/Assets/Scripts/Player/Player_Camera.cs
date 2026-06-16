using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Camera : MonoBehaviour
{
   public CinemachineCamera CinCam;
   public Keyboard keyboard;
    public Player_Movement PlayerMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CinCam = GetComponent<CinemachineCamera>();
        keyboard = Keyboard.current;
    }
    // Update is called once per frame
    void Update()
    {
        if (keyboard.shiftKey.wasReleasedThisFrame)
        {
            CinCam.Lens.FieldOfView = 60.0f;
     
        }
       else 
       if (keyboard.shiftKey.isPressed && keyboard.wKey.isPressed || keyboard.aKey.isPressed || keyboard.sKey.isPressed || keyboard.dKey.isPressed)
        {
            CinCam.Lens.FieldOfView = 70.0f;
        
        }        
       
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
public class PlayerGrounded : MonoBehaviour
{

    public bool IsGrounded;
    public LayerMask Ground;

    public GameObject PlayerArea;

    public void Update()
    {
       Vector3 RayOrigon = transform.position;
        Vector3 RayDir = Vector3.down;
        float RayDis = 10.0f;
        float Dis_Ground = Vector3.Distance(RayOrigon, PlayerArea.transform.position);
        RaycastHit hit;

        IsGrounded = Physics.Raycast(RayOrigon, RayDir, out hit, RayDis, Ground);
      if (IsGrounded == true)
        {
            Debug.DrawRay(RayOrigon, RayDir * RayDis, Color.blue);
        }
        else
        {
            Debug.DrawRay(RayOrigon, RayDir * RayDis, Color.red);
        }
    
        Debug.Log("Ray distance" + hit.distance);




    }
}


using JetBrains.Annotations;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{

    public bool IsGrounded;
    public LayerMask Ground;

    public GameObject PlayerArea;
   

    public Rigidbody RigBod;
    public void Awake()
    {
        RigBod = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        IsGrounded = GroundRay();

    }
    public void FixedUpdate()
    {
        float DropSpeed = 100.0f;
        if (IsGrounded == false)
        {
          RigBod.AddForce(Vector3.down * DropSpeed , ForceMode.Impulse);

        }
    }
    public bool GroundRay()
    {
        Vector3 RayOrigon = transform.position;
        Vector3 RayDir = Vector3.down;
        float RayDis = 3.50f;
        float Dis_Ground = Vector3.Distance(RayOrigon, PlayerArea.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(RayOrigon, RayDir, out hit, RayDis, Ground))
        {
            Debug.DrawRay(RayOrigon, RayDir * RayDis, Color.blue);
            IsGrounded = true;
            return true;
        }
        else
        {
            {
                Debug.DrawRay(RayOrigon, RayDir * RayDis, Color.red);
                IsGrounded = false;
                return false;
            }

        }
    }
}

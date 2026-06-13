using UnityEngine;

public class SimplePickUp : MonoBehaviour
{
    public Transform player;
    public float range;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= range && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("It's Working");
            Destroy(gameObject);
        }
    }
}

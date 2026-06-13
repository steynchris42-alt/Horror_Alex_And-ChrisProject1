using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private float _interactionRange = 5f; // how far the player can interact with objects

    [SerializeField]
    private Vector3 _rayPosition = new Vector3(0, 1f, 0);

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(DoInteractionTest(out IInteractable interactable))
            {
                if(interactable.CanInteract())
                {
                    interactable.Interact(this);
                }
            }
        }
    }
    private bool DoInteractionTest(out IInteractable interactable)
    {
        interactable = null;

        Ray ray = new Ray(transform.position + _rayPosition, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _interactionRange))
        {
            interactable = hitInfo.collider.GetComponent<IInteractable>(); // checks if the object has the IInteractable interface and assigns it to the interactable variable
           
            if (interactable != null)
            {
                return true;
            }
            return false;
        }
        return false;

    }

}

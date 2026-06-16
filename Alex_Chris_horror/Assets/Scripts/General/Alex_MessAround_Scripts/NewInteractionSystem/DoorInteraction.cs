using UnityEngine;
using DG.Tweening;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private bool _isOpen = false; // check if the intecation must take place 

    [SerializeField]
    private float _rotationSpeed = 5f; // the Tween duration in seconds

    [SerializeField]
    private Vector3 _targetRotation = new Vector3(0, 100f, 0); // the actual movement (the rotation of the door)


    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        if (_isOpen)
        {
            transform.DORotate(_targetRotation, _rotationSpeed, RotateMode.WorldAxisAdd);
        }
        else
        {
            transform.DORotate(-_targetRotation, _rotationSpeed, RotateMode.WorldAxisAdd);
        }
        _isOpen = !_isOpen;
        return true;
    }
}

using UnityEngine;
using DG.Tweening;

public class ItemRotate : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 2f; // Duration of the rotation in seconds
    [SerializeField]
    private Vector3 _rotationVector = new Vector3(0f, 360f, 0f); // Rotation angle (360 degrees around Y-axis)

    void Start()
    {
        transform.DORotate(_rotationVector, _rotationSpeed, RotateMode.WorldAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
}

using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] float smooth;
    [SerializeField] float rotation;

    void FixedUpdate()
    {
        smooth += rotation;
        transform.rotation = Quaternion.Euler(0, 0, smooth);
    }
}

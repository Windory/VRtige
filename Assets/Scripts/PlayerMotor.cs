using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 cameraRotation;


    [SerializeField]
    private Camera cam;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);


        }
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    void PerformRotation()
    {
        if (rotation != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
            cam.transform.Rotate(-cameraRotation);

        }
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }
}

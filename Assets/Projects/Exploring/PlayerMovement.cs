using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //TransformBasedMovement();
        PhysicsBasedMovement();
        
    }
    void TransformBasedMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void PhysicsBasedMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirction = new Vector3(horizontal, 0, vertical);
        rb.linearVelocity = moveDirction * moveSpeed;
        //rb.AddForce(moveDirction * moveSpeed);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player Collided with: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Entered trigger with: " + other.gameObject.name);
    }
}

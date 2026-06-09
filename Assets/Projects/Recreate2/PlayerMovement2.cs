using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    
    [Header("PLAYER ATTRIBUTES")]
    public float moveSpeed;
    public float rotateSpeed;
    public float jumpForce;
    private bool isOnGround;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * vertical;
        rb.AddForce(movement * moveSpeed);
        transform.Rotate(Vector3.up * horizontal * rotateSpeed * Time.deltaTime);
        
    }
    private void Update()
    {
        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isOnGround= false;
    }
}

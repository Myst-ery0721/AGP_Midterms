using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [Header("InputActionReferences")]
    public InputActionReference move;
    public InputActionReference jump;

    [Header("Variables")]
    private Vector2 moveInput;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpforce = 5f;
    Rigidbody rb;
    public bool onGround = false;


    private void Awake()
    {
        //Imediately get Rigid body from where it is attached
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Call imput Action and read from the InputMap
        moveInput = move.action.ReadValue<Vector2>();

        // Player movement Using transform.translate (Basics)
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);
        //transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void FixedUpdate()
    {
        //Why is it on fixed Update?: Unity reders this on a fixed time step. while Update() renders per frame. 
        // which provides more consistency for physics renders in this rather than update()
        // This is movement Using rigidbody
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 velocity = direction * speed;
        velocity.y = rb.linearVelocity.y; //On older versions its called Velocity but on newer versions its a diff name but same. 
        rb.linearVelocity = velocity;

    }
    private void OnEnable()
    {
        //This is how you call a method name from the Input Action map
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        //It is important to enable and disable them for more accurate results!
        //It ensures that when the object is destroyed or disabled, the event reference is removed.
        jump.action.started -= Jump;
    }

    // The method called from +=Jump
    private void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jumped");
        if (onGround == true)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            onGround = false;
        }
    }

    //Detecting Collions used for Jump
    private void OnCollisionEnter(Collision collision)
    {
        //Boolean just to avoid double jumps
        onGround = true;
    }
}



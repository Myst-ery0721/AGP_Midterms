using Unity.VisualScripting;
using UnityEngine;

public class DashSystem : MonoBehaviour
{

    [Header("COOLDOWN CONTROLS")]
    [SerializeField] private float cooldownTime = 5f;
    [SerializeField] private float cooldownTimer;
    [Header("DASH CONTROLS")]
    [SerializeField] private float dashDuration = 3f;
    [SerializeField] private float dashTimer;
    private bool isDashing = false;
    [SerializeField] private float moveSpeed = 10f;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer >= cooldownTime)
        {
            if (!isDashing)
            {
                isDashing = true;
            }
        }
        if (isDashing)
        {
            Dash();
        }
    }

    private void Dash()
    {
        dashTimer += Time.deltaTime;
        //Player Dashes
        Debug.Log("Player is Now Dashing");

        //Vector3 dashDirection = playerMovement.MoveDirection;
        //transform.Translate(dashDirection.normalized * moveSpeed * Time.deltaTime);

        if (dashTimer >= dashDuration)
        {
            isDashing = false;
            dashTimer = 0;
            cooldownTimer = 0;
        }
    }
}
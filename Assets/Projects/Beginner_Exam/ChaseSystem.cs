using UnityEngine;

public class ChaseSystem : MonoBehaviour
{
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float attackTimer;
    [SerializeField] private float attackCooldown = 5f;
    public Transform playerPosition;
    void Update()
    {
        distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);
        if (distanceToPlayer <= attackRange)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackCooldown)
            {
                Debug.Log("ATTACKING PLAYER!!!");
                attackTimer = 0;
            }
            
        }
        else if (distanceToPlayer <= chaseRange)
        {
            Debug.Log("CHASING PLAYER!!!");
            attackTimer = 0;
        }
        else
        {
            Debug.Log("PATROLLING...");

            attackTimer = 0;
        }
    }
}

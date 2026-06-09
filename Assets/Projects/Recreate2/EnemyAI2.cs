using System.Collections;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    public enum EnemyStates
        {
            IDLE, CHASE, ATTACK
        }
    [Header("ENEMY SETTINGS-------")]
    public int enemyHealth = 100;
    public float range;
    public float attackRange;
    public float chaseRange;
    public float enemySpeed;
    public int enemyDamage;
    public int enemyAttackCooldown;
    public EnemyStates enemyStates;

    bool canAttack = true;
    private Renderer rend;
    private Color ogMat;



    [Header("REFERENCES------")]
    public Transform player;
    public PlayerHealth2 playerHealth;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        ogMat = rend.material.color;
    }
    private void Update()
    {
        range = Vector3.Distance(player.position, transform.position);
        TransitionHandler();
        BehaviorHandler();
    }

    void TransitionHandler()
    {
        if(range <= attackRange)
        {
            enemyStates = EnemyStates.ATTACK;
        }
        else if (range <= chaseRange)
        {
            enemyStates = EnemyStates.CHASE;
        }
        else
        {
            enemyStates = EnemyStates.IDLE;
        }
    }
    void BehaviorHandler()
    {
        
        switch (enemyStates)
        {
            
            case EnemyStates.ATTACK:
                if(canAttack)
                {
                    StartCoroutine(AttackCooldown());
                }
                
                break;
            case EnemyStates.CHASE:
                Vector3 direction = player.position - transform.position;
                Vector3 lockPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
                transform.LookAt(lockPosition);
                transform.Translate(-direction * enemySpeed * Time.deltaTime);
                break;
            case EnemyStates.IDLE:
                
                break;
        }
    }
    public void enemyTakeDamage(int damage)
    {
        enemyHealth = enemyHealth - damage;
        StartCoroutine(DamageFlash1());
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    IEnumerator DamageFlash1()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rend.material.color = ogMat;
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        playerHealth.playerTakeDamage(enemyDamage);
         yield return new WaitForSeconds(enemyAttackCooldown);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

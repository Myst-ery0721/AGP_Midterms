using UnityEngine;

public class EnemyAI : MonoBehaviour
{
   public enum Enemystates
    {
        IDLE, CHASE, ATTACK
    }
    public Enemystates enemyStates;
    public float enemyRange;
    public float chaseRange, attackRange;
    public Transform player;
    public float enemySpeed;
    public PlayerHealth1 health;
    public int damage;
    public float cdTimer;


    private void Update()
    {
        enemyRange = Vector3.Distance(player.position, transform.position);
        StateTransition();
        StateBehavior();
    }
    //state Transition
    void StateTransition()
    {
        if (enemyRange <= attackRange)
        {
            enemyStates = Enemystates.ATTACK;
        }
        else if (enemyRange <= chaseRange)
        {
            enemyStates = Enemystates.CHASE;
        }
        else
        {
            enemyStates = Enemystates.IDLE;
        }

    }
    //State Behavior
    void StateBehavior()
    {
        
        Vector3 lockPosition = new Vector3(player.position.x, transform.position.y, player.position.z);    
        transform.LookAt(lockPosition);
        Renderer rend = GetComponent<Renderer>();
        Vector3 direction = player.position - transform.position;
        switch (enemyStates)
        {
            
            case(Enemystates.ATTACK):
                cdTimer += Time.deltaTime;
                rend.material.color = Color.white;
                if(cdTimer > 5f){
                    health.TakeDamage1(damage);
                    cdTimer = 0;
                }
                
                break;
            case(Enemystates.CHASE):
                transform.Translate(direction * enemySpeed * Time.deltaTime, Space.World);
                rend.material.color = Color.yellow;
                cdTimer = 0;
                break;
            case (Enemystates.IDLE):
                rend.material.color= Color.pink;
                cdTimer = 0;
                break;
        }
    }
    private void OnDrawGizmos()    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.orange;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

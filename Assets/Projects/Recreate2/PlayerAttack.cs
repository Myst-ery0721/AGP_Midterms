using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public EnemyAI2 enemyAI;
    public int damage;
    

    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && enemyAI.enemyStates == EnemyAI2.EnemyStates.ATTACK) 
        {
            enemyAI.enemyTakeDamage(damage);
            
        }

    }
    
}

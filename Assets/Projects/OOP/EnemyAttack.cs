using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerStats playerStats;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerStats.TakeDamage(20);
            //playerStats.health = 0;
        }
    }
}
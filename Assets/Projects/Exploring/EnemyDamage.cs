using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int enemyHealth = 100;
    public PlayerHealth stats;
    public int damage;

  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bullet Hurt Enemy");
            TakeDamage(damage);
        }
    }
    public void TakeDamage(int damage)
    {
        enemyHealth = enemyHealth - damage;
    }

}

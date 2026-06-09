using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float playerHealth = 10;
    private bool isAlive = true;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            TakeDamage(100);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            Heal(10);
        }
    }

    private void TakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        Debug.Log("PlayerHealth Now is: " + playerHealth);
        if (playerHealth <= 0 && isAlive)
        {
            Debug.Log("Player just died");
            Die();
        }
    }
    private void Heal(int heal)
    {
        if(playerHealth <= 99 && isAlive)
        {
            playerHealth = playerHealth + heal;
            Debug.Log("PlayerHealth Now is: " + playerHealth);
        }
        else if (playerHealth >= 100 && isAlive)
        {
            Debug.Log("MAX HP REACHED!");
            playerHealth = 100;
        }
    }
    private void Die()
    {
        isAlive = false;
        playerHealth = 0;
    }
}

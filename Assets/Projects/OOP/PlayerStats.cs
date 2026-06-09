using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public int mana = 50;
    void Start()
    {
        Debug.Log("Player HP: " + health);
        Debug.Log("Player Mana" + mana);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;

        Debug.Log("Player took damage!");
        Debug.Log("Current HP: " + health);
    }

    public void Heal(int healAmount)
    {
        health = health + healAmount;

        Debug.Log("Player healed!");
        Debug.Log("Current HP: " + health);
    }
}

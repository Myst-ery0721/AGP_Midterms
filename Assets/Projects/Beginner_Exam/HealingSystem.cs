using UnityEngine;

public class HealingSystem : MonoBehaviour
{
    [Header("PlayerHealth")]
    [SerializeField] private float health = 0;
    [Header("Player Cooldown")]
    [SerializeField] private float cooldownTimer;
    [SerializeField] private float cooldownDuration = 3f;
    [Header("Healing Settings")]
    [SerializeField] private bool isHealing = false;
    [SerializeField] private float healingTimer;
    [SerializeField] private float healingDuration = 5f;
    [SerializeField] private float RestoreHealth = 10f;

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer >= cooldownDuration && !isHealing)
        {
            isHealing = true;
            healingTimer = 0;
        }
        if (isHealing)
        {
            Healing();
        }
    }

    private void Healing()
    {
        //Temporary Movement method because I cant handle the original 
        if (Input.GetKeyDown(KeyCode.W))
        {
            isHealing = false;
            healingTimer = 0;
            Debug.Log("YOU MOVED!! CANCEL HEALING...");
        }
        else
        {
            healingTimer += Time.deltaTime;
            if(healingTimer >= healingDuration)
            {
                health = health + RestoreHealth;
                Debug.Log("HEALING PLAYER... Current Health is: " + health);

                isHealing = false;
                healingTimer = 0;
                cooldownTimer = 0;
            }
        }
    }

}

using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ChargedAttackSystem : MonoBehaviour
{
    [Header("CD")]
    [SerializeField] private bool isCharging = false;
    [SerializeField] private float chargedAttackCooldown = 5f;
    [SerializeField] private float chargedAttackCooldownTimer;
    [Header("Charged Attack Duration")]
    [SerializeField] private float chargedAttackDuration = 3f;
    [SerializeField] private float chargedAttackTimer;
    [Header("Damage Output")]
    [SerializeField] private float weakDamage = 10f;
    [SerializeField] private float maxDamage = 30f;

    void Update()
    {
        chargedAttackCooldownTimer += Time.deltaTime;
        if(!isCharging && Input.GetMouseButtonDown(1) && chargedAttackCooldownTimer >= chargedAttackCooldown)
        {
            isCharging = true;
        }

        if(isCharging && Input.GetMouseButton(1))
        {
            chargedAttackTimer += Time.deltaTime;
            Debug.Log("Is CHARGING!!!");
            
        }
        if (isCharging && Input.GetMouseButtonUp(1))
        {
            if (chargedAttackTimer >= chargedAttackDuration)
            {
                Debug.Log(maxDamage);
            }
            else
            {
                Debug.Log(weakDamage);
            }
            chargedAttackCooldownTimer = 0;
            chargedAttackTimer = 0;
            isCharging = false;
        }
    }


}

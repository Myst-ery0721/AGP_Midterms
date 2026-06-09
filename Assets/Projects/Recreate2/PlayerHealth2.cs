using System.Collections;
using UnityEngine;

public class PlayerHealth2 : MonoBehaviour
{
    public int playerHealth = 100;
    //public int damageFlashSeconds = ;
    private Renderer rend;
    private Color ogMat;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        ogMat = rend.material.color;
    }
    public void playerTakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        StartCoroutine(DamageFlash());
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DamageFlash()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rend.material.color = ogMat;

    }
}

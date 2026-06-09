using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth1 : MonoBehaviour
{
    public int health = 100 ;
    private Renderer rend;
    private Color originalMat;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalMat = rend.material.color;
    }
    private void Update()
    {
        
    }
    
    public void TakeDamage1(int damage)
    {
        health = health - damage;
        StartCoroutine(DamageFlash());
    }
    IEnumerator DamageFlash()
    {
        rend.material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        rend.material.color = originalMat;
    }
}

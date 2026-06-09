using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public GameObject prefab;
    public int moveSpeed;
    private GameObject spawnedPrefab;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spawnedPrefab = Instantiate(prefab, transform.position, transform.rotation);
        }
        spawnedPrefab.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
    }
}


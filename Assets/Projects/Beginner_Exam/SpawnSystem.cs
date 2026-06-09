using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 0;
    [SerializeField] private float spawnDuration = 5f;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnDuration)
        {
            Debug.Log("ENEMY SPAWNED");
            spawnTimer = 0f;
        }
    }
}

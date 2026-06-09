using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    void Update()
    {
        transform.Translate(Vector3.forward * shootSpeed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }
}

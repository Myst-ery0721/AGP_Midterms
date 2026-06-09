using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    public GameObject prefab;
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        Shoot();
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
        
    }
}

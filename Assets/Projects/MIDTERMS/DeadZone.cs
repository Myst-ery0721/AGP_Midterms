using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] private Transform cp1Pos;
    [SerializeField] private Transform cp2Pos;

    //checkpoint
    bool checkpoint1 = false;
    bool checkpoint2 = false;
    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // if player is in Y axis (-1) and down more, player will restart
        if (transform.position.y < -3f)
        {
            
            if (checkpoint1)
            {
                Vector3 cp1 = cp1Pos.position;
                transform.position = cp1;
            }
            else if(checkpoint2)
            {
                Vector3 cp2 = cp2Pos.position;
                transform.position = cp2;
            }
            else
            {
                transform.position = startPosition;
            }
        }
        else
        {
            //FINISH LINE
            Debug.Log("CONGRATULATIONS!");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CP1"))
        {
            checkpoint1 = true;
        }
        if (other.CompareTag("CP2"))
        {
            checkpoint2 = true;
            checkpoint1 = false;
        }
        if (other.CompareTag("END"));
    }
}

using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    bool checkPoint1, checkpoint2, Finishline;
    public Transform checkpoint1;

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //check what checkpoint
        if (other.CompareTag("Player"))
        {
            
        }

        
    }
}

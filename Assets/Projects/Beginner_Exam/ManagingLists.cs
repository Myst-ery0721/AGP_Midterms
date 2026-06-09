using UnityEngine;
using System.Collections.Generic;

public class ManagingLists : MonoBehaviour
{
    List<int> scores = new List<int>()
    {
        0, 0, 10, 20, 30, 40, 0, 0
    }; 
    private void Start()
    {
        Debug.Log("PreviousCount" + scores.Count);
        //foreach (int score in scores)
        //{
        //    Debug.Log(score);
        //}
        for (int i = scores.Count - 1; i >= 0; i--)
        {
            if (scores[i] <= 0)
            {
                scores.Add(100);
            }
            Debug.Log("UPDATED: " + scores.Count);
        }
    }
    void Update()
    {
        
    }
}

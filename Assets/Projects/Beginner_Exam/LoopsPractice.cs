using UnityEngine;
using System.Collections.Generic;
public class LoopsPractice : MonoBehaviour
{
    List<int> scores = new List<int>()
    {
        10, 20, 30
    };
    void Start()
    {
        for(int i = 0; i < scores.Count; i++)
        {
            Debug.Log(scores[i]);
            //scores[i] gets current item at current layer
            scores[i] = scores[i] * 3;
            Debug.Log(scores[i]);
            //modifying such as this results double the values
        }
    }
}

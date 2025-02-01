using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomFlyBall : MonoBehaviour
{
    [SerializeField] private List<string> flyBallTypes; 
    [SerializeField] private List<int> flyBallWeights;
    public string GetRandomFlyBallType(){
        int totalWeight = 0;
        foreach (int weight in flyBallWeights){
            totalWeight += weight;
        }

        int randomValue = Random.Range(0, totalWeight);
        int cumulativeWeight = 0;

        for (int i = 0; i < flyBallTypes.Count; i++)
        {
            cumulativeWeight += flyBallWeights[i];
            if (randomValue < cumulativeWeight)
            {
                return flyBallTypes[i];
            }
        }

        return flyBallTypes[0];
    }
}

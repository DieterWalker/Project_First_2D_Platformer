using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomFlyBall : MonoBehaviour
{
    [SerializeField] private ExpDropData expDropData;

    public string GetRandomFlyBallType(){
        int total = 0;
        foreach (int rate in expDropData.FlyBallRates){
            total += rate;
        }

        int randomValue = Random.Range(0, total);
        int cumulativeRate = 0;

        for (int i = 0; i < expDropData.FlyBallTypes.Count; i++)
        {
            cumulativeRate += expDropData.FlyBallRates[i];
            if (randomValue < cumulativeRate)
            {
                return expDropData.FlyBallTypes[i];
            }
        }

        return expDropData.FlyBallTypes[0];
    }
}

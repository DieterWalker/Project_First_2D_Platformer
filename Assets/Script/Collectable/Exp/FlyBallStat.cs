using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlyBallVStat", menuName = "Collectable/Fly Ball", order = 0)]
public class FlyBallStat : ScriptableObject
{
    [SerializeField] public int healValue;
    [SerializeField] public int expValue;
}

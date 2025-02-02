using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpDropRate", menuName = "DropRate/Fly Ball", order = 0)]
public class ExpDropData : ScriptableObject{
    [SerializeField, ReadOnly] private List<string> flyBallTypes = new List<string> { "White_Ball", "Blue_Ball", "Purple_Ball", "Red_Ball", "Green_Ball" }; 
    [SerializeField] private List<int> flyBallRates = new List<int> {1000,100,10,1,10};

    #region Properties
        public List<string> FlyBallTypes
        {
            get => flyBallTypes;
            // set => flyBallTypes = value;
        }

        public List<int> FlyBallRates
        {
            get => flyBallRates;
            set => flyBallRates = value;
        }
    #endregion
}

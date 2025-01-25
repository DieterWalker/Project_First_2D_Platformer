using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_PlayerStat : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower = 25f;
    #region Unity Method
    #endregion
    
    #region Properties
        public float MoveSpeed{
            get{return moveSpeed;} 
        } 

        public float JumpPower{
            get{return jumpPower;}
        }
    #endregion
}

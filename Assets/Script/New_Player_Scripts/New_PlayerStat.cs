using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_PlayerStat : MonoBehaviour
{
    [SerializeField] private int hp = 1000;
    [SerializeField] private int atk = 50;
    // [SerializeField] private int level = 0;
    [SerializeField] private int exp = 0;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower = 25f;
    [SerializeField] private int jumpCount = 2;
    #region Unity Method
    #endregion
    
    #region Properties
        public int Hp{
            get{return hp;} 
        }

        public float Atk{
            get{return atk;} 
        } 

        public float Exp{
            get{return exp;} 
        } 

        public float MoveSpeed{
            get{return moveSpeed;} 
        } 

        public float JumpPower{
            get{return jumpPower;}
        }

        public int JumpCount {
            get{return jumpCount;}
        }
    #endregion
}

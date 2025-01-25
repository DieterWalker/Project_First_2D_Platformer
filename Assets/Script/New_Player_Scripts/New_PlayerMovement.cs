using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_PlayerMovement : MonoBehaviour
{
    [SerializeField, ReadOnly] private Rigidbody2D rigidbody2D;
    

    #region Unity Method
        private void Awake(){
            rigidbody2D = GetComponent<Rigidbody2D>();        
        }
    #endregion

    #region Movement Method
        public void FlipPlayer(float horizontalInput){
            if (horizontalInput > 0.01f){
                transform.localScale = Vector3.one;
            } else if (horizontalInput < -0.01f){
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        public void MovePlayer(float horizontalInput /*, float moveSpeed*/){
            rigidbody2D.velocity = new Vector2(horizontalInput * 10, rigidbody2D.velocity.y);
        }
    #endregion
}

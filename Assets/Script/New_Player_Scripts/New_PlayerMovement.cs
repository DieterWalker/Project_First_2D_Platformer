using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    // #region Unity Method
    //     private void Awake(){
    //         // rb = GetComponent<Rigidbody2D>();  
    //         capsuleCollider = GetComponent<CapsuleCollider2D>();
    //     }
    // #endregion

    #region Movement Method
        public void FlipPlayer(float horizontalInput){
            if (horizontalInput > 0.01f){
                transform.localScale = Vector3.one;
            } else if (horizontalInput < -0.01f){
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        public void MovePlayer(Rigidbody2D rb, float horizontalInput , float moveSpeed){
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
    #endregion

    #region Jump Method
        public void JumpPlayer(Rigidbody2D rb, float jumpPower){
            
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    #endregion

    #region CheckLayer
        public bool IsGrounded(CapsuleCollider2D capsuleCollider){
            RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
            return raycastHit.collider != null;
        }

        public bool OnWall(CapsuleCollider2D capsuleCollider){
            RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.2f, wallLayer);
            return raycastHit.collider != null;
        }
    #endregion
}

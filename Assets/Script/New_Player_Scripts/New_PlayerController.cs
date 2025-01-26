using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_PlayerController : MonoBehaviour{
    [SerializeField, ReadOnly] public float horizontalInput;
    [SerializeField, ReadOnly] private New_PlayerAnimation playerAnimation;
    [SerializeField, ReadOnly] private New_PlayerMovement playerMovement;
    [SerializeField, ReadOnly] private New_PlayerStat playerStat;
    [SerializeField, ReadOnly] private New_PlayerTrigger playerTrigger;
    [SerializeField, ReadOnly] private Rigidbody2D rb;
    [SerializeField, ReadOnly] private CapsuleCollider2D capsuleCollider;      

    #region Unity Method
        private void Awake(){
            playerAnimation = GetComponent<New_PlayerAnimation>();
            playerMovement = GetComponent<New_PlayerMovement>();
            playerStat = GetComponent<New_PlayerStat>(); 
            playerTrigger = GetComponent<New_PlayerTrigger>();

            playerMovement.Initialize(playerStat.JumpCount);

            rb = GetComponent<Rigidbody2D>();
            capsuleCollider = GetComponent<CapsuleCollider2D>();
            
        }

        private void Update(){
            playerMovement.CheckJumpCount(playerStat.JumpCount, capsuleCollider);
            horizontalInput = Input.GetAxis("Horizontal");

            playerMovement.FlipPlayer(horizontalInput);
            playerMovement.MovePlayer(rb, horizontalInput, playerStat.MoveSpeed);

            if (playerMovement.OnWall(capsuleCollider) && !playerMovement.IsGrounded(capsuleCollider) && horizontalInput != 0)
                // if (!isGrounded() && onWall() && horizontalInput != 0)
                rb.velocity = new Vector2(0, rb.velocity.y); // Ngăn di chuyển ngang
                // else
            
            if(Input.GetKeyDown(KeyCode.W)){
                playerMovement.JumpPlayer(rb, playerStat.JumpPower);
            }

            playerAnimation.CheckAnimation(rb, horizontalInput, playerMovement.IsGrounded(capsuleCollider));
        }
    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PlayerController : MonoBehaviour{
    
    // [SerializeField, ReadOnly] private int setUpJumpCount = 2;
    [SerializeField, ReadOnly] private float moveSpeed;
    [SerializeField, ReadOnly] public int hp;
    [SerializeField, ReadOnly] public int currentHp;
    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private float setUpGravity = 10f; 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    // [SerializeField] private HealthBar healthBar;
    [SerializeField, ReadOnly] private int jumpCount; 
    [SerializeField, ReadOnly] private float wallJumpCoolDown;
    [SerializeField, ReadOnly] public float horizontalInput;
    [SerializeField, ReadOnly] private Rigidbody2D rb;
    [SerializeField, ReadOnly] private CapsuleCollider2D capsuleCollider;
    [SerializeField, ReadOnly] private PlayerStat playerStat;
    [SerializeField, ReadOnly] private SpineController spineController;
    [SerializeField, ReadOnly] private HealthBar healthBar;
    

    #region Unity Method

        private void Awake(){
            rb = GetComponent<Rigidbody2D>();
            capsuleCollider = GetComponent<CapsuleCollider2D>();
            spineController = GetComponent<SpineController>();
            playerStat = GetComponent<PlayerStat>();
            
            jumpCount = playerStat.getJump();
            moveSpeed = playerStat.getSpeed();
            hp = playerStat.getHP();
            currentHp = hp / 2;

            GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
            healthBar = healthBarObject.GetComponent<HealthBar>();
        }

        private void Start(){
            rb.gravityScale = setUpGravity;
        }

        private void Update(){
            CheckJumpCount();

            horizontalInput = Input.GetAxis("Horizontal");

            Flip();
            if (wallJumpCoolDown < 0.2f ) {
                // if (!isGrounded() && onWall() && horizontalInput != 0)
                //     rb.velocity = new Vector2(0, rb.velocity.y); // Ngăn di chuyển ngang
                // else
                    rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y); // Di chuyển bình thường
            
                if (onWall() && !isGrounded()){
                        //rb.gravityScale = 0;
                        //rb.velocity = Vector2.zero;
                        rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(-10f, rb.velocity.y)); // Giảm tốc độ rơi nhẹ
                    } else
                        rb.gravityScale = setUpGravity;

                    if(Input.GetKeyDown(KeyCode.Space) && jumpCount > 0){
                        Jump();
                        wallJumpCoolDown = 0;
                    }
            } else {
                wallJumpCoolDown += Time.deltaTime;
            }

            
            // print(jumpCount);
            CheckAnimation();
        }
    #endregion

    #region Movement Logic
        private void Flip(){
            if (horizontalInput > 0.01f) 
                transform.localScale = Vector3.one;
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3 (-1, 1, 1);
        }

        private void Jump(){
            if (isGrounded() || jumpCount > 0){
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpCount--;
            } else if(onWall() && !isGrounded()){
                if (horizontalInput == 0){
                    rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 25, 0);
                    transform.localScale = new Vector3(-MathF.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                } else {
                    rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 25);
                }
                wallJumpCoolDown = 0;
            }     
        }     

        private void CheckJumpCount(){
            if (isGrounded()|| onWall()){
                jumpCount = playerStat.getJump();
            } 
        }

        private bool isGrounded(){
            RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
            return raycastHit.collider != null;
        }

        private bool onWall(){
            RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.2f, wallLayer);
            return raycastHit.collider != null;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("LimitZone"))
            {
                Debug.Log("Player đã chạm vào LimitZone!");
                transform.position = Vector3.zero;
                healthBar.TestHealth(-currentHp);
                currentHp = 0;
            }
        }

    #endregion


    #region Play Animation
        private void CheckAnimation(){
            if (isGrounded()) {
                if (Mathf.Abs(horizontalInput) > 0.01f) {
                    spineController.PlayAnimation(0, "Run", true); // Đang chạy
                } else {
                    spineController.PlayAnimation(0, "Idle", true); // Đứng yên
                }
            } else if (rb.velocity.y > 0.1f) {
                spineController.PlayAnimation(0, "Jump", false); // Đang nhảy lên
            } else if (rb.velocity.y < -0.1f) {
                spineController.PlayAnimation(0, "Fall", false);
            } else if (onWall()){
                spineController.PlayAnimation(0, "Climb", false);
            }
        }
    #endregion

}

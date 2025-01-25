using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_PlayerAnimation : MonoBehaviour
{
    [SerializeField, ReadOnly] private SpineController spineController;

    #region Unity Method
        private void Awake(){
            spineController = GetComponent<SpineController>();
        }
    #endregion

    #region Animation Control
        public void CheckAnimation(Rigidbody2D rb, float horizontalInput, bool isGrounded){
            if (isGrounded) {
                if (Mathf.Abs(horizontalInput) > 0.01f) {
                    spineController.PlayAnimation(0, "Run", true); // Đang chạy
                } else {
                    spineController.PlayAnimation(0, "Idle", true); // Đứng yên
                }
            } if (rb.velocity.y > 0.1f) {
                spineController.PlayAnimation(0, "Jump", false); // Đang nhảy lên
            } else if (rb.velocity.y < -0.1f) {
                spineController.PlayAnimation(0, "Fall", false);
            }
        }
    #endregion
   
}

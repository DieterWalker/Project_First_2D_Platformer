using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField, ReadOnly] private PlayerController playerController;
    #region Unity Method
        public void Initialize(){
            playerController = GetComponent<PlayerController>();
        }
    #endregion

    #region OnTrigger Method
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("LimitZone"))
            {
                Debug.Log("Player đã chạm vào LimitZone!");
                transform.position = Vector3.zero;
                playerController.TakeDamage(playerController.playerStat.Hp);
            }
        }
    #endregion
}

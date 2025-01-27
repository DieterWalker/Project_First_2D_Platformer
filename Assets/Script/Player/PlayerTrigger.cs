using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    #region Unity Method

    #endregion

    #region OnTrigger Method
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("LimitZone"))
            {
                Debug.Log("Player đã chạm vào LimitZone!");
                transform.position = Vector3.zero;
                
            }
        }
    #endregion
}

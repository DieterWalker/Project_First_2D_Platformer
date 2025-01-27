using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBallMovement : MonoBehaviour
{
    // [SerializeField] private float randomMovingTime = 3f;
    [SerializeField, ReadOnly] public float time = 0f;
    [SerializeField, ReadOnly] private float speed = 5f;
    [SerializeField, ReadOnly] private Vector3 randomDirection;
    [SerializeField, ReadOnly] private Vector3 targetPosition;
    [SerializeField, ReadOnly] private FlyBallController flyBallController;
    
    #region Unity Method
        public void Awake(){
            flyBallController = GetComponent<FlyBallController>();
        }

        public void Initialize(TrailRenderer trailRenderer){
            gameObject.SetActive(true);
            time = 0f;
            speed = 5f;
            randomDirection = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0).normalized;
            targetPosition = transform.position + randomDirection;
            trailRenderer.Clear();
        }
    #endregion

    // #region Property
    //     public float Time{
    //         get{return time;}
    //         set{time = value;}
    //     }
    // #endregion

    #region Moving
        public void MoveRandom(){
            Move(targetPosition);
            time += Time.deltaTime;
        }

        public void MoveToPlayer(GameObject player){
            targetPosition = player.transform.position + new Vector3(0, 1.5f, 0);
            speed += 0.05f;
            Move(targetPosition);
            flyBallController.CheckDistancePlayer(targetPosition);
        }

        private void Move(Vector3 targetPosition){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

    #endregion

}

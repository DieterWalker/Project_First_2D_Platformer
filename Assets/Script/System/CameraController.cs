using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public float FollowSpeed = 2f;
    [SerializeField] private float yOffset = 1f;
    [SerializeField] private Transform target;

    #region Unity Method
        private void FixedUpdate(){
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    #endregion
}

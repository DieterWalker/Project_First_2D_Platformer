using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float setUpLifetime;
    [SerializeField, ReadOnly] private float lifetime;
    [SerializeField, ReadOnly] private float direction;
    private bool hit; 

    [SerializeField, ReadOnly] private CircleCollider2D circleCollider;

    #region Unity Method
        private void Awake(){
            circleCollider = GetComponent<CircleCollider2D>();
        }

        private void Start(){
            lifetime = setUpLifetime;
        }

        private void Update(){
            if (hit){
                return;
            }

            float movementSpeed = speed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0);
            
            lifetime -= Time.deltaTime;
            if (lifetime <= 0 )
                gameObject.SetActive(false);
        }
    #endregion

    #region 
        private void OnTriggerEnter2D(Collider2D collision){
            hit = true;
            circleCollider.enabled = false;
            Deactivate();
        }

        public void SetDirection(float _direction){
            lifetime = setUpLifetime;
            direction = _direction;
            gameObject.SetActive(true);
            hit = false;
            circleCollider.enabled = true;

            float localScaleX = transform.localScale.x;
            if (Mathf.Sign(localScaleX) != direction){
                localScaleX = -localScaleX;
            }

            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }

        private void Deactivate(){
            gameObject.SetActive(false);
        }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    
    [SerializeField] private int expGain = 3;
    [SerializeField, ReadOnly] private bool hasTriggered;
    [SerializeField, ReadOnly] private GetRandomFlyBall getRandomFlyBall;

    #region Unity Method
        private void Awake(){
            getRandomFlyBall = GetComponent<GetRandomFlyBall>();
        }

        private void Update(){
            transform.Rotate(new Vector3(0, 0, -25f) * Time.deltaTime);
        }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            for (int i = 0; i < expGain; i++)
            {
                // Random một loại FlyBall dựa trên trọng số
                string randomType = getRandomFlyBall.GetRandomFlyBallType();
                GameObject experience_Ball = Experience_Object_Pool.instance.GetPooledObject(randomType);

                if (experience_Ball != null)
                {
                    experience_Ball.transform.position = transform.position;
                    experience_Ball.SetActive(true);

                    FlyBallController experience_Ball_Script = experience_Ball.GetComponent<FlyBallController>();
                    experience_Ball_Script.Initialize();
                }
            }

            Destroy(gameObject);
        }
    }
}

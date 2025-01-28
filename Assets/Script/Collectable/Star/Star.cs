// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Star : MonoBehaviour{
//     [SerializeField] private int expGain = 3;
//     [SerializeField, ReadOnly] private bool hasTriggered;

//     private void Update(){
//         transform.Rotate(new Vector3(0, 0, -25f) * Time.deltaTime);
//     }

//     private void OnTriggerEnter2D(Collider2D collision){
//         if (collision.CompareTag("Player") &&  !hasTriggered){
//             hasTriggered = true;
            
//             for (int i = 0; i < expGain; i++ ){
//                 // Call Object Pool in here
//                 GameObject experience_Ball = Experience_Object_Pool.instance.GetPooledObject();
//                 experience_Ball.transform.position = transform.position;
//                 FlyBallController experience_Ball_Script = experience_Ball.GetComponent<FlyBallController>();
//                 experience_Ball_Script.Initialize();
//             }
//             Destroy(gameObject);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private int expGain = 3;
    [SerializeField] private List<string> flyBallTypes; // Danh sách các loại FlyBall (White, Blue, Purple)
    [SerializeField] private List<int> flyBallWeights; // Tỷ lệ trọng số tương ứng (99, 10, 1)
    [SerializeField, ReadOnly] private bool hasTriggered;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -25f) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            for (int i = 0; i < expGain; i++)
            {
                // Random một loại FlyBall dựa trên trọng số
                string randomType = GetRandomFlyBallType();
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

    private string GetRandomFlyBallType()
    {
        // Tính tổng trọng số
        int totalWeight = 0;
        foreach (int weight in flyBallWeights)
        {
            totalWeight += weight;
        }

        // Random một số trong khoảng từ 0 đến totalWeight
        int randomValue = Random.Range(0, totalWeight);
        int cumulativeWeight = 0;

        // Tìm loại FlyBall tương ứng
        for (int i = 0; i < flyBallTypes.Count; i++)
        {
            cumulativeWeight += flyBallWeights[i];
            if (randomValue < cumulativeWeight)
            {
                return flyBallTypes[i];
            }
        }

        // Trường hợp không tìm thấy (không nên xảy ra nếu dữ liệu hợp lệ)
        return flyBallTypes[0];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour{
    [SerializeField] private int expGain = 3;
    [SerializeField, ReadOnly] private bool hasTriggered;

    private void Update(){
        transform.Rotate(new Vector3(0, 0, -25f) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player") &&  !hasTriggered){
            hasTriggered = true;
            
            for (int i = 0; i < expGain; i++ ){
                // Call Object Pool in here
                GameObject experience_Ball = Experience_Object_Pool.instance.GetPooledObject();
                experience_Ball.transform.position = transform.position;
                Experience_Ball experience_Ball_Script = experience_Ball.GetComponent<Experience_Ball>();
                experience_Ball_Script.Initialize(collision.transform);
            }


            Destroy(gameObject);
        }
    }
}

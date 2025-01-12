using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience_Object_Pool : MonoBehaviour
{
    public static Experience_Object_Pool instance;

    [SerializeField] private GameObject circleExpPrefab;
    [SerializeField] private Transform expPoolParent; 
    // Số Object khởi đầu
    [SerializeField] private int initialPoolSize = 5;

    [SerializeField, ReadOnly] private List<GameObject> pool = new List<GameObject>();

    #region Unity Method 
        private void Awake(){
            instance = this; 
        }
        // Start is called before the first frame update
        private void Start()
        {
             for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = Instantiate(circleExpPrefab);
                obj.SetActive(false);
                obj.transform.SetParent(expPoolParent);
                pool.Add(obj);
            }
        }
    #endregion

    #region ObjectPool Action
        public GameObject GetPooledObject(){
            foreach (GameObject obj in pool){
                if (!obj.activeInHierarchy)
                    return obj;
            }
            // Nếu không có tạo Object mới
            return CreateObject();
        }
        
        private GameObject CreateObject(){
            GameObject newObject = Instantiate(circleExpPrefab);
            newObject.SetActive(true);
            newObject.transform.SetParent(expPoolParent);
            pool.Add(newObject);
            return newObject;
        }

    #endregion

}

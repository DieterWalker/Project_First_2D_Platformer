// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Experience_Object_Pool : MonoBehaviour
// {
//     public static Experience_Object_Pool instance;

//     // [SerializeField] private GameObject circleExpPrefab;
//     [SerializeField] private Transform expPoolParent; 
//     // Số Object khởi đầu
//     [SerializeField] private int initialPoolSize = 5;

//     [SerializeField, ReadOnly] private List<GameObject> pool = new List<GameObject>();

//     #region Unity Method 
//         private void Awake(){
//             instance = this; 
//         }
//         // Start is called before the first frame update
//         private void Start()
//         {
//              for (int i = 0; i < initialPoolSize; i++)
//             {
//                 GameObject obj = Instantiate(circleExpPrefab);
//                 obj.SetActive(false);
//                 obj.transform.SetParent(expPoolParent);
//                 pool.Add(obj);
//             }
//         }
//     #endregion

//     #region ObjectPool Action
//         public GameObject GetPooledObject(){
//             foreach (GameObject obj in pool){
//                 if (!obj.activeInHierarchy)
//                     return obj;
//             }
//             // Nếu không có tạo Object mới
//             return CreateObject();
//         }
        
//         private GameObject CreateObject(){
//             GameObject newObject = Instantiate(circleExpPrefab);
//             newObject.SetActive(true);
//             newObject.transform.SetParent(expPoolParent);
//             pool.Add(newObject);
//             return newObject;
//         }

//     #endregion

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience_Object_Pool : MonoBehaviour
{
    public static Experience_Object_Pool instance;

    [SerializeField] private List<GameObject> prefabs; // Danh sách các prefab khác nhau
    [SerializeField] private Transform expPoolParent;
    [SerializeField] private int initialPoolSize = 5;

    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (GameObject prefab in prefabs)
        {
            string key = prefab.name;
            if (!pools.ContainsKey(key))
            {
                pools[key] = new List<GameObject>();
                for (int i = 0; i < initialPoolSize; i++)
                {
                    GameObject obj = Instantiate(prefab);
                    obj.SetActive(false);
                    obj.transform.SetParent(expPoolParent);
                    pools[key].Add(obj);
                }
            }
        }
    }

    public GameObject GetPooledObject(string prefabName)
    {
        if (pools.ContainsKey(prefabName))
        {
            foreach (GameObject obj in pools[prefabName])
            {
                if (!obj.activeInHierarchy)
                    return obj;
            }

            // Nếu không có object nào sẵn sàng, tạo mới
            return CreateObject(prefabName);
        }

        Debug.LogWarning($"Prefab '{prefabName}' không được đăng ký trong Object Pool!");
        return null;
    }

    private GameObject CreateObject(string prefabName)
    {
        GameObject prefab = prefabs.Find(p => p.name == prefabName);
        if (prefab == null)
        {
            Debug.LogError($"Prefab '{prefabName}' không tồn tại!");
            return null;
        }

        GameObject newObject = Instantiate(prefab);
        newObject.SetActive(false);
        newObject.transform.SetParent(expPoolParent);
        pools[prefabName].Add(newObject);
        return newObject;
    }
}


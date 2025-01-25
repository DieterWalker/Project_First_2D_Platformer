using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_PlayerAnimation : MonoBehaviour
{
    [SerializeField, ReadOnly] private SpineController spineController;

    #region Unity Method
        private void Awake(){
            spineController = GetComponent<SpineController>();
        }
    #endregion
   
}

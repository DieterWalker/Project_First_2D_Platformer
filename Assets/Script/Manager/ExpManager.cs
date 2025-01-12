using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    [SerializeField, ReadOnly] public static ExpManager instance;
    [SerializeField] private int star;
    [SerializeField] private Text starDisplay;

    private void Awake(){
        if (instance == null){
            instance = this;
        }
    }

    private void OnGUI(){
        starDisplay.text = star.ToString();
    }

    public void ChangeExp(int amount){
        star += amount;
    }
}

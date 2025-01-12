using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    [SerializeField, ReadOnly] public static StarManager instance;
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

    public void ChangeCoins(int amount){
        star += amount;
    }
}

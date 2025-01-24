using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider backHealthBar;
    [SerializeField] private float speed = 1f;
    [SerializeField] private PlayerController playerController;
    [SerializeField, ReadOnly] private int currentHealth = 1000;

    [SerializeField, ReadOnly] private Coroutine backBarCoroutine;
    
    [SerializeField, ReadOnly] private Coroutine healthBarCoroutine;
    


    #region Unity Method
        private void Awake(){
            currentHealth = playerController.currentHp;
            // slider = GetComponent<Slider>();
            SetMaxHealth(healthBar ,playerController.hp);
            SetMaxHealth(backHealthBar, playerController.hp);
            SetHealth(healthBar ,playerController.currentHp);
            SetHealth(backHealthBar, playerController.currentHp);
        }

    #endregion

    #region HealthBar Manager
        public void SetMaxHealth(Slider slider,int health){
            slider.maxValue = health;
            slider.value = health;
        }

        public void SetHealth(Slider slider, int health){
            slider.value = health;
        }
    #endregion

    public void TestHealth(int healthChange){
        currentHealth = Mathf.Clamp(currentHealth + healthChange, 0, 1000);
        
        if (healthBarCoroutine != null){
            StopCoroutine(healthBarCoroutine);
        }

        if (backBarCoroutine != null){
            StopCoroutine(backBarCoroutine);
        }

        CheckHealthValue(healthChange);
    }

    private void CheckHealthValue(int healthChange){        
        if (healthChange > 0){
            healthBarCoroutine = StartCoroutine(AnimateHealthBar(healthBar, currentHealth));
            SetHealth(backHealthBar, currentHealth);
        } else {
            backBarCoroutine = StartCoroutine(AnimateHealthBar(backHealthBar, currentHealth));
            SetHealth(healthBar, currentHealth);
        }
    }

    private IEnumerator AnimateHealthBar(Slider healthBar, int health){
        while (Mathf.Abs(healthBar.value - health) > 0.01f){
            healthBar.value = Mathf.MoveTowards(healthBar.value, health, speed * Time.deltaTime * 100);
            yield return null;
        }
        healthBar.value = health;
    }
} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider backHealthBar;
    [SerializeField] private float speed = 1f;
    // [SerializeField, ReadOnly] private int currentHealth = 1000;

    [SerializeField, ReadOnly] private Coroutine backBarCoroutine;
    
    [SerializeField, ReadOnly] private Coroutine healthBarCoroutine;



    #region Unity Method
        public void Initialize(int health){
            SetMaxHealth(healthBar , health);
            SetMaxHealth(backHealthBar, health);
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

    public void ChangeHealth(int currentHealth, int healthChange){        
        if (healthBarCoroutine != null){
            StopCoroutine(healthBarCoroutine);
        }

        if (backBarCoroutine != null){
            StopCoroutine(backBarCoroutine);
        }

        CheckHealthValue(currentHealth, healthChange);
    }

    private void CheckHealthValue(int currentHealth, int healthChange){        
        if (healthChange > 0){
            healthBarCoroutine = StartCoroutine(AnimateHealthBar(healthBar, currentHealth));
            SetHealth(backHealthBar, currentHealth);
        } else {
            SetHealth(healthBar, currentHealth);
            backBarCoroutine = StartCoroutine(AnimateHealthBar(backHealthBar, currentHealth));
        }
    }

    private IEnumerator AnimateHealthBar(Slider healthBar, int health){
        float tempSpeed = speed;
        while (Mathf.Abs(healthBar.value - health) > 0.01f){
            healthBar.value = Mathf.MoveTowards(healthBar.value, health, tempSpeed * Time.deltaTime * 100);
            yield return null;
            tempSpeed += 0.025f;
        }
        healthBar.value = health;
    }
} 

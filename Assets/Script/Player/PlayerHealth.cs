using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField, ReadOnly] private int currentHp;
    [SerializeField, ReadOnly] private PlayerHealthBar playerHealthBar;

    #region Unity Method
        public void Initialize(int hp){
            GameObject healthBar = GameObject.FindGameObjectWithTag("HealthBar");
            playerHealthBar = healthBar.GetComponent<PlayerHealthBar>(); 

            playerHealthBar.Initialize(hp);

            currentHp = hp;
        }
    #endregion

    #region Health Function
        public void TakeDamage(int hp, int damage){
            currentHp = Mathf.Clamp(currentHp - damage, 0, hp);
            Debug.Log("Take" + damage + "damage. You HP is: " + currentHp);
            playerHealthBar.ChangeHealth(currentHp, -damage);
            
        }   

        public void Heal(int hp, int heal){
            currentHp = Mathf.Clamp(currentHp + heal, 0, hp);
            Debug.Log("heal" + heal + "damage. You HP is: " + currentHp);
            playerHealthBar.ChangeHealth(currentHp, heal);
            
        }
    #endregion
}

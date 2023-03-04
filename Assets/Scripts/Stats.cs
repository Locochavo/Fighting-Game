using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stats : MonoBehaviour
{
    public int damage = 5;
    public int maxhealth = 100;
    public int currentHealth;
    public Image healthBar;


    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.fillAmount= damage;   

        if (currentHealth < 1)
        {
            Debug.Log("Enemy is dead");
        }
    }
}

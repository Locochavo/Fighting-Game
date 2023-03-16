using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stats : MonoBehaviour
{
    public int damage = 5;
    public int maxhealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    public int TakeDamage()
    {
        currentHealth -= damage;

        if (currentHealth < 1)
        {
            GameManager.INSTANCE.WinPanel();
            Debug.Log("Enemy is dead");
        }

        return currentHealth;
    }
}

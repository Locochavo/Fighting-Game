using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        if (currentHealth < 1)
        {
            Debug.Log("Enemy is dead");
        }
    }
}

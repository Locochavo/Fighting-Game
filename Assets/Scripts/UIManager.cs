using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private HealhBar healthbarPlayer1;
    [SerializeField] private HealhBar healthbarPlayer2;



    public enum CharacterType { Player1, Player2 }


    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void TakeDamage(CharacterType characterType, Stats stats)
    {
        if (characterType == CharacterType.Player1) {

            healthbarPlayer1.UpdateHealthBar(stats.TakeDamage(), stats.maxhealth);
        }
        if (characterType == CharacterType.Player2) {

            healthbarPlayer2.UpdateHealthBar(stats.TakeDamage(), stats.maxhealth);
        }
    }

}

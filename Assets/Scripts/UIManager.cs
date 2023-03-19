using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private HealhBar healthbarPlayer1;
    [SerializeField] private HealhBar healthbarPlayer2;
  



    public enum CharacterType { Player1, Player2 }

    public void TakeDamage(CharacterType characterType, Stats stats)
    {
        if (characterType == CharacterType.Player1) {

            healthbarPlayer1.UpdateHealthBar(stats.TakeDamage(), stats.maxhealth);

        }
        if (characterType == CharacterType.Player2) {

            healthbarPlayer2.UpdateHealthBar(stats.TakeDamage(), stats.maxhealth);
           
        }
    }

    public void ResetHealthbars()
    {
        healthbarPlayer1.ResetHealthBar();
        healthbarPlayer2.ResetHealthBar();
    }
}



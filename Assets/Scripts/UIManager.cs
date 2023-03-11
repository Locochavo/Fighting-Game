using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //public Character[] characters;

    //public Character currrentCharacter;

    [SerializeField] private HealhBar healthbarPlayer1;
    [SerializeField] private HealhBar healthbarPlayer2;
    public SpriteRenderer sr;
    public List<Sprite> characters= new List<Sprite>();
    public int selectedcharacter = 0;
    public GameObject playercharacter;




    public enum CharacterType { Player1, Player2 }

    public void NextOption()
    {
        selectedcharacter = selectedcharacter + 1;
        if( selectedcharacter == characters.Count )
        {
            selectedcharacter = 0;
        }
        sr.sprite = characters[selectedcharacter];
    }

    public void BackOpttion()
    {
        selectedcharacter = selectedcharacter- 1;
        if(selectedcharacter < 0)
        {
            selectedcharacter = characters.Count - 1;
        }
        sr.sprite = characters[selectedcharacter];
    }

    public void PlayGame()
    {
    //    PrefabUtility.SaveAsPrefabAsset(playercharacter, "Assets/Option.prefab");
     //   SceneManager.LoadScene("");
    }




    //private void Awake()
    //{
    //    if (Instance == null) {
    //        Instance = this;
    //    }
    //    else if (Instance != this) {
    //        Destroy(gameObject);
    //    }
    //    DontDestroyOnLoad(gameObject);
    //}

    //private void Start()
    //{
    //    if (characters.Length > 0 && currrentCharacter == null)
    //    {
    //        currrentCharacter = characters[0];
    //    }
    //}

    //public void SetCharacter(Character character)
    //{
    //    currrentCharacter= character;
    //}

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

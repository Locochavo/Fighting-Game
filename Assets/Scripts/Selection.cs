using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;


public class Selection : MonoBehaviour
{
    //public GameObject optionPrefab;
    //public Transform prevCharacter;
    //public Transform selectedCharacter;
    [SerializeField] private Character[] characters;
    [SerializeField] private Transform spawnPlayer1;
    [SerializeField] private Transform spawnPlayer2;

    public GameObject selectedcharacter;
    public GameObject Player;
    private Sprite playersprite;


    private Character player1;
    private Character player2;
 


    private void Start()
    {
            playersprite = selectedcharacter.GetComponent<SpriteRenderer>().sprite; 
    }

    public void SelectRandomPlayer()
    {
        int randomIndex = Random.Range(0, characters.Length);
        player2= characters[randomIndex];
    }

    public void SelectPlayer1(Character SelectPlayer1)
    {
        player1 = SelectPlayer1;
    }

    public void SelectPlayer2(Character SelectPlayer2)
    {
        player2 = SelectPlayer2;
    }

 
    public void SpawnPlayers()
    {
        Instantiate(player1.prefab, spawnPlayer1);
        Instantiate(player2.prefab, spawnPlayer2);
        gameObject.SetActive(false);
    }





    //private void Start()
    //{
    //    foreach (Character c in UIManager.Instance.characters)
    //    {
    //        GameObject option = Instantiate(optionPrefab, transform);
    //        Button button = option.GetComponent<Button>();


        //        button.onClick.AddListener(() =>
        //        {
        //            UIManager.Instance.SetCharacter(c);



        //            if (selectedCharacter != null)
        //            {
        //                prevCharacter = selectedCharacter;
        //            }

        //            selectedCharacter = option.transform;

        //        });


}



using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Selection : MonoBehaviour
{
    [SerializeField] private Character[] characters;
    [SerializeField] private Transform spawnPlayer1;
    [SerializeField] private Transform spawnPlayer2;



    private Character player1;
    private Character player2;



    private void Start()
    {
        SelectRandomPlayer();
    }

    public void SelectRandomPlayer()
    {
        int randomIndex = Random.Range(0, characters.Length);
        player2 = characters[randomIndex];
    }

    public void SelectPlayer1(Character SelectPlayer1)
    {
        foreach (Character character in characters) {
            character.backGroundImage.enabled = false;
        }

        SelectPlayer1.backGroundImage.enabled = true;
        player1 = SelectPlayer1;
    }

    public void SelectPlayer2(Character SelectPlayer2)
    {
        player2 = SelectPlayer2;
    }


    public void SpawnPlayers()
    {
        if (player1 == null) return;

        var p1 = Instantiate(player1.prefab);
        p1.transform.position = spawnPlayer1.transform.position;
        var p2 = Instantiate(player1.prefab);
        p2.transform.position = spawnPlayer2.transform.position;
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



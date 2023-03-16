using System.Collections.Generic;
using UnityEngine;



public class Selection : MonoBehaviour
{
    [SerializeField] private Character[] characters;
    [SerializeField] private Transform spawnPlayer1;
    [SerializeField] private Transform spawnPlayer2;

    private Character player1;
    private Character player2;

    private List<GameObject> currentPlayers = new();

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

        var p1 = Instantiate(player1.prefabPlayer);
        p1.transform.position = spawnPlayer1.transform.position;
        var p2 = Instantiate(player2.prefabEnemy);
        p2.transform.position = spawnPlayer2.transform.position;
        gameObject.SetActive(false);
        GameManager.mainMenu.StartGame();
        GameManager.uIManager.ResetHealthbars();

        if (currentPlayers.Count > 0) {


            foreach (var player in currentPlayers) {
                Destroy(player);
            }

            currentPlayers.Clear();
        }



        currentPlayers.Add(p1);
        currentPlayers.Add(p2);


    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int amountOfPlayers; // List.Count?

    public Dictionary<string, Player> allPlayers /*= new Dictionary<string, Player>()*/;


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddPlayers()
    {
        // use amount of players and add that same amount of <Player> to this list.
        allPlayers = new Dictionary<string, Player>();

        for (int i = 0; i < amountOfPlayers; i++)
        {
            print("I have added " + "players");
            Player player = new Player();
            allPlayers.Add(("Player " + i), player);
        }
    }



}

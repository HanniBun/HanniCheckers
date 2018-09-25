using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum state { invalid, empty, blue, purple, green, orange, yellow, red };

    public state[,] States = new state[17, 13]  // Each cell's state on the board. Changes depending on how many players (PlayerPref "PlayerAmount").
{
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.empty, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.empty, state.empty, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.empty, state.empty, state.empty, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.empty, state.empty, state.empty, state.empty, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty },
        {state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty },
        {state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid },
        {state.invalid, state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid },
        {state.invalid, state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid },
        {state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid },
        {state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty },
        {state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.empty, state.empty, state.empty, state.empty, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.empty, state.empty, state.empty, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.empty, state.empty, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.empty, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid }
    };

    public void StateSetup(int amountOfPlayers)
    {
        switch (amountOfPlayers)
        {
            case 2:
                {
                    print(PlayerPrefs.GetInt("PlayerAmount").ToString() + " players");
                    topPlayer(state.red, PlayerPrefs.GetInt("PlayerAmount"));
                    bottomPlayer(state.blue, PlayerPrefs.GetInt("PlayerAmount"));
                    return;
                }
            case 3:
                {
                    print(PlayerPrefs.GetInt("PlayerAmount").ToString() + " players");
                    //topPlayer(state.red); 
                    //bottomRightPlayer(state.purple);
                    //bottomLeftPlayer(state.yellow);

                    print("More than two players isn't supported yet.");
                    return;
                }
            case 4:
                {
                    print(PlayerPrefs.GetInt("PlayerAmount").ToString() + " players");
                    //topPlayer(state.red);
                    //topRightPlayer(state.purple);
                    //bottomPlayer(state.blue);
                    //bottomLeftPlayer(state.green);
                    print("More than two players isn't supported yet.");
                    return;
                }
            case 6:
                {
                    print(PlayerPrefs.GetInt("PlayerAmount").ToString() + " players");
                    print("More than two players isn't supported yet.");
                    return;
                }

            default:
                return;
        }
    }

    void topPlayer(state color, int amountOfPlayers) // I made separate methods for each "home", to clear up the switch statement and make it easier to read.
    {
        States[0, 6] = color;
        States[1, 6] = color;
        States[1, 7] = color;
        States[2, 5] = color;
        States[2, 6] = color;
        States[2, 7] = color;
        States[3, 5] = color;
        States[3, 6] = color;
        States[3, 7] = color;
        States[3, 8] = color;

        if (amountOfPlayers == 2)
        {
            States[4, 4] = color;
            States[4, 5] = color;
            States[4, 6] = color;
            States[4, 7] = color;
            States[4, 8] = color;
        }
        else
            return;
    }

    void bottomPlayer(state color, int amountOfPlayers)
    {
        States[13, 5] = color;
        States[13, 6] = color;
        States[13, 7] = color;
        States[13, 8] = color;
        States[14, 5] = color;
        States[14, 6] = color;
        States[14, 7] = color;
        States[15, 6] = color;
        States[15, 7] = color;
        States[16, 6] = color;

        if (amountOfPlayers == 2)
        {
            States[12, 4] = color;
            States[12, 5] = color;
            States[12, 6] = color;
            States[12, 7] = color;
            States[12, 8] = color;
        }
        else
            return;
    }
}

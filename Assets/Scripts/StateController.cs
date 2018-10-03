using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    /// <summary>
    /// Contains the board's individual states for an empty board. Also has a Switch statement, which changes the states depending on how many
    /// players there are. 
    /// </summary>
 
    public enum State { invalid, empty, blue, red, green, orange, yellow, purple };

    public State[,] States = new State[17, 13]  // Each cell's state on the board. Changes depending on how many players there are.
{
        { State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.empty, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid },
        { State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.empty, State.empty, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid },
        { State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.empty, State.empty, State.empty, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid },
        { State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.empty, State.empty, State.empty, State.empty, State.invalid, State.invalid, State.invalid, State.invalid },
        {State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty },
        {State.invalid, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty },
        {State.invalid, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.invalid },
        {State.invalid, State.invalid, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.invalid },
        {State.invalid, State.invalid, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.invalid, State.invalid },
        {State.invalid, State.invalid, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.invalid },
        {State.invalid, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.invalid },
        {State.invalid, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty },
        {State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty, State.empty },
        {State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.empty, State.empty, State.empty, State.empty, State.invalid, State.invalid, State.invalid, State.invalid },
        {State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.empty, State.empty, State.empty, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid },
        {State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.empty, State.empty, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid },
        {State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.empty, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid, State.invalid }
    };

    public void StateSetup(int amountOfPlayers)
    {
        switch (amountOfPlayers)
        {
            case 2:
                {
                    print(amountOfPlayers.ToString() + " players");
                    bottomPlayer(State.blue, amountOfPlayers);
                    topPlayer(State.red, amountOfPlayers);
                    return;
                }
            case 3:
                {
                    print(amountOfPlayers.ToString() + " players");
                    print("More than two players isn't supported yet.");
                    return;
                }
            case 4:
                {
                    print(amountOfPlayers.ToString() + " players");
                    print("More than two players isn't supported yet.");
                    return;
                }
            case 6:
                {
                    print(amountOfPlayers.ToString() + " players");
                    print("More than two players isn't supported yet.");
                    return;
                }

            default:
                return;
        }
    }


    void topPlayer(State color, int amountOfPlayers)
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
    }

    void bottomPlayer(State color, int amountOfPlayers)
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
    }
}

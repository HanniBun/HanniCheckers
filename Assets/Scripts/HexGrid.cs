using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    GameObject tempCell;

    const int rows = 17, columns = 13;

    public HexCell [,] myGameBoard = new HexCell[rows, columns];

    StateController myStateController;

    public enum state { invalid, empty, blue, purple, green, orange, yellow, red};

    state [,] States = new state[17, 13]  // Each cell's state on the board. Changes depending on how many players (PlayerPref "PlayerAmount").
{
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.blue, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.blue, state.blue, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.blue, state.blue, state.blue, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        { state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.blue, state.blue, state.blue, state.blue, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty },
        {state.invalid, state.purple, state.purple, state.purple, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty },
        {state.invalid, state.purple, state.purple, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid },
        {state.invalid, state.invalid, state.purple, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid },
        {state.invalid, state.invalid, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.orange, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.yellow, state.invalid },
        {state.invalid, state.orange, state.orange, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.yellow, state.yellow, state.invalid },
        {state.invalid, state.orange, state.orange, state.orange, state.empty, state.empty, state.empty, state.empty, state.empty, state.empty, state.yellow, state.yellow, state.yellow },
        {state.orange, state.orange, state.orange, state.orange, state.empty, state.empty, state.empty, state.empty, state.empty, state.yellow, state.yellow, state.yellow, state.yellow },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.red, state.red, state.red, state.red, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.red, state.red, state.red, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.red, state.red, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid },
        {state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.red, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid, state.invalid }
    };

    void Start()
    {
        myStateController = this.GetComponent<StateController>();
        StateSetup(PlayerPrefs.GetInt("PlayerAmount"));

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i % 2 == 0)
                {
                    tempCell = Instantiate(cellPrefab, new Vector3(0.865f + j * 1.73f, 0, i * 1f), transform.rotation);
                }
                else
                {
                    tempCell = Instantiate(cellPrefab, new Vector3(j * 1.73f, 0, i * 1f), transform.rotation);
                }
                tempCell.transform.parent = this.transform; // Makes it not so cluttered in the hierarchy. Yay, structure!

                tempCell.GetComponent<HexCell>().myCellState = myStateController.States[i, j]; // Gets its state from the array.
                tempCell.GetComponent<HexCell>().row = i;
                tempCell.GetComponent<HexCell>().col = j;
 
                myGameBoard[i, j] = tempCell.GetComponent<HexCell>();
            }
        }
    }

    void StateSetup(int AmountOfPlayers)
    {
        //Get playerpref, changes the way States[,] look. 

        switch (PlayerPrefs.GetInt("PlayerAmount")) // TO DO: Change states[,] depending on case.
        {
            case 2:
                {
                    print(PlayerPrefs.GetInt("PlayerAmount").ToString() + " players");
                    return;
                }
            case 3:
                {
                    print(PlayerPrefs.GetInt("PlayerAmount").ToString() + " players");
                    return;
                }
            case 4:
                {
                    print(PlayerPrefs.GetInt("PlayerAmount").ToString() + " players");
                    return;
                }
            case 6:
                {
                    print(PlayerPrefs.GetInt("PlayerAmount").ToString() + " players");
                    return;
                }

            default:
                return;
        }
    }


    }

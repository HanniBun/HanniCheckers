using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveGameController : MonoBehaviour
{
    [SerializeField]
    UIController myUIController;

    HexGrid myHexGrid;
    StateController myStateController;

    private void Start()
    {
        myHexGrid = this.GetComponent<HexGrid>();
        myStateController = this.GetComponent<StateController>();
    }

    public void SaveGame()
    {
        SaveFile mySaveFile = new SaveFile(); // What happens to the old SaveFiles?? 

        for (int i = 0; i < myHexGrid.myGameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < myHexGrid.myGameBoard.GetLength(1); j++)
            {
                if (myHexGrid.myGameBoard[i, j] != null)
                {
                    mySaveFile.savedStates[i, j] = (int)myHexGrid.myGameBoard[i, j].myCellState;
                }

                else // If the index on the gameboard is null...
                {
                    mySaveFile.savedStates[i, j] = (int)StateController.state.invalid; // invalid becomes the same as null when it instantiates.
                }
            }
        }

        BinaryFormatter formatter = new BinaryFormatter();
        Stream stream =
        new FileStream(Application.persistentDataPath + "/SaveFile.dat", FileMode.Create);
        formatter.Serialize(stream, mySaveFile);
        stream.Close();

        print("We have saved!");

    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFile.dat"))
        {
            SaveFile mySaveFile;
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream =
            new FileStream(Application.persistentDataPath + "/SaveFile.dat",
            FileMode.Open);

            mySaveFile = (SaveFile)formatter.Deserialize(stream); // ihavenoideawhatimdoing.jpg

            stream.Close();

            for (int i = 0; i < myHexGrid.myGameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < myHexGrid.myGameBoard.GetLength(1); j++)
                {
                    if (mySaveFile.savedStates[i, j] != 0)
                    {
                        myHexGrid.myGameBoard[i, j].myCellState = (StateController.state)mySaveFile.savedStates[i, j];
                        myHexGrid.myGameBoard[i, j].ColorCheck();
                    }

                    else // If the index on the gameboard is null...
                    {
                        mySaveFile.savedStates[i, j] = (int)StateController.state.invalid; // invalid becomes the same as null when it instantiates.
                    }
                }
            }

            print("We have loaded");

        }

        else // If we have no savefile to load...
        {
            myUIController.LoadError();
        }
    }
}

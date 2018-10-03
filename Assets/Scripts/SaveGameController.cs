using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveGameController : MonoBehaviour
{
    #region Definitions and references
    [SerializeField]
    UIController myUIController;

    [SerializeField]
    PlayerController myPlayerController;

    HexGrid myHexGrid;
    

    private void Start()
    {
        myHexGrid = this.GetComponent<HexGrid>();
        myPlayerController = FindObjectOfType<PlayerController>();
    }
    #endregion

    #region Save method and Load method
    public void SaveGame()
    {
        SaveFile mySaveFile = new SaveFile();

        for (int i = 0; i < myHexGrid.myGameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < myHexGrid.myGameBoard.GetLength(1); j++)
            {
                if (myHexGrid.myGameBoard[i, j] != null)
                {
                    mySaveFile.savedStates[i, j] = (int)myHexGrid.myGameBoard[i, j].MyCellstate;
                }

                else // If the index on the gameboard is null...
                {
                    mySaveFile.savedStates[i, j] = (int)StateController.State.invalid; // invalid becomes the same as null when it instantiates.
                }
            }
        }

        mySaveFile.currentPlayer = myPlayerController.currentPlayer;
        mySaveFile.playerAmount = myPlayerController.playerAmount;

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
                        myHexGrid.myGameBoard[i, j].MyCellstate = (StateController.State)mySaveFile.savedStates[i, j];
                        myHexGrid.myGameBoard[i, j].ColorCheck();
                    }

                    else // If the index on the gameboard is null...
                    {
                        mySaveFile.savedStates[i, j] = (int)StateController.State.invalid; // invalid becomes the same as null when it instantiates.
                    }
                }
            }

            myPlayerController.currentPlayer = mySaveFile.currentPlayer;
            myPlayerController.playerAmount = mySaveFile.playerAmount;

            print("We have loaded");

        }

        else // If we have no savefile to load...
        {
            myUIController.LoadError();
        }
    }
    #endregion
}

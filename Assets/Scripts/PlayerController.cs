using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    Button twoPlayersButton, fourPlayersButton, fivePlayersButton, sixPlayersButton;

    void twoPlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 2);
        //... load set amount on board, change camera to game
    }

    void fourPlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 4);
    }

    void fivePlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 5);
    }

    void sixPlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 6);
    }


}

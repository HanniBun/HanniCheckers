using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //[SerializeField]
    //Button twoPlayersButton, fourPlayersButton, fivePlayersButton, sixPlayersButton;

    SceneController mySceneController;

    private void Start()
    {
        mySceneController = this.GetComponent<SceneController>();

    }

    public void twoPlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 2); // The playerpref PlayerAmount is to be used when loading the board itself: how the states are depends on how many players there are.
        //... load set amount on board, change camera to game
        mySceneController.SceneChange();
    }

    public void threePlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 3);
        mySceneController.SceneChange();
    }

    public void fourPlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 4);
        mySceneController.SceneChange();
    }

    public void sixPlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 6);
        mySceneController.SceneChange();
    }

}

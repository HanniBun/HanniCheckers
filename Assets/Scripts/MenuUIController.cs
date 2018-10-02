using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    [SerializeField]
    SceneController mySceneController;
    [SerializeField]
    PlayerController myPlayerController;

    private void Start()
    {
        mySceneController = this.GetComponent<SceneController>();
    }

    public void twoPlayersClicked()
    {
        myPlayerController.amountOfPlayers = 2;
       // PlayerPrefs.SetInt("PlayerAmount", 2);
        mySceneController.SceneChange();
    }

    public void threePlayersClicked()
    {
        //PlayerPrefs.SetInt("PlayerAmount", 3);
        //mySceneController.SceneChange();
    }

    public void fourPlayersClicked()
    {
        //PlayerPrefs.SetInt("PlayerAmount", 4);
        //mySceneController.SceneChange();
    }

    public void sixPlayersClicked()
    {
        //PlayerPrefs.SetInt("PlayerAmount", 6);
        //mySceneController.SceneChange();
    }
}

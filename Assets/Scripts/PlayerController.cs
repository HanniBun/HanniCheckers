using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    SceneController mySceneController;

    private void Start()
    {
        mySceneController = this.GetComponent<SceneController>();
    }

    public void twoPlayersClicked()
    {
        PlayerPrefs.SetInt("PlayerAmount", 2);
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

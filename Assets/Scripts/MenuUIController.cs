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

    #region Menu buttonclicks

    public void twoPlayersClicked()
    {
        myPlayerController.playerAmount = 2;
        mySceneController.SceneChange();
    }

    public void threePlayersClicked()
    {
    }

    public void fourPlayersClicked()
    {
    }

    public void sixPlayersClicked()
    {
    }
    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    /// <summary>
    /// Controls the UI in game.
    /// </summary>


    #region Definitions and references
    [SerializeField]
    StateController myStateController;
    [SerializeField]
    SaveGameController mySaveGameController;
    [SerializeField]
    HexGrid myHexGrid;

    PlayerController myPlayerController;

    [SerializeField]
    Text saveConfirmedText, loadErrorText, winText;
    [SerializeField]
    GameObject menuCanvas, winWindow, ingameButtons;

    float visibleTime = 2f;
    #endregion

    private void Start()
    {
        // PlayerController is not always present in the hierarchy, hence the use of Find.
        myPlayerController = FindObjectOfType<PlayerController>();

        menuCanvas.SetActive(true);

        saveConfirmedText.enabled = false;
        loadErrorText.enabled = false;
        winWindow.SetActive(false);
        ingameButtons.SetActive(false);
    }

    #region UI OnButton methods
    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void SaveButtonPressed()
    {
        mySaveGameController.SaveGame();
        StartCoroutine(SavedTextVisibleToggle());
    }

    public void LoadButtonPressed()
    {
        mySaveGameController.LoadGame();
    }

    public void twoPlayersClicked()
    {
        myPlayerController.playerAmount = 2;
        StartGame();
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

    #region UI visibility toggles

    public void LoadError()
    {
        StartCoroutine(LoadingErrorTextVisibleToggle());
    }

    public void Win(string victoriousPlayer)
    {
        winWindow.SetActive(true);
        winText.text = string.Format("{0} wins!", victoriousPlayer);
    }

    void StartGame()
    {
        myHexGrid.GameSetUp();

        menuCanvas.SetActive(false);
        ingameButtons.SetActive(true);
    }

    IEnumerator SavedTextVisibleToggle()
    {
        saveConfirmedText.enabled = true;
        yield return new WaitForSeconds(visibleTime);
        saveConfirmedText.enabled = false;
    }

    IEnumerator LoadingErrorTextVisibleToggle()
    {
        loadErrorText.enabled = true;
        yield return new WaitForSeconds(visibleTime);
        loadErrorText.enabled = false;
    }
    #endregion
}

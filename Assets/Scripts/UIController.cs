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

    PlayerController myPlayerController;

    [SerializeField]
    Text saveConfirmedText, loadErrorText, winText;
    [SerializeField]
    GameObject winWindow;

    float visibleTime = 2f;
    #endregion

    private void Start()
    {
        // PlayerController is not always present in the hierarchy, hence the use of Find.
        myPlayerController = FindObjectOfType<PlayerController>();

        saveConfirmedText.enabled = false;
        loadErrorText.enabled = false;
        winWindow.SetActive(false);
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
    #endregion



    public void LoadError()
    {
        StartCoroutine(LoadingErrorTextVisibleToggle());
    }

    public void WinWindow(string victoriousPlayer)
    {
        winWindow.SetActive(true);
        winText.text = string.Format("{0} wins!", victoriousPlayer);
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
}

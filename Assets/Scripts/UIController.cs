using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    StateController myStateController;
    [SerializeField]
    SaveGameController mySaveGameController;

    [SerializeField]
    Text saveConfirmedText, loadErrorText;


    float visibleTime = 2f;

    private void Start()
    {
        saveConfirmedText.enabled = false;
        loadErrorText.enabled = false;
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void SaveButtonPressed()
    {
        mySaveGameController.SaveGame();
        StartCoroutine(SavedTextVisibleToggle());
    }

    IEnumerator SavedTextVisibleToggle()
    {
        saveConfirmedText.enabled = true;
        yield return new WaitForSeconds(visibleTime);
        saveConfirmedText.enabled = false;
    }

    public void LoadButtonPressed()
    {
        mySaveGameController.LoadGame();
    }

    public void LoadError()
    {
        StartCoroutine(LoadingErrorTextVisibleToggle());
    }

    IEnumerator LoadingErrorTextVisibleToggle()
    {
        loadErrorText.enabled = true;
        yield return new WaitForSeconds(visibleTime);
        loadErrorText.enabled = false;
    }

}

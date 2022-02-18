using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSaves : MonoBehaviour
{
    public Button loadGameButton;

    private void Awake()
    {
        ToggleLoadGameButton();        
    }

    //disable load game if there is no save file
    public void ToggleLoadGameButton()
    {
        string filePath = Application.persistentDataPath + SaveDataManager.directory + SaveDataManager.saveFile;

        Debug.Log(filePath);

        if (!SaveDataManager.SaveExists(filePath))
        {
            loadGameButton.interactable = false;
        }
    }

    //load game > switch scene to garden and read save file into game objects
    public void LoadGame()
    {
        SaveDataManager.Load();
        SceneManager.LoadScene("Garden");
    }

    //new game > switch scene to garden and create new save file with initial objects
    public void NewGame()
    {
       SaveDataManager.Save();
        SceneManager.LoadScene("NewGame");
    }
}

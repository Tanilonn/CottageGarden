using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionSaves : MonoBehaviour
{   

    //load game > switch scene to garden and read save file into game objects
    public void SaveAndContinue()
    {
        SaveDataManager.Save();
        gameObject.SetActive(false);
    }

    //new game > switch scene to garden and create new save file with initial objects
    public void SaveAndQuit()
    {
        SaveDataManager.Save();
        Application.Quit();
    }
}

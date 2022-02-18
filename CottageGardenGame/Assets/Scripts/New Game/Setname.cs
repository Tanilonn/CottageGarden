using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setname : MonoBehaviour
{
    public InputField NameInput;

    public void SetPlayerName()
    {
        SaveDataManager.gameData.Player.Name = NameInput.text;
        SaveDataManager.Save();
        SceneManager.LoadScene("Garden");
    }
}

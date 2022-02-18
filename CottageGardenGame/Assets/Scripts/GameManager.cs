using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string fileName;
    public GameData GameData { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

    }

    public void Save()
    {
        SaveDataManager.Save();
    }

    public void Load()
    {
        GameData = SaveDataManager.Load();
    }
}

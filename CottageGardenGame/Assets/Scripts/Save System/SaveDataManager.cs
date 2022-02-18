// Add System.IO to work with files!
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{
    // Create a field for the save file.
    public static string directory = "/SaveData/";
    public static string saveFile = "mySave.txt";

    public static GameData gameData = new GameData();

    public static bool SaveExists(string path)
    {
        return File.Exists(path);
    }

    public static GameData Load()
    {
        string filePath = Application.persistentDataPath + directory + saveFile;

        // Does the file exist?
        if (SaveExists(filePath))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(filePath);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
        return gameData;
    }

    public static void Save()
    {
        string directoryPath = Application.persistentDataPath + directory;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(gameData);

        // Write JSON to file.
        File.WriteAllText(directoryPath + saveFile, jsonString);
    }

    
}
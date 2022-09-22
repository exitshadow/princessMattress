using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class GameData
{
    public string lastSceneReached;
}

public class DataManager : MonoBehaviour
{
    #region member fields & properties
    public static DataManager Instance = null;
    public static string DataPath {
        get {return Application.persistentDataPath  + "/gameSave.dat";}
    }
    public static bool SaveFileExists {
        get {return File.Exists(DataPath);}
    }
    #endregion

    #region methods
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(DataPath);

        GameData data = new GameData();
        data.lastSceneReached = SceneManager.GetActiveScene().name;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log($"File {DataPath} has been saved.");
    }

    public static void Load()
    {
        if (!SaveFileExists) return;
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(DataPath, FileMode.Open);
            GameData data = bf.Deserialize(file) as GameData;
            SceneManager.LoadScene(data.lastSceneReached);
        }
    }

    private void Awake()
    {
        #region singleton declaration
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        #endregion
    }
    #endregion
}


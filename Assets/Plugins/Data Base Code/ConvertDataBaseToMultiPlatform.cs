using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ConvertDataBaseToMultiPlatform : MonoBehaviour
{
    public string DataBaseName;

    public void Awake()
    {
        GenerateConnectionString(DataBaseName + ".db");
    }

    public void GenerateConnectionString(string DatabaseName)
    {
#if UNITY_EDITOR
        string dbPath = Application.dataPath + "/StreamingAssets/" + DatabaseName;
        Debug.Log("persistent datapath = " + Application.persistentDataPath);
#else
        //check if file exists in Application.persistentDataPath
        string filepath = Application.persistentDataPath + "/" + DatabaseName;

        if (!File.Exists(filepath) || new System.IO.FileInfo(filepath).Length == 0)
        {
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->
#if UNITY_ANDROID
            WWW loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);
            while (!loadDb.isDone) { } 
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_STANDALONE
            var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;
            // then save to Application.persistentDataPath
            File.Copy(loadDb, filepath);
#elif UNITY_STANDALONE_WIN
            var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;
            // then save to Application.persistentDataPath
            File.Copy(loadDb, filepath);
#endif
        }

        var dbPath = filepath;
#endif
    }
}

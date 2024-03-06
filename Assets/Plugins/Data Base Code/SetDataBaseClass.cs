using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SetDataBaseClass
{
    public static string SetDataBase(string DataBaseName)
    {
        string conn = "";
#if UNITY_EDITOR
        conn = "URI=file:" + Path.Combine(Application.dataPath, "StreamingAssets", DataBaseName); //Path to database
        Debug.Log("StDatabase ge currtent directory = " + Application.persistentDataPath);
        Debug.Log("Windows Mode");
        Debug.Log(conn);
#elif UNITY_STANDALONE
        conn = "URI=file:" + Path.Combine(Application.persistentDataPath, DataBaseName); //Path to database.
        Debug.Log("Android Mode");
#elif UNITY_STANDALONE_WIN
        conn = "URI=file:" + Path.Combine(Application.persistentDataPath, DataBaseName); //Path to database.
        Debug.Log("Android Mode");
#elif UNITY_ANDROID
        conn = "URI=file:" + Path.Combine(Application.persistentDataPath, DataBaseName); //Path to database.
        Debug.Log("Android Mode");
#endif

        return conn;
    }
}

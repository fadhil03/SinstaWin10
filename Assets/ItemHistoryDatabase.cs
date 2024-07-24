using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;

public class ItemHistoryDatabase : MonoBehaviour
{
    public string DataBaseName;
    public GameObject itemHistoryPrefab;
    public ScrollRect scrollView;
    public Transform scrollViewContent;

    void Start()
    {
        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");

        if (conn == null)
        {
            Debug.LogError("Failed to connect to the database.");
            return;
        }

        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        try
        {
            dbcon = new SqliteConnection(conn);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            string SQLQuery = "SELECT * FROM users";
            dbcmd.CommandText = SQLQuery;
            reader = dbcmd.ExecuteReader();

            Debug.Log("Connected to the database.");

            while (reader.Read())
            {
                GameObject newItemHistory = Instantiate(itemHistoryPrefab, scrollViewContent);
                ItemHistoryDisplay itemDisplay = newItemHistory.GetComponent<ItemHistoryDisplay>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string fieldName = reader.GetName(i);
                    string fieldValue = reader.GetValue(i).ToString();
                    itemDisplay.SetText(fieldName, fieldValue);
                }
            }

            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error accessing database: " + ex.Message);
        }
    }
}

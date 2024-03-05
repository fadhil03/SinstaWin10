using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;

public class ItemHistoryDatabase : MonoBehaviour
{
    public string DataBaseName;
    public GameObject itemHistoryPrefab;
    public Transform scrollViewContent;

    void Start()
    {
        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string SQLQuery = "SELECT * FROM users"; // Select semua record dari tabel users
        dbcmd.CommandText = SQLQuery;
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            // Membuat instance baru dari prefab ItemHistory
            GameObject newItemHistory = Instantiate(itemHistoryPrefab, scrollViewContent);

            // Mendapatkan komponen skrip yang bertanggung jawab untuk menampilkan data
            ItemHistoryDisplay itemDisplay = newItemHistory.GetComponent<ItemHistoryDisplay>();

            // Mengisi nilai pada setiap child Text sesuai dengan nilai dari field-field dalam record
            for (int i = 0; i < reader.FieldCount; i++)
            {
                // Mendapatkan nama field
                string fieldName = reader.GetName(i);

                // Mendapatkan nilai dari field
                string fieldValue = reader.GetValue(i).ToString();

                // Mengatur nilai teks pada child Text yang sesuai dengan nama field
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
}

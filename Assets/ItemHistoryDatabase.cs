using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;
using UnityEngine.UI;

public class ItemHistoryDatabase : MonoBehaviour
{
    public string DataBaseName;
    public GameObject itemHistoryPrefab;
    public ScrollRect scrollView;
    public TextMeshProUGUI debugCon, debugDB;
    public Transform scrollViewContent;

    void Start()
    {
        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");

        // Pengecekan koneksi ke database
        if (conn == null)
        {
            Debug.LogError("Failed to connect to the database.");
            debugCon.text = "Failed to connect to the database.";
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
            string SQLQuery = "SELECT * FROM users"; // Select semua record dari tabel users
            dbcmd.CommandText = SQLQuery;
            reader = dbcmd.ExecuteReader();

            // Jika koneksi berhasil, tampilkan pesan info
            Debug.Log("Connected to the database.");
            debugDB.text = "Connected to the database.";

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
        catch (System.Exception ex)
        {
            Debug.LogError("Error accessing database: " + ex.Message);
            debugDB.text = "Error accessing database: " + ex.Message;
        }
    }

    public void DeleteAllRecords()
    {
        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string SQLQuery = "DELETE FROM Users"; // Menghapus semua record dari tabel Users
        dbcmd.CommandText = SQLQuery;
        dbcmd.ExecuteNonQuery(); // Jalankan perintah SQL untuk menghapus record

        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        RefreshScrollView();
    }

    void RefreshScrollView()
    {
        scrollView.content.gameObject.SetActive(false); // Menonaktifkan konten scroll view
        scrollView.content.gameObject.SetActive(true); // Mengaktifkan kembali konten scroll view
    }
}

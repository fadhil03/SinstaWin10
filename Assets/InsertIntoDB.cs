using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using TMPro;

public class InsertIntoDB : MonoBehaviour
{
    public string DataBaseName;
    public TMP_InputField NameInput;

    public void InsertInto()
    {
        var _NameInput = NameInput.text.Trim();
        var _MediaBootable = PlayerPrefs.GetString("MediaBootable");
        var _ProductKey = PlayerPrefs.GetString("Product_Key");
        var _TypeOs = PlayerPrefs.GetString("Type_Os");
        var _Unallocated = PlayerPrefs.GetString("Unallocated_TotalSize");
        var _Partition1 = PlayerPrefs.GetString("Partition_1_TotalSize");
        var _Partition2 = PlayerPrefs.GetString("Partition_2_TotalSize");
        var _Partition3 = PlayerPrefs.HasKey("Partition_3_TotalSize") ? PlayerPrefs.GetString("Partition_3_TotalSize") : "-";
        var _Partition4 = PlayerPrefs.HasKey("Partition_4_TotalSize") ? PlayerPrefs.GetString("Partition_4_TotalSize") : "-";
        var _Username = PlayerPrefs.GetString("Username");
        var _Password = PlayerPrefs.HasKey("Password") ? PlayerPrefs.GetString("Password") : "-";
        var _ElapsedSimulationTime = PlayerPrefs.GetString("ElapsedSimulationTime");

        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string SQLQuery = "INSERT INTO Users (TanggalInput, Name, MediaBootable, ProductKey, TypeOs, UnallocatedPartition, Partition1, Partition2, Partition3, Partition4, UsernameWin, PasswordWin, SimulationTime) " +
                  "VALUES (DATETIME('now', 'localtime'), '" + _NameInput + "', '" + _MediaBootable + "', '" + _ProductKey + "', '" + _TypeOs + "', '" + _Unallocated + "', '" + _Partition1 + "', '" + _Partition2 + "', '" + _Partition3 + "', '" + _Partition4 + "', '" + _Username + "', '" + _Password + "', '" + _ElapsedSimulationTime + "')";
        dbcmd.CommandText = SQLQuery;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {

        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }
}

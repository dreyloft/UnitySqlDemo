using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography; // md5 hash
using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

public class databaseHandler : MonoBehaviour
{
    public string host, database, user, password;
    public bool pooling = true;
	public GameObject carModel;

    private string connectionString, sql;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader rdr = null;
    private MD5 _md5Hash;
	private int size;
	public string[, , , ,] qadCarsArray;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        connectionString = "Server=" + host + ";User=" + user + ";Password=" + password + ";Pooling=";

        if (pooling)
        {
            connectionString += "true;";
        }
        else
        {
            connectionString += "false;";
        }

        try
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            Debug.Log("MySQL State: " + con.State);

			readDatabase();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnApplicationQuit()
    {
        if (con.State.ToString() != "Closed")
        {
            con.Close();
            Debug.Log("MySQL Connection closed");
        }
        con.Dispose();
    }

	public string getConnectionState()
	{
		return con.State.ToString();
	}

	public void readDatabase(){
		sql += "USE democar; SELECT * FROM cars ";

		cmd = new MySqlCommand (sql, con);
		rdr = cmd.ExecuteReader();

		while (rdr.Read()) {
			Debug.Log(rdr.GetString("ID"));

			createCar(
				Int32.Parse(rdr.GetString("ID")), 
				rdr.GetString("Brand"), 
				Int32.Parse(rdr.GetString("Chassis_Number")), 
				Int32.Parse(rdr.GetString("Level")), 
				Int32.Parse(rdr.GetString("Lot")));
		}			
	}

	public void createCar(int id, string brand, int chassisNumber, int level, int lot)
	{
		Instantiate(carModel, new Vector3(-4.5f + lot, level + 0.25f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
	}
}
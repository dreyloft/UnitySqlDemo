using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography; // md5 hash
using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

public class databaseHandlerSand : MonoBehaviour
{
	public string host, database, table, user, password;
	public bool pooling = true;
	private string connectionString, sql;
	private MySqlConnection con = null;
	private MySqlCommand cmd = null;
	private MySqlDataReader rdr = null;
	private MD5 _md5Hash;

	public Terrain terrainObject;
	private float[,] heights;
	private int xRes, yRes;

	private void Awake()
	{
		xRes = terrainObject.terrainData.heightmapWidth;
		yRes = terrainObject.terrainData.heightmapHeight;
		heights = terrainObject.terrainData.GetHeights (0, 0, xRes, yRes);

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

			terrainObject.terrainData.SetHeights (0, 0, heights);
			con.Close();
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

		resetTerrain ();
	}

	public string getConnectionState()
	{
		return con.State.ToString();
	}

	public void readDatabase(){
		sql += "USE " + database + "; SELECT * FROM " + table + " ";

		cmd = new MySqlCommand (sql, con);
		rdr = cmd.ExecuteReader();

		while (rdr.Read()) {
			heights [rdr.GetInt32 ("x"), rdr.GetInt32 ("y")] = (256.0f + rdr.GetFloat ("height")) / 512.0f;
		}
	}

	public void resetTerrain()
	{
		for (int y = 0; y < yRes; y++) {
			for (int x = 0; x < xRes; x++) {
				heights [x, y] = 0.0f;
			}
		}
		terrainObject.terrainData.SetHeights (0, 0, heights);
	}
}
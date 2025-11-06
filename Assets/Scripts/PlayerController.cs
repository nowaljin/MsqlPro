using System;
using System.Data;
using UnityEngine;
using MySqlConnector;

public class PlayerController : MonoBehaviour
{
    private string connStr = "server=172.16.2.26;user id=tateno;password=ae21215926;database=BozkurtIlker";
    public string nameID = "SquareA";
    public float moveStep = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SendPositionToDB), 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W))pos.y += moveStep;
        if (Input.GetKey(KeyCode.S))pos.y -= moveStep;
        if (Input.GetKey(KeyCode.A))pos.x -= moveStep;
        if (Input.GetKey(KeyCode.D))pos.x += moveStep;
       
        transform.position = pos;
        
    }

    private void SendPositionToDB()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                string slq = "update pos set x="+posX+",y="+;
                MySqlCommand cmd = new MySqlCommand(slq, conn);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }
    }
}
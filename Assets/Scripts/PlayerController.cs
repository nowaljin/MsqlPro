using MySqlConnector;
using System;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string connStr = "server=172.16.2.26;user id=tateno;password=ae21215926;database=tateno";
    public string nameID = "SquareA";
    public float moveStep = 0.001f;
    private float sendInterval = 0.5f;
    private float sendTimer = 0f;
    public float speed = 2f;
    public float distance = 3f;
    private float startX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W)) pos.y += moveStep;
        if (Input.GetKey(KeyCode.S)) pos.y -= moveStep;
        if (Input.GetKey(KeyCode.A)) pos.x -= moveStep;
        if (Input.GetKey(KeyCode.D)) pos.x += moveStep;
        transform.position = pos;
        sendTimer += Time.deltaTime;
        if (sendTimer >= sendInterval)
        {
            SendPositionToDB();
            sendTimer = 0f;
        }
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
                string slq = "update pos set x=" + posX + ",y=" + posY + " where id=22503026";
                MySqlCommand cmd = new MySqlCommand(slq, conn);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }
    }
}
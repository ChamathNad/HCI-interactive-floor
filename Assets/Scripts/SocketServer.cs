//using System;
//using WebSocketSharp;
//using UnityEngine;

//public class SocketServer : MonoBehaviour
//{
//        private Laputa wssv;
//        WebSocket ws = new WebSocket("ws://localhost:8765/");

//        void Start()
//        {        



//    }
//    private void Update()
//    {
//        //ws.OnMessage += (sender, e) =>
//        //      Debug.Log("Laputa says: " + e.Data);
//        //Debug.Log("sssss");
//        //ws.Connect();
//    }
//}
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using WebSocketSharp;

public class SocketServer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("WebSocket Class");
        // Create WebSocket instance
        using (var ws = new WebSocket("ws://localhost:8765/"))
        {

            Debug.Log(ws.ReadyState);

            // Add OnOpen event listener
            ws.OnOpen += (sender, e) => {


                Debug.Log("WS connected!");
                Debug.Log("WS state: " + ws.ReadyState);

                ws.Send(Encoding.UTF8.GetBytes("Hello from Unity 3D!"));
            };

            // Add OnMessage event listener
            ws.OnMessage += (sender, e) => {

                Debug.Log("WS received message: " + e.Data);// Encoding.UTF8.GetString(e.Data));

                ws.Close();
            };

            // Add OnError event listener
            ws.OnError += (sender, e) => {


                Debug.Log("WS error: " + e.Exception);
            };

            // Add OnClose event listener

            // Connect to the server
            ws.Connect();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

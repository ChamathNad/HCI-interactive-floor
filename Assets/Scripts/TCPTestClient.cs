using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TCPTestClient : MonoBehaviour {  	
	#region private members 	
	private TcpClient socketConnection; 	
	private Thread clientReceiveThread;

    #endregion

    private string dataset;

    // Use this for initialization 	
    void Start () {
		ConnectToTcpServer();     
	}  	
	// Update is called once per frame
	void Update () {         
		if (dataset != null) {
            Debug.Log(dataset);
             this.GetComponent<Spawner>().spawner(dataset);
        }     
	}  	
	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	private void ConnectToTcpServer () { 		
		try {  			
			clientReceiveThread = new Thread (new ThreadStart(ListenForData)); 			
			clientReceiveThread.IsBackground = true; 			
			clientReceiveThread.Start();  		
		} 		
		catch (Exception e) { 			
			Debug.Log("On client connect exception " + e); 		
		} 	
	}  	
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
	private void ListenForData() { 		
		try { 			
			socketConnection = new TcpClient(DataHolder.IPaddress,DataHolder.port);  			
			Byte[] bytes = new Byte[4096];

            Debug.Log(socketConnection.ToString());
			while (true) {
                // Get a stream object for reading 
                Debug.Log("-------------------------------");

                using (NetworkStream stream = socketConnection.GetStream()) { 					
					int length; 					
					// Read incomming stream into byte arrary. 					
					while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) { 						
						var incommingData = new byte[length]; 						
						Array.Copy(bytes, 0, incommingData, 0, length); 						
						// Convert byte array to string message. 						
						string serverMessage = Encoding.UTF8.GetString(incommingData); 						
						Debug.Log("server message received as: " + serverMessage);
                        dataset = serverMessage;
					} 				
				} 			
			}
        }         
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);
            if (socketConnection != null)
            {
                socketConnection.Close();
            }
            else
            {
                DataHolder.conStatus = false;
                Debug.Log("Socket is NULL");
            }

        }
        catch (Exception)
        {
            DataHolder.conStatus = false;
            Debug.Log("Connection Lost");
        }
	}
    private void OnDisable()
    {
        Debug.Log("Socket script is Closing");
        if (socketConnection != null)
        {
            socketConnection.Close();
            DataHolder.conStatus = false;
        }
        else
        {
            Debug.Log("Socket is NULL");
        }
    }
    /// <summary> 	
    /// Send message to server using socket connection. 	
    /// </summary> 	
    private void SendMessage() {         
		if (socketConnection == null) {             
			return;         
		}  		
		try { 			
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream(); 			
			if (stream.CanWrite) {                 
				string clientMessage = "This is a message from one of your clients."; 				
				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage); 				
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);                 
				Debug.Log("Client sent his message - should be received by server");             
			}         
		} 		
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	}
}
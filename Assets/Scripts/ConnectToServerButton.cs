using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class ConnectToServerButton : NetworkBehaviour
{
	public NetworkMenu onlinemenu;
	public Text serverIP;
    public Text gameName;

    private HostData connection;
	
	// Use this for initialization
	public void OnClick () {
		if(connection != null) {
			Network.Connect (connection);
			onlinemenu.errors.text = "host data connecting...";
		}
		else if(serverIP!= null && onlinemenu.serverPort!=null) {
            //string serverIP = this.serverIP.text;
            //int serverPort = int.Parse(this.onlinemenu.serverPort.text);
            string serverIP = "localhost";
            int serverPort = onlinemenu.defaultServerPort;
            onlinemenu.errors.text = "port" + onlinemenu.serverPort.text;
			Network.Connect(serverIP, serverPort);
			Debug.Log( "connecting to s" + serverIP + ":" + serverPort + " ...");
		} else {
			print ("Lo script non sa a chi connettersi");
		}
	}
    public override void OnStartClient()
    {
        if (isLocalPlayer)
        {
            Debug.Log("0 ASSERT OnConnectedToServer");
            onlinemenu.errors.text = "OnConnectedToServer";
        }
    }

    void OnConnectedToServer()
    {
        onlinemenu.errors.text = "OnConnectedToServer";
    }

    void OnFailedToConnect(NetworkConnectionError error)
    {
        Debug.Log("Failed to connect to server" + error);
    }

    public void setConnection(HostData con) {
		connection = con;
        gameName.text = con.gameName;

        //OnClick();
	}
}

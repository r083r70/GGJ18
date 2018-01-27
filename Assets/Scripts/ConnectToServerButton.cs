using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConnectToServerButton : MonoBehaviour {
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
            onlinemenu.errors.text = "port" + onlinemenu.serverPort.text;
			Network.Connect(serverIP.text, int.Parse(onlinemenu.serverPort.text));
			onlinemenu.errors.text = "connecting...";
		} else {
			print ("Lo script non sa a chi connettersi");
		}
	}

    void OnConnectedToServer()
    {
        Debug.Log("Connected to server");
    }

    void OnFailedToConnect(NetworkConnectionError error)
    {
        Debug.Log("Failed to connect to server" + error);
    }

    public void setConnection(HostData con) {
		connection = con;
        gameName.text = con.gameName;

        OnClick();
	}
}

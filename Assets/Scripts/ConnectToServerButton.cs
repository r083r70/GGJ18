using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConnectToServerButton : MonoBehaviour {
	public NetworkMenu onlinemenu;
	public Text serverIP;
	public Text serverPort;
    public Text gameName;

    private HostData connection;

	void Start() {
		if(serverIP!= null && serverPort!=null) {
			serverIP.text = onlinemenu.serverIP;
			serverPort.text = ""+onlinemenu.serverPort;
		}
	}
	
	// Use this for initialization
	public void OnClick () {
		if(connection != null) {
			Network.Connect (connection);
			onlinemenu.errors.text = "connecting...";
		}
		else if(serverIP!= null && serverPort!=null) {
			Network.Connect(serverIP.text, int.Parse(serverPort.text));
			onlinemenu.errors.text = "connecting...";
		} else {
			print ("Lo script non sa a chi connettersi");
		}
	}
	
	void OnConnectedToServer() {
        //Network.isMessageQueueRunning = false;
        onlinemenu.errors.text = "connected to " + connection.gameName;
    }
	
	public void setConnection(HostData con) {
		connection = con;
        gameName.text = con.gameName;

        OnClick();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConnectToServerIP : MonoBehaviour {
    public InputField[] ipFields;
    public int[] defaultIp;
    public Text text;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < ipFields.Length; i++)
        {
            ipFields[i].text = "" + defaultIp[i];
        }
    }
	
	// Update is called once per frame
	public void Connect() {
        string ip = "";
        
        for (int i = 0; i < ipFields.Length - 1; i++)
        {
            ip += ipFields[i].text + ".";
        }
        ip += ipFields[ipFields.Length - 1].text;

        text.text = "connecting to " + ip + ":" + Manager.serverPort;

        Network.Connect(ip, Manager.serverPort);
    }
}

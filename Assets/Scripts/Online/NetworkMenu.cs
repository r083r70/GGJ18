using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkMenu : NetworkManager
{
    public int maxConnections = 2;
    public Text serverPort;
    public int defaultServerPort = 7777;
    public Text playerName;
    public Text numServers;
    public GameObject playerPrefab;


    // Use this for initialization
    void Start () {
        //InitServer();

        Refresh();
	}


    public void InitServer()
    {
        bool pa = Network.HavePublicAddress();

        NetworkConnectionError error;

        
        if (serverPort == null)
        {
            error = Network.InitializeServer(maxConnections, defaultServerPort, !pa);
        }
        else
        {
            error = Network.InitializeServer(maxConnections, int.Parse(serverPort.text), !pa);
        }

        if (error == NetworkConnectionError.NoError)
        {
            MasterServer.RegisterHost(gameTypeName, playerName.text + "'s game");
            OnRegisterHost();
        }
        else
        {
            errors.text = "" + error;
        }
    }

    void OnRegisterHost()
    {
        Debug.Log(errors + " " + "NewServer");
        errors.text = "NewServer";
        Network.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, 0);
    }

    public string gameTypeName = "GGJ18";
    public string roomName = "Test Room";

    public string serverIP = "localhost";

    public int GameScene = 1;

    public GameObject servers;

    public Text errors;


    public void Refresh()
    {
        MasterServer.ClearHostList();
        MasterServer.RequestHostList(gameTypeName);
    }

    void Update()
    {
        HostData[] conns = MasterServer.PollHostList();
        numServers.text = conns.Length.ToString();

        /* for(int i=0; i<conns.Length-servers.transform.childCount; i++) {
			Transform bo = servers.transform.GetChild(0);
			Transform b = Instantiate(bo,bo.position,bo.rotation) as Transform;
			b.parent = servers.transform;
			b.position = Vector3.up*20f;
		} */

        for (int i = 0; i < conns.Length; i++)
        {
            setServer(conns[i], servers.transform.GetChild(i));


            //UIButton b = Instantiate(UIButton) as UIButton;
            //b.transform.parent = transform;
        }
    }

    private void setServer(HostData server, Transform t)
    {
        string name = server.gameName;
        string players = "" + server.connectedPlayers;

        ConnectToServerButton b = t.GetComponent<ConnectToServerButton>();
        b.setConnection(server);

        //Text l = animation.FindChild("ServerName").GetComponent<Text>();
        //l.text = name + " " + players;
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        Debug.Log("1");
        errors.text = "OnServerConnect";
        Debug.Log("OnServerConnect");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        errors.text = "ClientConnect";
        Debug.Log("ClientConnect");
    }
}

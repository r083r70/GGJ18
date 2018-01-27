using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : NetworkManager
{
    public static int serverPort = 7777;
    public static string gameTypeName = "GGJ18";
    public Text errors;

    // Use this for initialization
    void Start()
    {
        InitServer();
    }

    public void InitServer()
    {
        bool pa = Network.HavePublicAddress();

        NetworkConnectionError error = Network.InitializeServer(maxConnections, serverPort, !pa);
        errors.text = "Initialize server " + Network.player.ipAddress + ":" + serverPort;

        if (error == NetworkConnectionError.NoError)
        {
            //MasterServer.RegisterHost(gameTypeName, "'s game");
            //OnRegisterHost();
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
        Debug.Log("NewServer");
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        errors.text = "ServerConnect";
        Debug.Log("ServerConnect");
        
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        errors.text = "ClientConnect";
        Debug.Log("ClientConnect");
    }
}
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : NetworkManager
{
    public int serverPort = 7777;
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

        if (error == NetworkConnectionError.NoError)
        {
            MasterServer.RegisterHost(gameTypeName, "'s game");
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

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        errors.text = "ServerConnect";
        SceneManager.LoadScene("PiccioneAnims", LoadSceneMode.Additive);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        errors.text = "ClientConnect";

    }
}
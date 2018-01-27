using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class SearchServer : MonoBehaviour {
    public Text errors;
    private bool connecting;

    void Start()
    {
        connecting = false;
        Refresh();
    }

    public void Refresh()
    {
        MasterServer.ClearHostList();
        MasterServer.RequestHostList(Manager.gameTypeName);
    }

    void Update()
    {
        if (connecting)
        {
            return;
        }

        Refresh();


        HostData[] conns = MasterServer.PollHostList();
        for (int i = 0; i < conns.Length; i++)
        {
            Connect(conns[i]);
        }
    }

    public void Connect(HostData server)
    {
        if (server != null)
        {
            Network.Connect(server);
            errors.text = "host data connecting...";
            connecting = true;
        }
        else
        {
            errors.text = "Lo script non sa a chi connettersi";
        }
    }

    /*public override void OnStartClient()
    {
        if (isLocalPlayer)
        {
            errors.text = "0 ASSERT OnConnectedToServer";
        }
    }*/

    
}

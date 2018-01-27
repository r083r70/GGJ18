using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientConnection : NetworkBehaviour {
    public Text errors;
    private bool connecting;

    void Start()
    {
        
    }

    

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (isLocalPlayer)
        {
            errors.text = "0 ASSERT OnConnectedToServer";
        }
    }


}

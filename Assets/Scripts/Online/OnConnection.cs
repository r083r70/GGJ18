using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnConnection : NetworkBehaviour {
    public Text errors;
    private bool connecting;

    

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (isLocalPlayer)
        {
            SceneManager.LoadScene("Particles");
        }
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        if (isServer)
        {
            SceneManager.LoadScene("Particles");
        }
    }
}

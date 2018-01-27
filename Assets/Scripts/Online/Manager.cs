using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Manager : NetworkManager
{
    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("1");
        SceneManager.LoadScene("PiccioneAnims", LoadSceneMode.Additive);
    }


}
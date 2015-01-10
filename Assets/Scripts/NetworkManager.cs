using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
    public GameObject obj;
	public GameObject obj2;
    string ip = "127.0.0.1";
    string port = "25000";
    bool connected = false;
    private void CreatePlayer()
    {
        connected = true;
        Network.Instantiate(obj, obj.transform.position, obj.transform.rotation, 1);
		Network.Instantiate(obj2, obj.transform.position, obj.transform.rotation, 1);

    }
    // サーバーに接続したとき呼ばれる
    public void OnConnectedToServer()
    {
        CreatePlayer();
        connected = true;
    }
    //　サーバー初期化するときに呼ばれる
    public void OnServerInitialized()
    {
        CreatePlayer();
    }

    // ここらへんはボタンで呼んでる
    public void InitServer()
    {
        if(!connected)
        Network.InitializeServer(10, int.Parse(port), false);
    }
    public void ConnecteClient()
    {
        if(!connected)
        Network.Connect(ip, int.Parse(port));
    }


}

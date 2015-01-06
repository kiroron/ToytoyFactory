using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
    string registeredGameName = "Test";
    private void StartServer()
    {
        Network.InitializeServer(32, 25000, false);
        MasterServer.RegisterHost(registeredGameName,"Networking Turoial Game");
    }
}

using UnityEngine;
using System.Collections;

public class TestRPCManager : MonoBehaviour {
    [RPC]
     public void ToggleColor(){
         renderer.material.color = Color.black;
        }
	// Update is called once per frame
	void Update () {
       
        if (networkView.isMine)
        {
            if (Input.GetKey("a"))
            {
                networkView.RPC("ToggleColor", RPCMode.All);
            }
        }
	}
}

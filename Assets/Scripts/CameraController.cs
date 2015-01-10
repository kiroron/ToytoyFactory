using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
		GetComponent<Camera>().enabled = networkView.isMine;
    }

    void Update()
    {

    }
}

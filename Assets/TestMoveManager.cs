using UnityEngine;
using System.Collections;

public class TestMoveManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if (networkView.isMine)
        {
            if (Input.GetKey("right"))
            {
                pos.x += 0.2f;
                transform.position = pos;
            }
            if (Input.GetKey("left"))
            {
                pos.x += -0.2f;
                transform.position = pos;
            }
        }
	}
}

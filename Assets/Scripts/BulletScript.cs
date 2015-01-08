using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public float speed = 5;
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * speed;
	}

	void OnCollisionEnter(Collision col){
		Destroy (this.gameObject);
	}
}

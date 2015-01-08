using UnityEngine;
using System.Collections;

public class SkillController : MonoBehaviour {
	public GameObject obj;
	private GameObject playerCamera;
	void Start(){
		playerCamera = GetComponent<ThirdPersonController> ().playerCamera;
	}

	public void Update(){
		if(Input.GetButtonDown("Fire1")) Shot();
	}
	public void Shot(){
		GameObject testshot = Instantiate (obj, transform.position + new Vector3(0,1,0), playerCamera.transform.rotation) as GameObject;

	}
}

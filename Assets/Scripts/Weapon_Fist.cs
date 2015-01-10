using UnityEngine;
using System.Collections;

public class Weapon_Fist : MonoBehaviour {
	public bool isAttack;
	enum AttackNum{
		non,
		NormalAttack
	}
	private Animator animator;
	private GameObject father;
	void Awake(){
		father = GameObject.FindWithTag ("Player");
		gameObject.transform.parent = father.transform;
		animator = transform.parent.GetComponent<Animator> ();
		transform.parent = GameObject.FindWithTag ("RightHand").transform;
		transform.localPosition = Vector3.zero;
	}
	void AttackStart(){
		isAttack = true;
		collider.enabled = true;
	}
	public void AttackEnd(){
		isAttack = false;
	}
	void ConnectAttackPoint(){
		collider.enabled = false;
	}

	void StanderdAttack(){
		AttackStart ();
	}
	void Update(){
		if(Input.GetKey("z")){
			father.GetComponent<ThirdPersonController>().AttackStart ();
		}

	}

}

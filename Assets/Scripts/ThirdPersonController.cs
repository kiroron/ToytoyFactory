// 三人称ゲーム作る時のカメラのスクリプト
// 使う時はカメラを子供にして、親にaddして使ってね！
// Vector3 cameraPositionはカメラとプレイヤーとの距離です！

using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {
	/* カメラ関係 */
	public float sensitivityX = 10f;
	public float sensitivityY = 10f;
	public float minimumY = -60f;
	public float maximumY = 60f;
	public float cameraDistant = 3f;//カメラとプレイヤーとの距離
	public Vector3 plusCameraPosition = new Vector3(0.5f,1f,0);

	private Vector3 cameraPosition;
	public GameObject playerCamera;
	private float rotationY = 0f;
	private float rotationX = 0f;

	/* 移動関係 */
	public float speed = 2.0f;
	public float jumpPower = 20.0f;
	public float gravity = 3.0f;

	private float moveDirection_y = 0;
	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	void Start(){

		controller = GetComponent<CharacterController> ();

		playerCamera = gameObject.transform.FindChild ("Camera").gameObject;
		// カメラを親から切り離す
		playerCamera.transform.parent = null;
	}
	void FixedUpdate () {
		
		// カメラを決める
		NormalCamera ();
		// カメラの向きを使って移動する
		Move ();
	}
	
	
	
	void NormalCamera(){
		// マウスの移動量取得
		rotationX += Input.GetAxis ("Mouse X") * sensitivityX ;
		rotationY += Input.GetAxis ("Mouse Y") * -sensitivityY;


		rotationX %= 360; // 1回転=360度
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		// カメラの座標を決める。球体座標。めんどくさかった
		cameraPosition.z = Mathf.Cos (rotationX * Mathf.PI / 180) * Mathf.Cos(rotationY * Mathf.PI / 180);
		cameraPosition.x = Mathf.Sin (rotationX * Mathf.PI / 180) * Mathf.Cos(rotationY * Mathf.PI / 180);

		cameraPosition.y = Mathf.Sin (-rotationY * Mathf.PI / 180);

		cameraPosition *= -cameraDistant;

		// cameraのアングルを決める
		playerCamera.transform.localEulerAngles = new Vector3 (rotationY, rotationX, 0);

		// 最後にプレイヤーの座標を足した値を追加して座標確定
		playerCamera.transform.position = cameraPosition + transform.position + plusCameraPosition;
	}

	void Move(){
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			moveDirection = playerCamera.transform.right * Input.GetAxis ("Horizontal") +
			playerCamera.transform.forward * Input.GetAxis ("Vertical");

			moveDirection.y = 0;
			moveDirection.Normalize ();
			moveDirection *= speed;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (moveDirection), 0.1f);
		} else
			moveDirection = Vector3.zero;
		// ジャンプ関係
		if (controller.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				moveDirection_y = jumpPower;
			}
		} else {
			moveDirection_y -= gravity * Time.deltaTime;
		}
		moveDirection.y = moveDirection_y;
		controller.Move (moveDirection * Time.deltaTime);
	}
}

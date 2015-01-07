// 三人称ゲーム作る時のカメラのスクリプト
// 使う時はカメラを子供にして、親にaddして使ってね！
// Vector3 cameraPositionはカメラとプレイヤーとの距離です！

using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {
	public float sensitivityX = 10f;
	public float sensitivityY = 10f;
	public float minimumY = -60f;
	public float maximumY = 60f;
	
	public Vector3 cameraPosition = new Vector3 (0, 1, -3);
	private Vector3 cameraPositionRe;
	private GameObject playerCamera;
		public float rotationY = 0f;
		public float rotationX = 0f;
	
	void Start(){
				// カメラを取得する
				playerCamera = gameObject.transform.FindChild ("Camera").gameObject;
				// カメラを親から切り離す
				playerCamera.transform.parent = null;
	}
	void FixedUpdate () {
				// マウスの移動量取得
				rotationX += Input.GetAxis ("Mouse X") * sensitivityX ;
				rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;

				rotationX %= 360; // 1回転=360度
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				// カメラ関係（子供になってないとダメ）
				// ポジション決め
	
				NormalCamera ();
		
		
				//transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0)
	}
	
	
	
	void NormalCamera(){
				cameraPositionRe.z = Mathf.Cos (-rotationY * Mathf.PI / 180) * cameraPosition.z + Mathf.Cos(rotationX * Mathf.PI / 180);

				cameraPositionRe.x = Mathf.Sin (rotationX * Mathf.PI / 180);
				cameraPositionRe.y = Mathf.Sin (-rotationY * Mathf.PI / 180);

				playerCamera.transform.localEulerAngles = new Vector3 (-rotationY, -rotationX, 0);

				//	transform.localEulerAngles = new Vector3 (0, rotationX, 0);
				playerCamera.transform.position = cameraPositionRe + transform.position;
	}
	void FlayCamera(){
		
		playerCamera.transform.localPosition = cameraPosition ;
		playerCamera.transform.localEulerAngles = Vector3.zero;
		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		
	}
}

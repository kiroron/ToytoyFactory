using UnityEngine;
using System.Collections;

public class CharacterMoveController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public float gravity;
    public bool isis;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
		isis = networkView.isMine;
	}
	
	// Update is called once per frame
	void Update () {
				if (isis)
        {
            Vector2 moved = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moved.Normalize();
            moved *= speed;
            // 水面方向関係
            moveDirection.x = moved.x;
            moveDirection.z = moved.y;
            moveDirection = transform.TransformDirection(moveDirection);

            // ジャンプ関係
            if (controller.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpPower;
                }
            }
            else
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            controller.Move(moveDirection * Time.deltaTime);
        }
	}
}

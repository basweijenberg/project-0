using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	public static float translation = 0;
	public static float hor = 0;
	public static float ver = 0;
	public static bool canMove = true;

	void FixedUpdate() {
		if (canMove){
			translation = Input.GetAxisRaw("Vertical") * speed;
			float straffe = Input.GetAxisRaw("Horizontal") * speed;
			hor = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
			ver = Mathf.Abs(Input.GetAxisRaw("Vertical"));
			translation *= Time.deltaTime;
			straffe *= Time.deltaTime;

			transform.Translate(straffe, 0, translation);	
		}
	}
}

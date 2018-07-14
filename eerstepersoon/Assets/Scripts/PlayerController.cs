using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;

	void Update() {
		float translation = Input.GetAxisRaw("Vertical") * speed;
		float straffe = Input.GetAxisRaw("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate(straffe, 0, translation);	
	}
}

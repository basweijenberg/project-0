using UnityEngine;

public class MouseLockController : MonoBehaviour {

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update() {
		if (Input.GetButtonDown("Cancel")){
			Cursor.lockState = CursorLockMode.None;
		}

		if (Input.GetButtonDown("Fire1")){
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}

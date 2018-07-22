using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 3.0f;
	public float smoothing = 2.0f;
	float elapsedTime = 0;

	GameObject player;

	void Start() {
		player = this.transform.parent.gameObject;
	}

	void Update() {
		if (!PauseMenuController.GameIsPaused && PlayerController.canMove){
			var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

			md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
			smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f/smoothing);
			smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f/smoothing);
			mouseLook += smoothV;

			transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
			player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
			mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

			float totalMovement = Mathf.Clamp(PlayerController.hor + PlayerController.ver, 0, 1);
			if (totalMovement > 0)
				elapsedTime += Time.deltaTime;
			
			float yOffset = Mathf.Sin(elapsedTime*15)*0.05f;
			transform.position =  transform.parent.position +(Vector3.up/2)+ Vector3.up* (yOffset*totalMovement);
		}
	}
}

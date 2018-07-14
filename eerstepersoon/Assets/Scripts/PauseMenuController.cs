using UnityEngine;

public class PauseMenuController : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	void Start(){
		Resume();
	}

	void Update(){
		if (!GameIsPaused) {
			if (Input.GetButtonDown("Cancel")) 
				Pause();
		} else
			if (Input.GetButtonDown("Fire1")){
				Resume();
			}
	}

	void Resume() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		GameIsPaused = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Pause() {
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		GameIsPaused = true;
		Cursor.lockState = CursorLockMode.None;
	}
}

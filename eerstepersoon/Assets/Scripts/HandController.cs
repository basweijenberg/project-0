using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

	public GameObject pivot;

	void Update() {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0.2f));
		Debug.DrawRay(ray.origin, ray.direction*2, Color.yellow);
		if(Input.GetButtonDown("Fire1")){
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 3)){
				if (hit.transform.tag == "Pickup"){
					StartCoroutine(Pickup(hit.transform.gameObject, hit.point));
				}
			}
		}
		if (PlayerController.canMove){
			transform.position = Vector3.Lerp(transform.position, pivot.transform.position, Time.deltaTime* 10f);
			transform.rotation = Quaternion.Lerp(transform.rotation, pivot.transform.rotation, Time.time * 3);
		}
	}

	private IEnumerator Pickup(GameObject g, Vector3 v){
		Debug.Log("Nice!");
		PlayerController.canMove = false;
		while (transform.position != v){
			transform.position = Vector3.MoveTowards(transform.position, v, 2*Time.deltaTime);
			yield return null;
		}
		PlayerController.canMove = true;
	}
}

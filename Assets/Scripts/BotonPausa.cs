using UnityEngine;
using System.Collections;

public class BotonPausa : MonoBehaviour {

	public GameObject PauseCamera;
	bool pause = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){ //Este metodo es para acivar la pausa
		if (gameObject.name == "Pause") {
			PauseCamera.SetActive(true);
			pause = true;
			if (pause == true){
				NotificationCenter.DefaultCenter().PostNotification(this, "Pausa");
			}
		}else if(gameObject.name == "Help"){
			PauseCamera.SetActive(false);
			pause = false;
			if (pause == false){
				Time.timeScale = 1;
			}
		}
		//NotificationCenter.DefaultCenter ().PostNotification (this, "Pausa");
		//Debug.Log ("Pausa");
		//Application.LoadLevel ("PausaScene");
	}
}

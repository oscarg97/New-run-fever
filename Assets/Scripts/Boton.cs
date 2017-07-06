using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){ //Este metodo es para ir a la siguiente escena
		if (Application.loadedLevelName == "InicioScene") {
			Application.LoadLevel("HelpScene1");
		}if (Application.loadedLevelName == "HelpScene1") {
			Application.LoadLevel("HelpScene2");
		}if (Application.loadedLevelName == "HelpScene2") {
			Application.LoadLevel("HelpScene3");
		}if (Application.loadedLevelName == "HelpScene3") {
			Application.LoadLevel("GameScene");
		}if (Application.loadedLevelName == "GameScene") {
			Application.LoadLevel("GameScene");
		}
	}
}

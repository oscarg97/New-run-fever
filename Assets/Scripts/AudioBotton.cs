using UnityEngine;
using System.Collections;

public class AudioBotton : MonoBehaviour {

	public GameObject mas, menos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){ //Este metodo es para ir a la siguiente escena
		if (mas.name == "+") {
			AudioListener.volume = 1;
		}if (menos.name == "-") {
			AudioListener.volume = 0;
		}
	}
}
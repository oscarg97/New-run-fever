using UnityEngine;
using System.Collections;

public class BotonPausa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){ //Este metodo es para acivar la pausa
		Debug.Log ("Pausa");
		//Application.LoadLevel ("PausaScene");
	}
}

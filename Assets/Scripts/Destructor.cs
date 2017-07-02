using UnityEngine;
using System.Collections;

//Esta clase es para no tener basura de objetos fuera de pantalla
public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Este metodo es para que cuando colisione el objeto destructor con cualquier otro, se elimine
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Debug.Break();
			// POR HACER... HACER QUE SE MUESTRE LA PUNTUACION MAXIMA
			// (HA MUERTO EL PERSONAJE)
		}else{
			Destroy(other.gameObject);
		}
	}
}

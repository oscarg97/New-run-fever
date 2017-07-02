using UnityEngine;
using System.Collections;

//Movimiento de la camara con el personaje
public class SeguirPersonaje : MonoBehaviour {

	public Transform personaje;
	public float separacion = 6f; //Esta variable es para que el personaje este mas a la izq del centro de la camara

	// Update is called once per frame
	void Update () { //Mover la camara dependiendo de la posicion del personaje
		transform.position = new Vector3 (personaje.position.x+separacion, transform.position.y, transform.position.z);
	}
}

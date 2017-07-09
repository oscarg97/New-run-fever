using UnityEngine;
using System.Collections;

//Clase para contar el puntaje en plataformas
public class Bloque : MonoBehaviour {

	private bool haColisionadoConElJugador = false; //Controlar la colision del personaje y plataforma
	public int puntosGanados = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(!haColisionadoConElJugador && collision.gameObject.tag == "Player"){
			//Debug.Log ("Colision ok");
			GameObject obj = collision.contacts[0].collider.gameObject;
			if(obj.name == "PATA_1" || obj.name == "PATA_0"){
				//Esto es para que se sepa si solo son las patas las que tocan
				haColisionadoConElJugador = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
			}
		}
	}
}

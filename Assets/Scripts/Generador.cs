﻿using UnityEngine;
using System.Collections;

// esta clase es para generar las plataformas aleatoriamente
public class Generador : MonoBehaviour {
	public GameObject[] obj;
	public float tiempoMin = 1.5f;
	public float tiempoMax = 3f;
	private bool fin = false; //Esta variable es para generar bloques si el personaje no ha perdido

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer"); 
		//toda esta linea de codigo es para que el programa sepa cuando empieza a correr el personaje
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeHaMuerto"); 
		//toda esta linea de codigo es para que el programa sepa cuando murio el personaje
	}

	void PersonajeHaMuerto(Notification notification){
		fin = true;
	}

	void PersonajeEmpiezaACorrer(Notification notification){
		Generar ();
	}

	// Update is called once per frame
	void Update () {
	
	}
	// este metodo instancia las opciones de objeto que se dieron, aleatoriamente. ej: de los 3 tipos
	//de plataformas se escoje uno a la vez
	void Generar (){
		if (!fin) {//desde 0 hasta .length {cuantas opciones son)
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
				}
	}
}

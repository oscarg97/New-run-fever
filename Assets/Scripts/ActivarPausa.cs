﻿using UnityEngine;
using System.Collections;

public class ActivarPausa : MonoBehaviour {

	public GameObject camera;
	int PuntMax;
	string Player;
	public TextMesh puntMax;
	public TextMesh jug;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "Pausa");
	}
	
	void Pausa(Notification notificacion){
		Time.timeScale = 0;
		PuntMax = EstadoJuego.estadoJuego.puntuacionMaxima;
		puntMax.text = PuntMax.ToString ();
		Player = EstadoJuego.estadoJuego.jugador;
		Debug.Log ("aqui" + Player.ToString ());
		jug.text = "hola";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

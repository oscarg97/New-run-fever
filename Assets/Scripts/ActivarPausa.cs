﻿using UnityEngine;
using System.Collections;

public class ActivarPausa : MonoBehaviour {

	public GameObject camera;
	int PuntMax;
	public TextMesh puntMax;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "Pausa");
	}
	
	void Pausa(Notification notificacion){
		Time.timeScale = 0;
		PuntMax = EstadoJuego.estadoJuego.puntuacionMaxima;
		puntMax.text = PuntMax.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

//Esta clase es para ganar puntuacion en el juego
public class Puntuacion : MonoBehaviour {

	private int key = 0;
	private int _puntuacion = 0;
	public int puntuacion{
		get { return _puntuacion ^ key; }
		set {
			key = Random.Range(0,int.MaxValue);
			_puntuacion = value ^ key;
		}
	}
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		ActualizarMarcador();
	}
	
	//Es la puntuacion a la base de datos pero pues no se como unir a otra bd que no sea google play
	 void PersonajeHaMuerto(Notification notificacion){
		if(puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima){
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar(true);
		}
		/* 
		// Enviamos a Google Play Games la puntuacion obtenida
		Social.ReportScore(puntuacion, "CgkI1-mG67sBEAIQBg", (bool success) => {});
		
		// Activamos las medallas correspondientes
		if(puntuacion>=25){
			Social.ReportProgress("CgkI1-mG67sBEAIQAQ", 100.0, (bool success) => {});
		}
		if(puntuacion>=50){
			Social.ReportProgress("CgkI1-mG67sBEAIQAg", 100.0, (bool success) => {});
		}		
		if(puntuacion>=100){
			Social.ReportProgress("CgkI1-mG67sBEAIQAw", 100.0, (bool success) => {});
		}	
		if(puntuacion>=150){
			Social.ReportProgress("CgkI1-mG67sBEAIQBA", 100.0, (bool success) => {});
		}	
		if(puntuacion>=200){
			Social.ReportProgress("CgkI1-mG67sBEAIQBQ", 100.0, (bool success) => {});
		}							
	}*/

	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;
		//Debug.Log ("Incrementando " + puntosAIncrementar + " puntos");
		ActualizarMarcador();
	}

	void ActualizarMarcador(){
		marcador.text = puntuacion.ToString();
		//Debug.Log ("marcador actualizado con algo de puntos");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

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
	
	//Es la puntuacion a la base de datos
	 void PersonajeHaMuerto(Notification notificacion){
		if(puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima){
			Debug.Log("Superado. Maxima: "+EstadoJuego.estadoJuego.puntuacionMaxima+" Actual: "+puntuacion);
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar(true);
		}else{
			Debug.Log("No superado. Maxima: "+EstadoJuego.estadoJuego.puntuacionMaxima+" Actual: "+puntuacion);
		}
	}

	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;
		//Debug.Log ("Incrementando " + puntosAIncrementar + " puntos");
		ActualizarMarcador();
	}

	void ActualizarMarcador(){
		marcador.text = puntuacion.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

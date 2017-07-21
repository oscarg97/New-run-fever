using UnityEngine;
using System.Collections;

public class Agregar_Puntos : MonoBehaviour {
	
	public GameObject Server;
	
	string jugador;
	int puntuacion;
	
	void Start(){
		if(gameObject.GetComponent<Conexion>()){
			Server = gameObject;
		}
	}

	void Update(){
		//jugador = EstadoJuego.estadoJuego.jugador;
		//puntuacion = EstadoJuego.estadoJuego.puntuacionMaxima;
		//NotificationCenter.DefaultCenter().AddObserver (this, "GuardarScore");
		//NotificationCenter.DefaultCenter().AddObserver (this, "ObtenerJug");
		ObtenerJug ();
		GuardarScore ();
		//Debug.Log (jugador);
		StartCoroutine (Server.GetComponent<Conexion>().Agregar_Puntos(jugador, puntuacion));
	}

	void GuardarScore(){
		int score = EstadoJuego.estadoJuego.puntuacionMaxima;
		puntuacion = score;
	}

	void ObtenerJug(){
		string nick = EstadoJuego.estadoJuego.jugador;
		jugador = nick;
	}
	
 	/*void OnGUI (){	
		GUILayout.BeginArea(new Rect(Screen.width/4,Screen.height/8,Screen.width/2,Screen.height/2));
		GUILayout.BeginHorizontal();
		GUILayout.Label("NOMBRE : ");	names = GUILayout.TextArea(names);
		GUILayout.Label ("SCORE : "); score = GUILayout.TextArea (score);
		GUILayout.EndHorizontal();
		if(GUILayout.Button("Enviar")){
			StartCoroutine(Server.GetComponent<Conexion>().Agregar_Puntos(names,score));
			names = ""; score = "";
		}
		GUILayout.EndArea();
	}*/
}

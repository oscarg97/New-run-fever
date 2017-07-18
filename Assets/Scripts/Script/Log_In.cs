using UnityEngine;
using System.Collections;

public class Log_In : MonoBehaviour {
	public GameObject Server;
	string jugador = "";
	string password = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI (){

		GUILayout.Space(50);
		GUILayout.Label("Jugador: ");	jugador = GUILayout.TextArea(jugador);
		GUILayout.Label ("Contrasenia: "); password = GUILayout.TextArea (password);
		GUILayout.BeginArea(new Rect(Screen.width/4,Screen.height/8,Screen.width/2,Screen.height/2));
		if(GUILayout.Button("Iniciar Sesion")){
			StartCoroutine(Server.GetComponent<Conexion>().Log_In(jugador,password));
			jugador = ""; password = "";
		}
		GUILayout.EndArea();
	}
}

using UnityEngine;
using System.Collections;

public class Log_In : MonoBehaviour {
	public GameObject Server;
	public GameObject registrarse;
	string jugador = "";
	string password = "";
	string email = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		NotificationCenter.DefaultCenter().AddObserver (this, "SesionScore");
	}
	void SesionScore(Notification jugador2){
		string nomJu = (string)jugador2.data;
		StartCoroutine(Server.GetComponent<Conexion>().Log_In2(nomJu));
	}
	void OnGUI (){//Siempre esta iniciado este metodo
		GUILayout.BeginArea(new Rect(Screen.width/4,Screen.height/4,Screen.width/2,Screen.height/1));
		GUILayout.Space(50);
		GUILayout.Label("Jugador: ");	jugador = GUILayout.TextArea(jugador);
		GUILayout.Label ("Contrasenia: "); password = GUILayout.TextArea (password);
		if(GUILayout.Button("Iniciar Sesion")){//Cuando de click en el boton se pasara al script conexion a validar

			StartCoroutine(Server.GetComponent<Conexion>().Log_In(jugador,password));
		}
		if(GUILayout.Button ("Registrarse")){//Cuando se de al boton de registrarse se cerrara y se abrira un script para registrarse
			registrarse.SetActive(true);
		}
		GUILayout.EndArea();
	}
}

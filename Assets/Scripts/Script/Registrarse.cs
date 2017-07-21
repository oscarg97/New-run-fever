using UnityEngine;
using System.Collections;

public class Registrarse : MonoBehaviour {
	public GameObject Server;
	public GameObject LogIn;
	string jugador = "";
	string password = "";
	string email = "";
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		LogIn.SetActive (false);
	}
	void OnGUI (){
		GUILayout.BeginArea(new Rect(Screen.width/4,Screen.height/5,Screen.width/2,Screen.height/1));
		GUILayout.Space(50);
		GUILayout.Label("Jugador: "); jugador = GUILayout.TextArea(jugador);
		GUILayout.Label ("Contrasenia: "); password = GUILayout.TextArea (password);
		GUILayout.Label("Correo electronico: "); email = GUILayout.TextArea(email);
		if(GUILayout.Button("Registrarse")){
			StartCoroutine(Server.GetComponent<Conexion>().Registrarse(jugador,password,email));
			jugador = ""; password = ""; email="";
			LogIn.SetActive(true);
		}
		
		GUILayout.EndArea();
	}
}

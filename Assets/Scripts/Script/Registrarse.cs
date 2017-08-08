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
		GUILayout.Space(45);
		jugador = GUILayout.TextArea(jugador);
		GUILayout.Space(35);
		password = GUILayout.TextArea (password);
		GUILayout.Space(35);
		email = GUILayout.TextArea(email);
		if(GUILayout.Button("Registrarse")){
			StartCoroutine(Server.GetComponent<Conexion>().Registrarse(jugador,password,email));
			jugador = ""; password = ""; email="";
			LogIn.SetActive(true);
		}
		
		GUILayout.EndArea();
	}
}

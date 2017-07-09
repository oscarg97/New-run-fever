using UnityEngine;
using System.Collections;

public class Agregar_Puntos : MonoBehaviour {
	
	public GameObject Server;
	public static Agregar_Puntos agregarPuntos;
	string nomUsr = "";
	public int score = 0;
	
	void Start(){
		if(gameObject.GetComponent<Conexion>()){
			Server = gameObject;
		}	
	}
	
 	void OnGUI (){
				GUILayout.BeginArea (new Rect (Screen.width / 4, Screen.height / 8, Screen.width / 2, Screen.height / 2));
				GUILayout.BeginHorizontal ();
				GUILayout.Label ("NOMBRE : ");
				nomUsr = GUILayout.TextArea (nomUsr);

				GUILayout.EndHorizontal ();
				if (GUILayout.Button ("Enviar")) {
						StartCoroutine (Server.GetComponent<Conexion> ().Agregar_Puntos (nomUsr, score));
						nomUsr = "";
						score = 10;
				}
				GUILayout.EndArea ();
		}
}
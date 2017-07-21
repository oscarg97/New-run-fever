using UnityEngine;
using System.Collections;

public class visualizar : MonoBehaviour {
	string result = "";
	//public GUISkin Stylo;

	public void ObtenerResultado (string resultado){//Aqui verifica todo
		if(resultado != "Rok!" && resultado.Length > 5){
			//Debug.Log("Nom si " + resultado);
			NotificationCenter.DefaultCenter().PostNotification(this, "Sesion", resultado);//Esta notificacion envia una senial al script BotonIS
		}
		if(resultado == "Rok!"){
			NotificationCenter.DefaultCenter().PostNotification(this, "Sesion", resultado);
		}
		if(int.Parse(resultado)>0){
			//Debug.Log("Punt si " + resultado);
			//NotificationCenter.DefaultCenter().PostNotification(this, "SesionScores", resultado);//Esta notificacion envia una senial al script EstadoJuego
			EstadoJuego.estadoJuego.puntuacionMaxima = int.Parse(resultado);
			NotificationCenter.DefaultCenter().PostNotification(this, "LogIn");
		}
		NotificationCenter.DefaultCenter().PostNotification(this, "LogIn");
	}
	
	/*void OnGUI () {
		GUI.skin = Stylo;
		Rect Posicion = new Rect();
		Posicion = GUI.Window(1,Posicion,Visualizador,"");	
	}
	
	void Visualizador (int WindowID){
		GUI.skin = Stylo;
		GUILayout.Box(result);
	}*/
}

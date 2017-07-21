using UnityEngine;
using System.Collections;

public class BotonIS : MonoBehaviour {
	public GameObject InSe,Reg;
	public GameObject TextStart, TextAlpha, Fondo;
	public TextMesh jugador;
	public static BotonIS IS;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//NotificationCenter.DefaultCenter().AddObserver(this, "Sesion");//Una vez ya hecho todo lo del metodo de abajo, aqui recibe el dato
		NotificationCenter.DefaultCenter().AddObserver(this, "LogIn");
	}

	void OnMouseDown(){//Este metodo es para abrir la ventana para iniciar sesion
		if (gameObject.name == "InSe") {
			InSe.SetActive(true);//InSe es del scrip Log_In
			TextStart.SetActive(false);
			TextAlpha.SetActive(false);
			Fondo.SetActive(true);
		}else if(gameObject.name == "Ex"){
			InSe.SetActive(false);
			Fondo.SetActive (false);
			TextStart.SetActive (true);
			TextAlpha.SetActive (true);
			Reg.SetActive(false);
		}
		audio.Play ();
	}

	public void LogIn(){
		InSe.SetActive(false);
		Fondo.SetActive (false);
		TextStart.SetActive (true);
		TextAlpha.SetActive (true);
	}
	void Sesion(Notification sesion){//Este metodo funciona para verificar y obtener el nombre de usuario
		InSe.SetActive(false);
		Reg.SetActive (false);
		Fondo.SetActive (false);
		TextStart.SetActive (true);
		TextAlpha.SetActive (true);
		string player = (string)sesion.data;
		jugador.text = player;
	}
}

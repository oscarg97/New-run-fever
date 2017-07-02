using UnityEngine;
using System.Collections;

//Esta clase es un movimiento del fondo
public class Scroll : MonoBehaviour {

	public bool IniciarEnMovimiento = false;
	public float velocidad = 0f;
	private bool enMovimiento = false;
	private float tiempoInicio = 0f;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		if (IniciarEnMovimiento) {
			PersonajeEmpiezaACorrer();
		}
	}

	void PersonajeHaMuerto(){
		enMovimiento = false;
	}

	void PersonajeEmpiezaACorrer(){
		enMovimiento = true;
		tiempoInicio = Time.time;//Decimos que el tiempo que la aplicacion esta andando
								 //se almacene un tiempo que estamos parados
	}
	
	// Update is called once per frame
	void Update () {
		if(enMovimiento){
			renderer.material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
			//Una vez que se empieza a correr, hacemos que el fondo se empiece a mover suave
		}
	}
}

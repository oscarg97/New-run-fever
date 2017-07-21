using UnityEngine;
using System.Collections;

//Esta clase progama el salto
public class ControladorPerzonaje : MonoBehaviour {
	public float fuerzaSalto = 20f;

	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprovadorRadio = 0.07f;
	public LayerMask mascaraSuelo;

	private bool dobleSalto = false;
	private Animator animator; //Vinculacion con la animacion

	private bool corriendo = false;
	public float velocidad = 5f;//Velocidad del personaje


	void Awake(){
		animator = GetComponent<Animator> (); //Vinculador con la animacion
		}


	// Use this for initialization
	void Start () {
	
	}

	//Esto nos asegura que se actualizara constantemente
	void FixedUpdate(){
		if (corriendo) {
			rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
				}
		animator.SetFloat ("VelX", rigidbody2D.velocity.x); //Actualiza el personaje a correr
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprovadorRadio, mascaraSuelo);
		animator.SetBool ("isGrounded", enSuelo); //Envia notificacion al animador para animacion
		if (enSuelo) {
			dobleSalto = false;
				}
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if(corriendo){
				//hacemos que salte si puede saltar
				if (enSuelo || !dobleSalto) {
					audio.Play();
					rigidbody2D.velocity= new Vector2 (rigidbody2D.velocity.x, fuerzaSalto);
					//rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
					if(!dobleSalto && !enSuelo){
						dobleSalto = true; //Esto es para que cuando el personaje no este tocando el suelo
										   //pueda saltar una vez mas
					}
				}


			}else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
				//Aqui hago lo mismo para saber que el mono corre y generar los bloques pero a este
				//le puse un PostNotification y para eso ocupo un observador instanciado anteriormente
			}
	             

		}
}
}
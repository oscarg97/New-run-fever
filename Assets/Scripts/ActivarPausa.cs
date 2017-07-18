using UnityEngine;
using System.Collections;

public class ActivarPausa : MonoBehaviour {

	public GameObject camera;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "Pausa");
	}
	
	void Pausa(Notification notificacion){
		Time.timeScale = 0.001f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

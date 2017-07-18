using UnityEngine;
using System.Collections;

public class ActivarPausa : MonoBehaviour {

	public GameObject camaraPausa;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "Pausa");
	}
	
	void Pausa(Notification notificacion){
		//audio.Stop();
		//audio.clip = gameOverClip;
		//audio.loop = false;
		//audio.Play();
		camaraPausa.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

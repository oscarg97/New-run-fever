using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SocialPlatforms;

public class EstadoJuego : MonoBehaviour {
	
	public int puntuacionMaxima;
	public string jugador = "";

	public static EstadoJuego estadoJuego;
	
	private String rutaArchivo;

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		if(estadoJuego==null){
			estadoJuego = this;
			DontDestroyOnLoad(gameObject);
			
			//cloud = new GooglePlayCloud();
			
			//PlayGamesPlatform.DebugLogEnabled = false;
			//PlayGamesPlatform.Activate();
		}else if(estadoJuego!=this){
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar();
		NotificationCenter.DefaultCenter ().AddObserver (this, "Sesion");
		//NotificationCenter.DefaultCenter().PostNotification (this, "SesionScore", jugador);
		//Debug.Log(puntuacionMaxima.ToString());
		//InicioSesionGooglePlay(true);
	}
	
	/*public void InicioSesionGooglePlay(bool silencioso){
		((PlayGamesPlatform)Social.Active).Authenticate((bool success) => {
		if(success){
			cloud.CloudLoad();
		}
		}, silencioso);
	}*/
	
	// Update is called once per frame
	void Update () {
		if (jugador != "") {
			//NotificationCenter.DefaultCenter().AddObserver (this, "Sesion");
			NotificationCenter.DefaultCenter ().PostNotification (this, "SesionScore", jugador);
		}
	}
	
	public void Guardar(bool guardarEnLaNube){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(rutaArchivo);
		
		DatosAGuardar datos = new DatosAGuardar();
		datos.jugador = jugador;
		if(puntuacionMaxima < datos.puntuacionMaxima){
			puntuacionMaxima = datos.puntuacionMaxima;
		}
		//NotificationCenter.DefaultCenter().AddObserver (this, "GuardarScore", puntuacionMaxima);
		//NotificationCenter.DefaultCenter().AddObserver (this, "ObtenerJugador", jugador);

		bf.Serialize(file, datos);
		
		file.Close();
		
		/*if(guardarEnLaNube){
			cloud.CloudSave(datos);
		}*/
	}
	
	void Cargar(){
		if(File.Exists(rutaArchivo)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(rutaArchivo, FileMode.Open);
			
			DatosAGuardar datos = (DatosAGuardar) bf.Deserialize(file);

			jugador = datos.jugador;

			puntuacionMaxima = datos.puntuacionMaxima;
			
			file.Close();
		}else{
		}
	}
	void Sesion(Notification resultado){
		string player = (string)resultado.data;
		jugador = player;
	}
	void SesionScore(int score){
		puntuacionMaxima = score;
	}
}

[Serializable]
class DatosAGuardar{
	public int puntuacionMaxima;
	public string jugador;
}

/*class GooglePlayCloud : GooglePlayGamesCloudHelper<DatosAGuardar>{

	protected override DatosAGuardar ConflictoAlGuardar (int slot, DatosAGuardar local, DatosAGuardar server)
	{
		if(local.puntuacionMaxima > server.puntuacionMaxima){
			return local;
		}else{
			return server;
		}
	}
	protected override void DatosDescargados (int slot, DatosAGuardar data)
	{
		if(data == null) return;
		if(data.puntuacionMaxima > EstadoJuego.estadoJuego.puntuacionMaxima){
			EstadoJuego.estadoJuego.puntuacionMaxima = data.puntuacionMaxima;
			EstadoJuego.estadoJuego.Guardar(false);
		}
	}

}*/
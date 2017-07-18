using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SocialPlatforms;

public class EstadoJuego : MonoBehaviour {

	public int puntuacionMaxima = 0;
	public string puntuacion = "'.$row['puntuacion'].'";
	public string usuario = "'.$row['jugador'].'";
	public string nickname = "YOMEROMERO";
	string key = "ff4ff8ff99s5s1af5as99vc8d1ny8";

	public static EstadoJuego estadoJuego; //Es una variable para saber a que escena del juego se va
	
	private String rutaArchivo;

	void Awake(){ //Este metodo solo se hace refencia a los componentes
		rutaArchivo = Application.persistentDataPath + "/puntuacion.php";
		if(estadoJuego==null){
			estadoJuego = this;
			DontDestroyOnLoad(gameObject);
			/*
			cloud = new GooglePlayCloud();
			
			PlayGamesPlatform.DebugLogEnabled = false;
			PlayGamesPlatform.Activate();*/
		}else if(estadoJuego!=this){
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar();
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
	
	}
	
	//
	public void Guardar(bool guardarEnLaNube){
		//BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(rutaArchivo);
		
		DatosAGuardar datos = new DatosAGuardar();
		datos.puntuacionMaxima = puntuacionMaxima;
		datos.nickname = nickname;
		StreamWriter sw = new StreamWriter(file);
		sw.WriteLine("<?php" +
			"include ('conexion.php');" +
			"$name = $_GET["+nickname+"];" +
			"$score = $_GET["+puntuacion+"];" +
			"$hash = $_GET["+key+"];" +
			"if($hash == "+key+"){" +
			"$query = 'INSERT INTO juego VALUES (NULL, '$name', '$score');';" +
			"$result = mysql_query($query) or die('Query failed: ' . mysql_error());" +
			"}" +
			"?>");
		sw.Close();
		//bf.Serialize(file, datos);
		
		//file.Close();
		
		//if(guardarEnLaNube){
			//cloud.CloudSave(datos);
		//}
	}
	
	void Cargar(){
		if(File.Exists(rutaArchivo)){
			//BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(rutaArchivo, FileMode.Open);
			
			DatosAGuardar datos = new DatosAGuardar(); 
			//bf.Deserialize(file);
			
			puntuacionMaxima = datos.puntuacionMaxima;
			nickname = datos.nickname;
			StreamReader sr = new StreamReader(file);
			sr.ReadToEnd();
			sr.Close();
			//file.Close();
		}else{
			puntuacionMaxima = 0;
		}
	}
}

[Serializable]
class DatosAGuardar{
	public int puntuacionMaxima;
	public string nickname;
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
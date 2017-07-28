using UnityEngine;
using System.Collections;
 
public class Conexion : MonoBehaviour{
    string Agregar_Puntos_PHP = "http://192.168.1.70:8080/run-fever/agregarpuntos.php";
    string Ver_Puntos_PHP = "http://192.168.1.70:8080/run-fever/verpuntos.php";
	string Log_In_PHP = "http://192.168.1.70:8080/run-fever/login.php";
	string Log_In2_PHP = "http://192.168.1.70:8080/run-fever/login2.php";
	string Registrarse_PHP = "http://192.168.1.70:8080/run-fever/registrarse.php";
	
    public IEnumerator Agregar_Puntos(string nombre,int puntos){	
        if(nombre != ""){
			//Debug.Log(nombre +" y "+puntos.ToString());
			string formulario = Agregar_Puntos_PHP + "?jugador=" + nombre + "&puntuacion=" + puntos;		
	        WWW datos = new WWW(formulario); 
			yield return datos;
			if(datos.error != null){
					//print("Error: " + datos.error);		
			}else{
				//print("MejorPunt");
			}
		}else{//print("Sin Nombre");
		}
	}
 
    public IEnumerator Ver_Puntos(string jugador){
		string formulario = Ver_Puntos_PHP + "?jugador=" + jugador;
        WWW verpuntos = new WWW(formulario);
        yield return verpuntos;
 
        if (verpuntos.error != null){
            //print("Error: " + verpuntos.error);
        }
        else{
			//print ("VerPunt");
			gameObject.GetComponent<visualizar>().ObtenerResultado(verpuntos.text); 
        }
    }
	public IEnumerator Log_In(string jugador, string password){
		string formulario = Log_In2_PHP + "?" + "jugador=" + jugador + "&password=" + password;
		WWW login = new WWW (formulario);
		yield return login;
		if (login.error != null) {
			//print ("Error: " + login.error);
		} else {
			//print ("Nombre");
			gameObject.GetComponent<visualizar>().ObtenerResultado (login.text); 
				}
		}
	public IEnumerator Log_In2(string jugador){//Este metodo es para sacar el nombre de usuario de el que se loguee
		string formulario2 = Log_In_PHP + "?" + "jugador=" + jugador;//Es el link completo
		WWW login2 = new WWW (formulario2);//El WWW es para mandarlo al web con todo el link
		yield return login2;
		if (login2.error != null) {
			//print ("Error: " + login2.error);
		} else {
			//print ("Punt");
			gameObject.GetComponent<visualizar>().ObtenerResultado (login2.text); //Valida en el script visualizar
		}
	}
	public IEnumerator Registrarse(string jugador, string password, string email){
		string formulario = Registrarse_PHP + "?" + "jugador=" + jugador + "&password=" + password + "&correo=" + email;
		WWW registrarse = new WWW (formulario);
		yield return registrarse;
		if (registrarse.error != null) {
			//print ("Error: " + registrarse.error);
		} else {
			//print ("Registro");
			gameObject.GetComponent<visualizar>().ObtenerResultado (registrarse.text); 
		}
	}
}
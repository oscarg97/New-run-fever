using UnityEngine;
using System.Collections;
 
public class Conexion : MonoBehaviour{
    string Agregar_Puntos_PHP = "http://192.168.1.174:8080/run-fever/agregarpuntos.php";
    string Ver_Puntos_PHP = "http://192.168.1.174:8080/run-fever/verpuntos.php";
	string Log_In_PHP = "http://192.168.1.174:8080/run-fever/login.php";
	string Seguridad = "ff4ff8ff99s5s1af5as99vc8d1ny8";
	
    public IEnumerator Agregar_Puntos(string nombre,string puntos){	
        if(nombre != ""){
		string formulario = Agregar_Puntos_PHP + "?" + "name=" + nombre + "&score=" + puntos + "&key=" + Seguridad;		
        WWW datos = new WWW(formulario); 
		yield return datos;
		if(datos.error != null) print("Error: " + datos.error); else{ print("Tu Registro fue Exitoso!"); }		
		}else{
			print("No hay nombre!");
		}
    }
 
    public IEnumerator Ver_Puntos(){
        WWW verpuntos = new WWW(Ver_Puntos_PHP);
        yield return verpuntos;
 
        if (verpuntos.error != null){
            print("Error: " + verpuntos.error);
        }
        else{
			print ("Tu peticion Fue Exitosa!");
			gameObject.GetComponent<visualizar>().ObtenerResultado(verpuntos.text); 
        }
    }
	public IEnumerator Log_In(string jugador, string password){
		string formulario = Log_In_PHP + "?" + "jugador=" + jugador + "&password=" + password;
		WWW login = new WWW (formulario);
		yield return login;
		if (login.error != null) {
			print ("Error: " + login.error);
		} else {
			print ("El inicio Fue Exitosa!");
			gameObject.GetComponent<visualizar>().ObtenerResultado (login.text); 
				}
		}
}
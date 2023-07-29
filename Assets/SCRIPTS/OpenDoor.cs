using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;          
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Text text;   //VARIABLE PUBLICA PARA IMPORTAR UN TEXTO QUE EN ESTE CASO SERA EL TEXTO QUE NOS INDIQUE QUE TECLA PRESIONAR
   
    public string levelName;    //VARIABLE PUBLICA PARA INDICAR EL NOMBRE DEL NIVEL EN EL BUILD SETTING
    private bool inDoor = false;    //CON ESTO INDICAMOREMOS SI ESTAMOS O NO EN LA PUERTA PARA PRESIONAR EL BOTON QUE NOS TRASLADE AL NIVEL DESEADO

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.gameObject.CompareTag("Player"))  //COLISION CON EL OBJETO DE ETIQUETA PLAYER
        {
            text.gameObject.SetActive(true);            //ACTIVACION DEL TEXTO
            inDoor = true;                              //HACEMOS VERDADERO QUE ESTAMOS PASANDO POR LA PUERTA
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);               //DESACTIVACION DEL TEXTO
        inDoor = false;                                 //YA NO ESTAMOS PASANDO POR LA PUERTA
        Debug.Log("Pasamos por el trigger");
    }
    private void Update()                               //COMPRBAMOS CONSTANTEMENTE SI ESTAMOS DENTRO DE LA PUERTA PARA PULSAR LA TECLA QUE NOS TRASLADE
    { 
    if(inDoor && Input.GetKey("space"))                 //CODICION DE SI ESTAMOS EN LA PUERTA Y PRESIONAMOS LA TECLA 
    {
        SceneManager.LoadScene((levelName));            //DECLARACIÓN PARA INDICAR QUE NIVEL QUEREMOS PARA TRASLADARNOS
    }
    }
}


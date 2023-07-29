using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
//LOS COMENTARIOS DE COMO VA EL ORDEN ES EN FUSION CON EL SCRIPT PLAYER RESPAWN
 private void OnTriggerEnter2D (Collider2D collision) //1. ENTRAREMOS AL EVENTO TRIGGER DEL COLLIDER
    {
        if(collision.CompareTag("Player")) //2. REALIZARÁ LA COLISION CON LA ETIQUETA PLAYER
        {                                                               
            collision.GetComponent<playerRespawn>().ReachedCheckPoint(transform.position.x,transform.position.y); //6.AQUI MANDAMOS LLAMAR LA FUNCION DE REACHEDCHECKPOINT DEL SCRIPT  PLAYERRESPAWN, en el parentesis dePUES DE .REACHEDCHECKPOINT NO VA NADA POR AHORA.
                                                                    //9. colocamos (transform.position.x,transform.position.y) que vendría siendo la posicion del checkpoint y el punto 8 lo ocupara para que el jugador aparezca EN ESA COORDENADA
            Debug.Log("Checkpoint");
            GetComponent<Animator>().enabled=true; //13. REVISAR MAS ABAJO ESTO
        }
    }

}


/*PARA JUNTAR LAS ANIMACIONES DEL CHECKPOINT
1.HACER TODAS LAS SECUENCIAS DE ANIMACION DEL CHECK, IDLE Y FLAG OUT
2.BORRAR EL CONTROLADOR DEL IDLE Y ABRIR EL DEL FLAG OUT
3.METER LA ANIMACION DEL IDLE EN LA VENTANA ANIMATOR Y TRANSICIONAR DEL FLAG OUT AL IDLE.
4. PONERLE UN COMPONENTE ANIMATOR AL LA IMAGEN DEL MASTIL DEL CHECKPOINT Y EN EL INSPECTOR DESACTIVARLO
Y EN EL CONTROLADOR QUE PIDE EL COMPONENTE ARRASTRAR EL DEL FLAG OUT.
5 EN ESTE MISMO SCRIPT EN NUESTRO METODO IF PONER EL SIGUIENTE CODIGO: GetComponent<Animator>().enabled=true; */


// PARA REINICIAR DESDE EL PUNTO DE PARTIDA Y NO EN EL CHECKPOINT IR A EDIT--> CLEAR ALL PLAYER PREFS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
 public static bool isGrounded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name); //PARA QUE NOS DIGA CON QUE CHOCAMOS
        if(collision.gameObject.name!="Checkpoint" && !collision.gameObject.CompareTag("Pared")) //CONDICION DE SI ES DIFERENTE DE CHECKPOINT NO LO TOME EN CUENTA Y TAMBIEN NO TOME EN CUENTA LOS TOBJ CON TAG DE PARED
        {
        isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name!="Checkpoint" && !collision.gameObject.CompareTag("Pared"))
        {
        isGrounded = false;
        }
    }
}

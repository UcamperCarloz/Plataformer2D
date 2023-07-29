using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerRespawn : MonoBehaviour
{

    private bool isDead = false;  // Variable para controlar si el jugador está muerto o no

    public bool IsDead()
    {
        return isDead;
    }

    public GameObject[] hearts;															//arreglo para tener todos los corazones en uno mismo
    private int life;
    public Animator animator;
    private float checkPointPositionX, checkPointPositionY;
    void Start()
    {
        life = hearts.Length;
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
            //animator.SetBool("isJump",false);
        }
    }

    private void Checklife()            //CON ESTE METODO METEMOS CONDICIONALES PARA CUANDO NUESTRA VIDA SEA MENOR A CIERTA CANTIDAD, SE DESTRUYAN EN ESTE CASO LOS GAMEOBJECTS DE LOS CORAZONES CORRESPONDIENTES
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("DEATH");     //EN EL TUTO TIENE UNA ANIMACION DE QUE EL PERSONAJE RECIBIÓ UN GOLPE Y SE COLOCÓ ESTA LINEA EN LAS 3 CONDICIONS PERO AL SER DE MUERTE LA NUESTRA LA PONDREMOS EN LA ULTIMA VIDA
            Invoke("ReloadScene", 1);                // DE PREFERENCIA CREEMOS UNA ANIMACION DE HIT PARA COLOCARLA EN LAS OTRAS DOS CONDICIONES							
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)

        {
            Destroy(hearts[2].gameObject);
        }
    }
    public void ReachedCheckPoint(float x, float y)

    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        life--;     //FUNCION PARA RESTAR VIDAS
        Checklife(); 		//CON ESTO LLAMAMOS EL METODO DE LAS CONDICIONES
        if (life <= 0)
        {
            isDead=true;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}






/*public class playerRespawn : MonoBehaviour
{

    private bool isDead = false;  // Variable para controlar si el jugador está muerto o no

    public bool IsDead()
    {
        return isDead;
    }

    public Animator animator;
    private float checkPointPositionX, checkPointPositionY;
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }


    public void ReachedCheckPoint(float x, float y)

    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        isDead = true;  // Establece la variable isDead en true cuando el jugador muere
        animator.Play("DEATH");
        Invoke("ReloadScene", 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
*/





















/*
______________________________________________
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRespawn : MonoBehaviour
{
    public Animator animator;
    private float checkPointPositionX, checkPointPositionY;

    private PlayerHealth playerHealth; // Referencia al script PlayerHealth

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        animator.Play("DEATH");
        Invoke("ReloadScene", 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Agrega un método OnCollisionEnter2D o OnTriggerEnter2D (según cómo detectes la colisión) para que el jugador reciba daño al tocar ciertos objetos.
    // Supongamos que al tocar ciertos objetos, el jugador recibe 20 de daño.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            playerHealth.TakeDamage(20f);
        }
    }
}*/



































using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //CON ESTO DAMOS ACCESO A LAS DEMÁS ESCENAS
using UnityEngine.UI; //1T

public class CoinManager : MonoBehaviour
{
    public GameObject hearts;   //VARIABLE PUBLCA PARA COLOCAR EL GRUPO DE LAS VIDAS O HEARTS
    public Text levelCleared; //2T
    public GameObject transition;
    public void Update()
    {
        AllCoinsCollected();
    }
    public void AllCoinsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan monedas, Victoria!");
            levelCleared.gameObject.SetActive(true);//3T.
            Invoke("ChangeScene", 3); //5T
            hearts.SetActive(false);   //AQUI DESACTIVAMOS EL GRUPO DE LAS VIDAS ANTES DE QUE SE CORRA LA TRANSICIÓN A LA SIGUIENTE ESCENA
            transition.SetActive(true);
            
        }
    }
            
            void ChangeScene()//4T
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //AL COLECTAR TODASLAS MONEDAS, NOS MANDA A LA SIGUIENTE ESCENA EN EL ORDEN DEL BUILD SETTINGS
            //ANTES DE CREAR EL TEXTO DE LEVEL CLEAR ESTO ESTABA EN EL METODO IF PERO PARA PODER APRECIAR EL TEXTO DELEVEL CLEAR LO PASAMOS A UN METODO INDEPENDIENTE PARA QUE NO NOS MANDE A LA SIGUIENTE ESCENA DE GOLPE.
            }
}



/*COMO COLOCAR UN TEXTO DE QUE COMPLETMOS EL NIVEL(EN ESTE CASO AL COLECTAR LAS MONEDAS)
0T CREAMOS NUESTRO TEXTO, MODIFICAMOS POSICION FUENTE,TEXTO,NOMBRE DEL OBJETO.
1T. IMPORTAR BIBLIOTECA UI.
2T. CREAMOS VARIABLE PARA IMPORTAR UN OBJETO DE TEXTO
3T. EN EL INSPECTOR DESACTIVAMOS EL OBJETO TEXTO Y CON ESTA LINEA DECLARAMOS SU ACTIVACIÓN AL COMPLETAR EL NIVEL
4T CREAMOS ESTE METODO PARA AISLAR EL CAMBIO DE ESCENA PARA APRECIAR EL TEXTO EL TIEMPO QUE DETERMINEMOS POSTERIORMENTE
5T. CON EL METODO INVOKE POSPONEMOS UN TIEMPO DETERMINADO LA LINE DENTRO DE VOID CHANGE SCENE PARA APRECIAR EL TEXTO.*/
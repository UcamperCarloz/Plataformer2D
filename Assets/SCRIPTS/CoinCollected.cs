using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinCollected : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
          //  FindObjectOfType<CoinManager>().AllCoinsCollected(); "LO BORRAMOS AL CREAR EL UPDATE EN COINMANAGER  PARA ASÍ SOLUCIONAR AL TOMAR 2 O MAS MONEDAS A LA VEZ Y ASÍ APAREZCA EL MENSAJE"
            Destroy(gameObject, 0.4f);

        }
    }
}

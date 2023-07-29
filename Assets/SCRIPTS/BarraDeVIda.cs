using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVIda : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

   public void CambiarVidaMaxima(float vidaMaxima)
   {
    slider.maxValue=vidaMaxima;

   }
   public void CambiarVidaActual(float cantidadVida)
   {
    slider.value=cantidadVida;
   }
    public void IncializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaActual(cantidadVida);
        CambiarVidaMaxima(cantidadVida);
    }
}

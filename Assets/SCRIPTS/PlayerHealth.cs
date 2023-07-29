using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public BarraDeVIda healthBar; // Referencia al script de la barra de vida

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.IncializarBarraDeVida(maxHealth); // Inicializa la barra de vida con el valor máximo al inicio
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // Para asegurarse de que la salud no sea menor a 0 ni mayor a la máxima

        healthBar.CambiarVidaActual(currentHealth); // Actualiza el valor actual en la barra de vida

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Coloca aquí las acciones que deben suceder cuando el jugador muere
        // Por ejemplo, puedes llamar al método PlayerDamaged() del script playerRespawn para que el jugador reaparezca en el último checkpoint.
        GetComponent<playerRespawn>().PlayerDamaged();
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LuciernagaScript : MonoBehaviour
{
    [SerializeField] private Light2D luciernaga;
    [SerializeField] private float intervalo = 2f;     // Tiempo entre movimientos
    [SerializeField] private float rango = 2f;         // Rango de movimiento
    [SerializeField] private float velocidad = 2f;     // Velocidad de desplazamiento

    private Vector3 posicionInicial;
    private Vector3 destinoActual;
    private bool yendoAHaciaDestino = false;

    private void Start()
    {
        posicionInicial = transform.position;
        StartCoroutine(CambiarDestinoPeriodicamente());
    }

    private void Update()
    {
        if (yendoAHaciaDestino)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidad * Time.deltaTime);

            // Si ya llegó al destino, dejar de moverse
            if (Vector3.Distance(transform.position, destinoActual) < 0.05f)
            {
                yendoAHaciaDestino = false;
            }
        }
    }

    private IEnumerator CambiarDestinoPeriodicamente()
    {
        while (true)
        {
            // Elegir nueva posición dentro del rango
            destinoActual = posicionInicial + new Vector3(
                Random.Range(-rango, rango),
                Random.Range(-rango, rango),
                0f
            );

            yendoAHaciaDestino = true;

            // Esperar antes de cambiar de destino nuevamente
            yield return new WaitForSeconds(intervalo);
        }
    }
}

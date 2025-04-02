using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ControllerDayNightCycle : MonoBehaviour
{
    [SerializeField] private Light2D generalLight;
    [SerializeField] private Light2D windowLight;
    [SerializeField] private DayNightCycle[] dayNightCycle;
    [SerializeField] private float timePerCycle; // en segundos
    private float currentCycleTime = 0;
    private float percentageCycle;
    private int currentCycle = 0;
    private int nextCycle = 1;

    private void Start()
    {
        generalLight.color = dayNightCycle[0].colorCycle;
        verificarLuzVentana();
        
    }

    private void Update()
    {
        currentCycleTime += Time.deltaTime;
        percentageCycle = currentCycleTime / timePerCycle;

        if (currentCycleTime >= timePerCycle)
        {
            currentCycleTime = 0;
            currentCycle = nextCycle;

            if (nextCycle + 1 > dayNightCycle.Length - 1 )
            {
                nextCycle = 0;
            }
            else
            {
                nextCycle += 1;
            }
            verificarLuzVentana();
        }

        // cambiar el color
        cambiarColor(dayNightCycle[currentCycle].colorCycle, dayNightCycle[nextCycle].colorCycle);
    }

    private void cambiarColor(Color colorActual, Color siguienteColor)
    {
        generalLight.color = Color.Lerp(colorActual, siguienteColor, percentageCycle);
    }

    private void verificarLuzVentana()
    {
        if (dayNightCycle[currentCycle].nameCycle == "esMañana")
        {
            windowLight.enabled = true;
        }
        else
        {
            windowLight.enabled = false;    
        }
    }
}

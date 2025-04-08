using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;



public class ControllerDayNightCycle : MonoBehaviour
{
    [SerializeField] private Light2D generalLight; // luz general
    [SerializeField] private Light2D[] windowsLight;
    [SerializeField] private Color colorTransparente;
    [SerializeField] private Color colorVisible;
    [SerializeField] private DayNightCycle[] dayNightCycle; // ciclos del dia
    [SerializeField] private float timePerCycle; // cuanto tarda cada ciclo en segundos
    private float currentCycleTime = 0;// tiempo actual del ciclo
    private float percentageCycle;// porcentaje del cliclo se usa en el cambio de color 
    private int currentCycle = 0;// ciclo actual
    private int nextCycle = 1;// siclo siguiente

    public event EventHandler<OnNightEventArgs> OnNight;
    public class OnNightEventArgs : EventArgs
    {
        public string nombreCiclo;
    }
    private void Start()
    {
        generalLight.color = dayNightCycle[0].colorCycle;
        verificarLuzVentana();
        colorTransparente = new Color(1f,1f,0f,0f);
        colorVisible = new Color(1f,1f,0f,1f);
        
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
            
        }
       
        OnNight?.Invoke(this, new OnNightEventArgs { nombreCiclo = dayNightCycle[currentCycle].nameCycle });
        
        // cambiar el color
        cambiarColor(dayNightCycle[currentCycle].colorCycle, dayNightCycle[nextCycle].colorCycle);
        verificarLuzVentana();
    }

    private void cambiarColor(Color colorActual, Color siguienteColor)
    {
        generalLight.color = Color.Lerp(colorActual, siguienteColor, percentageCycle);
    }

    private void verificarLuzVentana()
    {
        if (dayNightCycle[currentCycle].nameCycle == "sunrise")
        {
            foreach (var item in windowsLight)
            {
                item.color = Color.Lerp(colorTransparente, colorVisible, percentageCycle);
            }
            
        }

        if (dayNightCycle[currentCycle].nameCycle == "day")
        {
            foreach (var item in windowsLight)
            {
                item.color = Color.Lerp(colorVisible, colorTransparente, percentageCycle);
            }
            
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HallwayLight : MonoBehaviour
{
    [SerializeField] private Light2D luzPasillo;
    private ControllerDayNightCycle controladorDiaNoche;
    private void Start()
    {
        controladorDiaNoche = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControllerDayNightCycle>();
        controladorDiaNoche.OnNight += EncenderLuzPasillo;
    }

    private void EncenderLuzPasillo(object sender, ControllerDayNightCycle.OnNightEventArgs e)
    {

        if (e.nombreCiclo == "night" || e.nombreCiclo == "midnight")
        {
            luzPasillo.enabled = true;
        }
        else
        {
            luzPasillo.enabled = false;
        }
    }
}

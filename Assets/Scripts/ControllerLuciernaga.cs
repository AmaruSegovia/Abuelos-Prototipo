using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ControllerLuciernaga : MonoBehaviour
{
    [SerializeField] private Light2D[] luciernagas;
    private ControllerDayNightCycle controladorDiaNoche;
    private void Start()
    {
        controladorDiaNoche = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControllerDayNightCycle>();
        controladorDiaNoche.OnNight += EncenderLuzPasillo;
    }


    private void EncenderLuzPasillo(object sender, ControllerDayNightCycle.OnNightEventArgs e)
    {
        if (e.nombreCiclo == "night" || e.nombreCiclo == "midnight" || e.nombreCiclo == "dawn")
        {
            foreach (var luciernaga in luciernagas)
            {
                luciernaga.enabled = true;
            }
        }
        else
        {
            foreach (var luciernaga in luciernagas)
            {
                luciernaga.enabled = false;
            }
        }
    }
}

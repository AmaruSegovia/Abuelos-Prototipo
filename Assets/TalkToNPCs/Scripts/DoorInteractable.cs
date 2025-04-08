using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Tilemap tilemap;
    bool estaAdentro = false; // Variable para controlar la opacidad
    [SerializeField] private string interactText;
    [SerializeField] private Transform posicionAfuera;
    [SerializeField] private Transform posicionAdentro;

    private void Awake()
    {
    }
    public void Interact(Transform interactorTransform) // cuando el jugador presiona E
    {
        Color color = tilemap.color;
        if (!estaAdentro)
        {
            color.a = 0f;
            tilemap.color = color;
            interactorTransform.position = posicionAdentro.position;
            estaAdentro = true;
        }
        else
        {
            color.a = 1f;
            tilemap.color = color;
            interactorTransform.position = posicionAfuera.position;
            estaAdentro = false;
        }
    }
    public void OnPlayerNearby() // cuando el jugador esta cerca
    {

    }

    public void OnPlayerFar() // cuando el jugador se aleja
    {

    }


    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Interact(Transform interactorTransform) // cuando el jugador presiona E
    {
        Debug.Log("bla bla bla");
        spriteRenderer.color = Color.red;
    }

    public void OnPlayerNearby() // cuando el jugador esta cerca
    {
        Debug.Log("hola");
        spriteRenderer.color = Color.yellow;
    }

    public void OnPlayerFar() // cuando el jugador se aleja
    {
        Debug.Log("chau");
        spriteRenderer.color = Color.white;
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

using UnityEngine;

public class WheelchairInteractable : MonoBehaviour, IInteractable
{
    private string interactText;
    private SpriteRenderer spriteRenderer;
    private bool isCarried = false;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isCarried = false;
    }

    public void Interact(Transform interactorTransform)
    {
        spriteRenderer.color = Color.red;

        if (!isCarried)
        {
            transform.SetParent(interactorTransform);
            transform.localPosition = new Vector3(0f, -1.5f, 0f);
            isCarried = true;
        }
        else
        {
            transform.SetParent(null);
            isCarried = false;
        }
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
        return isCarried ? "Dejarlo XD" : "Llevar al señor";
    }

    public Transform GetTransform()
    {
        return transform;
    }
}

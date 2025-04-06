using UnityEngine;
using UnityEngine.Tilemaps;

public class OcultarPared : MonoBehaviour
{
    private Tilemap tilemap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        
    }

    private void CambiarOpacidad(float num)
    {
        Color color = tilemap.color;
        color.a = num;
        tilemap.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CambiarOpacidad(0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CambiarOpacidad(1);
        }

    }

}

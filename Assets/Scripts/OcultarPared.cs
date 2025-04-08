using UnityEngine;
using UnityEngine.Tilemaps;

public class OcultarPared : MonoBehaviour
{
    [SerializeField]  Tilemap tilemap;
    bool bandera = true; // Variable para controlar la opacidad

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
}

    private void cambiarOpacidad()
    {

        Color color = tilemap.color;
        if (bandera)
        {
            color.a = 0f;
            tilemap.color = color;
            bandera = false;
        }
        else
        {
            color.a = 1f;
            tilemap.color = color;
            bandera = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cambiarOpacidad();
        }
    }

}

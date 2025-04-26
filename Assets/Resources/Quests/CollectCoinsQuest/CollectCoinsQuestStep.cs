using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CollectCoinsQuestStep : QuestStep
{
    private int coinsCollected = 0;
    private int coinsToComplete = 5;


    private void OnEnable()
    {
        // nos suscribimos al evento de coleccion de monedas mientras este activado este objeto
        GameEventsManager.instance.miscEvents.onCoinCollected += CoinCollected;
    }   
    private void OnDisable()
    {
        // nos desuscribimos del evento de coleccion de monedas cuando se desactiva este objeto
        GameEventsManager.instance.miscEvents.onCoinCollected -= CoinCollected;
    }

    private void CoinCollected()
    {
        if(coinsCollected < coinsToComplete)
        {
            coinsCollected++;
        }
        if (coinsCollected >= coinsToComplete) // verificamos si el objetivo se completo
        {
            Debug.Log("¡Objetivo completado!");
            FinishedStepQuest(); //llamamos a la funcion que termina el paso de la mision
        }
    }
}

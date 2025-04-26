using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
private bool isFinished = false; // Indica si el paso de la misi�n ha sido completado.

    protected void FinishedStepQuest()
    {
        if (!isFinished) 
        isFinished = true; // Cambia el estado a "completado" para evitar que se complete varias veces.

        //aqui va algo :v
        Destroy(this.gameObject);
    }
}

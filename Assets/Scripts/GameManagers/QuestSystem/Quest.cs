using UnityEngine;

public class Quest
{
    public QuestInfoSO info; // Información de la misión (almacenada en un ScriptableObject).
    public QuestState state; // Estado actual de la misión (por ejemplo, en progreso, completada, etc.).
    private int currentQuestStepIndex; // Índice del paso actual de la misión.

    public Quest(QuestInfoSO questInfo)
    {
        this.info = questInfo; // Asigna la información de la misión.
        this.state = QuestState.REQUERIMENTS_NOT_MET; // Inicializa el estado como "requisitos no cumplidos".
        this.currentQuestStepIndex = 0; // Comienza en el primer paso de la misión.
    }


    public void MoveToNextStep()
    {
        this.currentQuestStepIndex++; // Aumenta el índice del paso actual.
    }


    public bool CurrentStepExist()
    {
        return (currentQuestStepIndex < info.questStepPrefabs.Length);
        // retorna "true" si el índice actual (currentQuestStepIndex) es menor que la longitud del array de pasos (questStepPrefabs)
        // lo que significa que faltan más pasos para completar la mision.
    }


    // sirve para instanciar el prefab del paso actual de la misión en un objeto padre especificado (parentTransform).
    public void InstantiateCurrentQuestStep(Transform parentTransform)
    {
        GameObject questStepPrefab = GetCurrentQuestStepPrefab(); //Obtiene el prefab del paso de quest actual.
        if(questStepPrefab != null)
        {
            Object.Instantiate <GameObject>(questStepPrefab, parentTransform); //Instancia el prefab del paso de quest actual en el padre especificado.
        }
        else
        {
            Debug.LogError("Quest step prefab is null.");
        }
    }

    //Obtiene el prefab del paso actual de la misión.
    private GameObject GetCurrentQuestStepPrefab()
    {
        GameObject questStepPrefab = null;

        //Verificamos si el paso actual existe 
        if (CurrentStepExist())
        {
            //Si existe asignamos el prefab correspondiente al índice actual (currentQuestStepIndex) desde el array questStepPrefabs.
            questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
        }
        else
        {
            Debug.LogError("No more quest steps available.");
        }
        return questStepPrefab;
    }
}

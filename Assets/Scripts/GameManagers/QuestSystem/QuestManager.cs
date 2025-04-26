using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Dictionary<string, Quest> questMap; // Mapa de misiones donde la clave es el ID de la misión y el valor es el objeto Quest.

    private void Awake()
    {
        questMap = CreateQuestMap(); // Inicializa el mapa de misiones al cargar el script.
        Quest quest = GetQuestById("CollectCoinsQuest");
        Debug.Log(quest.info.displayName);
        Debug.Log(quest.info.levelRequirement);
        Debug.Log(quest.state);
        Debug.Log(quest.CurrentStepExist());
    }
    private Dictionary<string, Quest> CreateQuestMap()
    {
        {
            QuestInfoSO[] questInfoArray = Resources.LoadAll<QuestInfoSO>("Quests"); // Cargar todos los ScriptableObjects de misiones desde la carpeta "Resources/Quests".
            Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>(); // Crear un mapa de misiones utilizando el ID como clave.
            foreach (QuestInfoSO questInfo in questInfoArray) // Llenar el mapa con las misiones cargadas.
            {
                if (idToQuestMap.ContainsKey(questInfo.id)) // Verificar si la misión ya existe en el mapa.
                                                            // Si la misión ya existe, se ignora y se continúa con la siguiente.
                {
                    Debug.LogError($"Quest with id {questInfo.id} already exists.");
                    continue;
                }
                idToQuestMap.Add(questInfo.id, new Quest(questInfo));
            }
            return idToQuestMap; // Retornar el mapa de misiones.
        }
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null)
        {
            Debug.LogError($"Quest with id {id} not found.");
        }
        return quest;
    }
}

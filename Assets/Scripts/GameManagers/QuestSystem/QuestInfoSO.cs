using UnityEngine;


[CreateAssetMenu(fileName = "QuestInfoSO", menuName ="ScriptableObjects/QuestInfoSO", order =1)] //para crear una nueva instancia de QuestInfoSO
public class QuestInfoSO : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; } // ID de la misión, se asigna automáticamente al nombre del ScriptableObject.

    [Header("General")]
    public string displayName; // Nombre de la misión que se mostrará al jugador.

    [Header("Requirements")]
    public int levelRequirement; // Nivel mínimo requerido para aceptar la misión.
    public QuestInfoSO[] questPrerequisites; // Misiones previas que deben completarse antes de aceptar esta misión.

    [Header("Steps")]
    public GameObject[] questStepPrefabs; // Prefabs de los pasos de la misión. Se instanciarán en el orden en que aparecen en el array.

    [Header("Rewards")]
    public int goldReward;  // Recompensa de oro al completar la misión.
    public int experienceReward; // Recompensa de experiencia al completar la misión.
    private void OnValidate()
    {
#if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
        /* Cuando editas el ScriptableObject en el editor de Unity, el método OnValidate()
se llama automáticamente. Este método actualiza el campo id para que coincida 
con el nombre del ScriptableObject.*/

    }
}

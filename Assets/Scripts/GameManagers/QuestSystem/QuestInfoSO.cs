using UnityEngine;


[CreateAssetMenu(fileName = "QuestInfoSO", menuName ="ScriptableObjects/QuestInfoSO", order =1)] //para crear una nueva instancia de QuestInfoSO
public class QuestInfoSO : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; } // ID de la misi�n, se asigna autom�ticamente al nombre del ScriptableObject.

    [Header("General")]
    public string displayName; // Nombre de la misi�n que se mostrar� al jugador.

    [Header("Requirements")]
    public int levelRequirement; // Nivel m�nimo requerido para aceptar la misi�n.
    public QuestInfoSO[] questPrerequisites; // Misiones previas que deben completarse antes de aceptar esta misi�n.

    [Header("Steps")]
    public GameObject[] questStepPrefabs; // Prefabs de los pasos de la misi�n. Se instanciar�n en el orden en que aparecen en el array.

    [Header("Rewards")]
    public int goldReward;  // Recompensa de oro al completar la misi�n.
    public int experienceReward; // Recompensa de experiencia al completar la misi�n.
    private void OnValidate()
    {
#if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
        /* Cuando editas el ScriptableObject en el editor de Unity, el m�todo OnValidate()
se llama autom�ticamente. Este m�todo actualiza el campo id para que coincida 
con el nombre del ScriptableObject.*/

    }
}

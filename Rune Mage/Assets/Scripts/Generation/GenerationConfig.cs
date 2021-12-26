using UnityEngine;

using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "GenerationConfig", menuName = "Ruinum/Data/Generation/GenerationConfig")]
public class GenerationConfig : ScriptableObject
{
    [Header("General Settings")]
    public int MaxRoomAmount;
    public float GenerationTime;

    [Header("Secret Room Settings")]
    public bool Constant;
    [HideIf("Constant"), Tooltip("Value on which roomAmount will divide to calculate secret rooms")]
    public int SecretsDivide;
    [ShowIf("Constant")]
    public int SecretsAmount;

    [Header("Prefabs")]
    public GameObject WallPrefab;
    public GameObject SecretWallPrefab;

    [Header("Boss Room Prefabs")]
    public GridRoom Boss_1;
}

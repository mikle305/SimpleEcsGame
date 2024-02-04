using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Configs/Player", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
    }
}
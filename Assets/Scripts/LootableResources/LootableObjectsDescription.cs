using UnityEngine;

namespace LootableResources
{
    [CreateAssetMenu(menuName = "Create LootableObjectsDescription", fileName = "LootableObjectsDescription", order = 0)]
    public class LootableObjectsDescription : ScriptableObject
    {
        public LootableObjectDescription[] LootableObjects;
    }
}
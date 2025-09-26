using System;
using UnityEngine;

namespace LootableResources
{
    [Serializable]
    public class LootableObjectChancesRange
    {
        public int GradableItemLevel;
        public Vector2Int FromToChanceResourcesCount;
        public Vector2Int FromToChanceResourceCount;
    }
}
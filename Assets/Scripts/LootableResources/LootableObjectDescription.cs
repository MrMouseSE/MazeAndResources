using System;

namespace LootableResources
{
    [Serializable]
    public class LootableObjectDescription
    {
        public LootableObjectsGrades Grade;
        public LootableObjectChancesRange[] Chances;
    }
}
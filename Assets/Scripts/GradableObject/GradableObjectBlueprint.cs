using System.Collections.Generic;
using GradableObjectReference;

namespace GradableObject
{
    public class GradableObjectBlueprint
    {
        public GradableObjectDescription GradableObjectReferenceDescription;
        public Dictionary<GradableObjectData, int> GradableObjectRecipe;
        public Dictionary<string, int> GradableObjectRecipeReference;
        public int CurrentAdditionalProperties;
        public List<GradableObjectData> AdditionalPropertyObjects;

        public void UpdateAdditionalPropertiesCount(int additionalPropertiesCount)
        {
            CurrentAdditionalProperties = additionalPropertiesCount;
        }

        public void AddGradableObjectToRecipe(GradableObjectData gradableObjectData)
        {
            if (!GradableObjectRecipe.TryAdd(gradableObjectData, 1)) GradableObjectRecipe[gradableObjectData]++;
        }

        public bool TryToRemoveObjectFromRecipe(GradableObjectData gradableObjectData)
        {
            if (!GradableObjectRecipe.ContainsKey(gradableObjectData)) return false;
            GradableObjectRecipe.Remove(gradableObjectData);
            return true;

        }

        public void AddAdditionalObject(GradableObjectData additionalObject)
        {
            AdditionalPropertyObjects.Add(additionalObject);
        }

        public void RemoveAdditionalObject(GradableObjectData additionalObject)
        {
            AdditionalPropertyObjects.Remove(additionalObject);
        }
    }
}

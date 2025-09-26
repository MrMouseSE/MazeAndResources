using System.Collections.Generic;
using GradableObject;

namespace ResourceHolder
{
    public static class ResourceHandler
    {
        public static Dictionary<string, int> CurrentResources;

        public static bool CheckBlueprintResources(GradableObjectBlueprint blueprint)
        {
            bool canBeCreated = true;
            Dictionary<string, int> currentResourcesToRemove = new Dictionary<string, int>();
            foreach (var resource in blueprint.GradableObjectRecipeReference)
            {
                currentResourcesToRemove.Add(resource.Key, resource.Value);
            }

            foreach (var resource in blueprint.AdditionalPropertyObjects)
            {
                if (!currentResourcesToRemove.TryAdd(resource.GradableObjectName, 1))
                    currentResourcesToRemove[resource.GradableObjectName] += 1;
            }
            
            foreach (var resource in currentResourcesToRemove)
            {
                canBeCreated &= CheckResourceAvailability(resource.Key, resource.Value);
            }
            
            return canBeCreated;
        }

        public static bool CheckResourceAvailability(string resourceName, int additionalPropertiesCount)
        {
            return CurrentResources.ContainsKey(resourceName) && CurrentResources[resourceName] > additionalPropertiesCount;
        }

        public static void DecreaseResourcesByBlueprint(GradableObjectBlueprint blueprint)
        {
            foreach (var resource in blueprint.GradableObjectRecipeReference)
            {
                DecreaseCurrentResources(resource.Key, resource.Value);
            }
        }

        public static void DecreaseCurrentResources(string resourceName, int additionalPropertiesCount)
        {
            CurrentResources[resourceName] -= additionalPropertiesCount;
        }

        public static void IncreaseCurrentResources(string resourceName, int additionalPropertiesCount)
        {
            if(!CurrentResources.TryAdd(resourceName, additionalPropertiesCount))
                CurrentResources[resourceName] += additionalPropertiesCount;
        }
    }
}
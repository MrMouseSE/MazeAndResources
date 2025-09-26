using System.Collections.Generic;
using GradableObject;
using GradableObjectReference;

namespace Factories
{
    public static class GradableObjectStaticFactory
    {
        public static GradableObjectModel CreateGradableObjectModel(GradableObjectDescription description,
            int additionalPropertiesCount)
        {
            GradableObjectBlueprint gradableObjectBlueprint = CreateGradableObjectBlueprint(description,
                additionalPropertiesCount);
            GradableObjectModel gradableObjectModel = new GradableObjectModel(gradableObjectBlueprint);
            return gradableObjectModel;
        }

        public static GradableObjectBlueprint CreateGradableObjectBlueprint(GradableObjectDescription description, 
            int additionalPropertiesCount)
        {
            GradableObjectBlueprint gradableObjectBlueprint = new GradableObjectBlueprint
            {
                GradableObjectReferenceDescription = description,
                GradableObjectRecipe = new Dictionary<GradableObjectData, int>(),
                GradableObjectRecipeReference = description.GradableObjectRecipe,
                CurrentAdditionalProperties = additionalPropertiesCount,
                AdditionalPropertyObjects = new List<GradableObjectData>()
            };
            return gradableObjectBlueprint;
        }
    }
}
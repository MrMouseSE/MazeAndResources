
namespace GradableObject
{
    public class GradableObjectModel
    {
        public GradableObjectData ObjectData;
        public GradableObjectBlueprint ObjectBlueprintCreatedFrom;
        
        public GradableObjectModel(GradableObjectBlueprint objectBlueprintCreatedFrom)
        {
            ObjectBlueprintCreatedFrom = objectBlueprintCreatedFrom;
            ObjectData = objectBlueprintCreatedFrom.GradableObjectReferenceDescription.
                    GetObjectData(objectBlueprintCreatedFrom.CurrentAdditionalProperties);
        }
    }
}
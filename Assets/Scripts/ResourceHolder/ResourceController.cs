using GradableObject;

namespace ResourceHolder
{
    public class ResourceController
    {
        public GradableObjectBlueprint CurrentGradableObjectBlueprint;

        public bool TryCreateNewGradableObject()
        {
            bool isProcess = ResourceHandler.CheckBlueprintResources(CurrentGradableObjectBlueprint);
            
            if (!isProcess) return false;
            
            ResourceHandler.DecreaseResourcesByBlueprint(CurrentGradableObjectBlueprint);

            return true;
        }

        public void SetCurrentGradableObjectBlueprint(GradableObjectBlueprint newGradableObjectBlueprint)
        {
            CurrentGradableObjectBlueprint = newGradableObjectBlueprint;
        }
    }
}
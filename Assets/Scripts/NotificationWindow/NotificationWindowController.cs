using LootableResources;

namespace NotificationWindow
{
    public class NotificationWindowController : IGradableMechanicColroller
    {
        public void UpdateGradableMechanicController(DummyEntryPoint context, float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void ShowNotification(LootableObjectModel lootableObjectModel)
        {
            lootableObjectModel.OnLootGenerated -= this.ShowNotification;
        }
    }
}
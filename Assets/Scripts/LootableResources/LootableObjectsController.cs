using System.Collections.Generic;
using NotificationWindow;
using UnityEngine;

namespace LootableResources
{
    public class LootableObjectsController : IGradableMechanicColroller
    {
        public List<LootableObjectContainer> LootableObjectContainers;
        public List<LootableObjectModel> LootableObjectModels;
        
        public List<LootableObjectModel> CurrentRoomLootableObjectModels;

        public void AddLootableObjectContainers(List<LootableObjectContainer> lootableObjectContainer)
        {
            LootableObjectContainers.AddRange(lootableObjectContainer);
            foreach (var container in LootableObjectContainers)
            {
                GenerateLootableObjectModel(container);
            }
        }

        public void GenerateLootableObjectModel(LootableObjectContainer lootableObjectContainer)
        {
            LootableObjectModels.Add(new LootableObjectModel(lootableObjectContainer, DummyEntryPoint.LootableObjectsDescription,
                DummyEntryPoint.GradableObjectsSOHolder));
        }

        public void UpdateCurrentRoomLootableObjectModel(int roomId)
        {
            CurrentRoomLootableObjectModels = LootableObjectModels.FindAll(x=>x.ObjectContainer.RoomId == roomId);
        }

        public void UpdateGradableMechanicController(DummyEntryPoint context, float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UseNearestLootableObjectIfPossible(context);
            }
        }

        private void UseNearestLootableObjectIfPossible(DummyEntryPoint context)
        {
            float nearestDistance = float.MaxValue;
            LootableObjectModel closestLootableObject = null;
            foreach (var currentRoomLootableObjectModel in CurrentRoomLootableObjectModels)
            {
                Vector3 objectTransformPosition = currentRoomLootableObjectModel.ObjectContainer.ObjectTransform.position 
                                                  - context.PlayerTransform.position;
                if (!(objectTransformPosition.magnitude < nearestDistance)) continue;
                nearestDistance = objectTransformPosition.magnitude;
                closestLootableObject = currentRoomLootableObjectModel;
            }

            if (closestLootableObject == null) return;
            NotificationWindowController windowController = context.GetControllerByType(typeof (NotificationWindowController)) as NotificationWindowController;
            if (!closestLootableObject.IsLootGenerated)
            {
                closestLootableObject.ObjectContainer.Open();
                closestLootableObject.OnLootGenerated += windowController.ShowNotification;
            }
            else
            {
                windowController.ShowNotification(closestLootableObject);
            }
        }
    }
}
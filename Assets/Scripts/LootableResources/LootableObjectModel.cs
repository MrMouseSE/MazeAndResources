using System;
using System.Collections.Generic;
using Factories;
using GradableObject;
using GradableObjectReference;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LootableResources
{
    public class LootableObjectModel
    {
        public LootableObjectContainer ObjectContainer;
        public bool IsLootGenerated;
        public Dictionary<string, List<GradableObjectModel>> LootableObjects;

        private GradableObjectsSOHolder _gradableObjectsSoHolder;
        private LootableObjectChancesRange[] Chances;

        public Action<LootableObjectModel> OnLootGenerated;

        public LootableObjectModel(LootableObjectContainer objectContainer, LootableObjectsDescription lootableObjectsDescription,
            GradableObjectsSOHolder gradableObjectsSoHolder)
        {
            ObjectContainer = objectContainer;
            ObjectContainer.OnAnimationFinish += GenerateLoot;
            foreach (var lootableObject in lootableObjectsDescription.LootableObjects)
            {
                if (lootableObject.Grade == ObjectContainer.Grade)
                {
                    Chances = lootableObject.Chances;
                }
            }
            _gradableObjectsSoHolder = gradableObjectsSoHolder;
        }

        public void GenerateLoot()
        {
            LootableObjects = new Dictionary<string, List<GradableObjectModel>>();
            
            foreach (var chancesRange in Chances)
            {
                int resourcesCount = GetCountFromRange(chancesRange.FromToChanceResourcesCount);
                List<GradableObjectScriptableObject> thisLevelItems = 
                    _gradableObjectsSoHolder.GetGradableObjectsByLevel(chancesRange.GradableItemLevel);
                for (int i = 0; i < resourcesCount; i++)
                {
                    GradableObjectScriptableObject gradableObjectSO = thisLevelItems[Random.Range(0, thisLevelItems.Count)];
                    int resourceCount = GetCountFromRange(chancesRange.FromToChanceResourceCount);
                    for (int j = 0; j < resourceCount; j++)
                    {
                        GradableObjectModel gradableObjectModel =
                            GradableObjectStaticFactory.CreateGradableObjectModel(gradableObjectSO.Description, 
                                int.MaxValue);
                        if (LootableObjects.ContainsKey(gradableObjectModel.ObjectData.GradableObjectName))
                        {
                            LootableObjects[gradableObjectModel.ObjectData.GradableObjectName].Add(gradableObjectModel);
                        }
                        else
                        {
                            LootableObjects.Add(
                                gradableObjectModel.ObjectData.GradableObjectName,
                                new List<GradableObjectModel>{ gradableObjectModel }
                                );
                        }
                    }
                }
            }

            IsLootGenerated = true;
            OnLootGenerated?.Invoke(this);
        }

        public void OnDestroy()
        {
            ObjectContainer.OnAnimationFinish -= GenerateLoot;
        }

        private int GetCountFromRange(Vector2Int range)
        {
            return Random.Range(range.x, range.y);
        }
    }
}
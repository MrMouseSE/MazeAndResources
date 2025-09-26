using System;
using System.Collections.Generic;
using AdditionalProperty;
using GradableObject;

namespace GradableObjectReference
{
    [Serializable]
    public class GradableObjectDescription
    {
        public int GradableObjectLevel;
        public string GradableObjectName;
        public GradableObjectSimpleData SimpleData;

        public int MaximumAdditionalPropertiesCount;
        public List<ObjectAdditionalProperty> AvailableProperties; 
        
        public Dictionary<string, int> GradableObjectRecipe;

        public GradableObjectData GetObjectData(int currentAdditionalPropertiesCount)
        {
            GradableObjectData gradableObjectData = new GradableObjectData();
            gradableObjectData.GradableObjectLevel = GradableObjectLevel;
            gradableObjectData.GradableObjectName = GradableObjectName;
            gradableObjectData.ReferenceObjectSimpleData = SimpleData;
            List<ObjectAdditionalProperty> propertyList = new List<ObjectAdditionalProperty>();
            if (currentAdditionalPropertiesCount > MaximumAdditionalPropertiesCount)
                currentAdditionalPropertiesCount = MaximumAdditionalPropertiesCount;
            for (int i = 0; i < currentAdditionalPropertiesCount; i++)
            {
                propertyList.Add(AvailableProperties[UnityEngine.Random.Range(0, AvailableProperties.Count)]);
            }
            gradableObjectData.ObjectAdditionalProperties = propertyList;
            return gradableObjectData;
        }
    }
}
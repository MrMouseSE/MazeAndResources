using System;
using System.Collections.Generic;
using AdditionalProperty;

namespace GradableObject
{
    [Serializable]
    public class GradableObjectSimpleData
    {
        public ObjectAdditionalProperty[] ObjectProperties;
        
        public Dictionary<string, float> GradableObjectPropertiesValues;

        public void ConvertPropertiesToDictionary()
        {
            GradableObjectPropertiesValues = new Dictionary<string, float>();
            foreach (var objectProperty in ObjectProperties)
            {
                GradableObjectPropertiesValues.Add(objectProperty.PropertyName, objectProperty.PropertyScalePercent);
            }
        }

        public float FindPropertyByName(string propertyName)
        {
            return GradableObjectPropertiesValues[propertyName];
        }
    }
}
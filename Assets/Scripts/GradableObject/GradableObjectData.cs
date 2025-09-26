using System.Collections.Generic;
using AdditionalProperty;

namespace GradableObject
{
    public class GradableObjectData
    {
        public int GradableObjectLevel;
        public string GradableObjectName;
        public List<ObjectAdditionalProperty> ObjectAdditionalProperties;
        public GradableObjectSimpleData ReferenceObjectSimpleData;

        public float GetCalculatedPropertyValue(string propertyName)
        {
            float resultValue = ReferenceObjectSimpleData.FindPropertyByName(propertyName);
            float additionalPercent = 0f;
            foreach (var objectAdditionalProperty in ObjectAdditionalProperties)
            {
                additionalPercent += objectAdditionalProperty.GetPropertyScalePercent();
            }
            return resultValue * (1 + additionalPercent);
        }
    }
}

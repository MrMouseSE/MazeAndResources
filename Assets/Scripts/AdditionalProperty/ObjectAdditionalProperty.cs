using System;

namespace AdditionalProperty
{
    [Serializable]
    public class ObjectAdditionalProperty
    {
        public string PropertyName;
        public float PropertyScalePercent;
        
        public float GetPropertyScalePercent()
        {
            return PropertyScalePercent;
        }
    }
}
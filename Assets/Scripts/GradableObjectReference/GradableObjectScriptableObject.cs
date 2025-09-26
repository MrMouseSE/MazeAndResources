using UnityEngine;

namespace GradableObjectReference
{
    [CreateAssetMenu(menuName = "Create GradableObjectScriptableObject", fileName = "GradableObjectScriptableObject", order = 0)]
    public class GradableObjectScriptableObject : ScriptableObject
    {
        public GradableObjectDescription Description;
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GradableObjectReference
{
    [CreateAssetMenu(menuName = "Create GradableObjectsSOHolder", fileName = "GradableObjectsSOHolder", order = 0)]
    public class GradableObjectsSOHolder : ScriptableObject
    {
        public GradableObjectScriptableObject[] GradableObjects;
        
        public Dictionary<GradableObjectScriptableObject, int> GradableObjectsDictionary = 
            new Dictionary<GradableObjectScriptableObject, int>();

        public void ConvertPropertiesToDictionary()
        {
            GradableObjectsDictionary.Clear();
            int higestLevel = 0;
            for (int i = 0; i < GradableObjects.Length; i++)
            {
                if (higestLevel < GradableObjects[i].Description.GradableObjectLevel) 
                    higestLevel = GradableObjects[i].Description.GradableObjectLevel;
            }
            foreach (var gradableObject in GradableObjects)
            {
                GradableObjectsDictionary.Add(gradableObject, gradableObject.Description.GradableObjectLevel);
            }
        }

        public List<GradableObjectScriptableObject> GetGradableObjectsByLevel(int level)
        {
            return (from gradableObjectPair in GradableObjectsDictionary where level == gradableObjectPair.Value 
                select gradableObjectPair.Key).ToList();
        }
    }
}
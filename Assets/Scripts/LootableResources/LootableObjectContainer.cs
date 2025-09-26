using System;
using UnityEngine;

namespace LootableResources
{
    public class LootableObjectContainer : MonoBehaviour
    {
        public LootableObjectsGrades Grade;

        [Space]
        public Transform ObjectTransform;
        public GameObject ObjectGameObject;
        public Transform AnimationRoot;
        public Animation ObjectAnimation;

        public Action OnAnimationFinish;
        [HideInInspector]
        public int RoomId;

        public void Open()
        {
            ObjectAnimation.Play();
        }

        public void OpenAnimationEnded()
        {
            OnAnimationFinish?.Invoke();
        }
    }
}
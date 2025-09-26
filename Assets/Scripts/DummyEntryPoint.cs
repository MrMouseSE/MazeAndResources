using System;
using System.Collections.Generic;
using Enemies;
using GradableObjectReference;
using LootableResources;
using NotificationWindow;
using Player;
using Rooms;
using UnityEngine;

public class DummyEntryPoint : MonoBehaviour
{
    public static LootableObjectsDescription LootableObjectsDescription;
    public static GradableObjectsSOHolder GradableObjectsSOHolder;
        
    public Transform PlayerTransform;
        
    public List<IGradableMechanicColroller> gradableMechanicController;
        
    private void Awake()
    {
        gradableMechanicController = new List<IGradableMechanicColroller>()
        {
            new RoomsController(),
            new LootableObjectsController(),
            new NotificationWindowController(),
            new PlayerBehaviourController(),
            new EnemiesController()
        };
    }

    private void Update()
    {
        foreach (var mechanicController in gradableMechanicController)
        {
            mechanicController.UpdateGradableMechanicController(this, Time.deltaTime);
        }
    }

    public IGradableMechanicColroller GetControllerByType(Type type)
    {
        return gradableMechanicController.Find(x=>x.GetType() == type);
    }
}
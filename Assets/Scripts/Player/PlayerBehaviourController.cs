using System.Collections.Generic;
using Player.PlayerSystems;
using Player.PlayerSystems.PlayerBodyPartsSkils;
using Player.PlayerSystems.PlayerHealthSystem;
using Player.PlayerSystems.PlayerMovementScripts;
using Player.PlayerSystems.PlayerSkillsScripts;

namespace Player
{
    public class PlayerBehaviourController : IGradableMechanicColroller
    {
        
        public List<IPlayerSystem> PlayerSystems { get; set; }

        public PlayerBehaviourController()
        {
            PlayerSystems = new List<IPlayerSystem>();
            PlayerSystems.Add(new PlayerBodypartsController());
            PlayerSystems.Add(new PlayerHealthController());
            PlayerSystems.Add(new PlayerMovementController());
            PlayerSystems.Add(new PlayerSkillsController());
        }
        
        public void UpdateGradableMechanicController(DummyEntryPoint context, float deltaTime)
        {
            foreach (IPlayerSystem system in PlayerSystems)
            {
                system.UpdatePlayerSystem(context, deltaTime);
            }
        }
    }
}
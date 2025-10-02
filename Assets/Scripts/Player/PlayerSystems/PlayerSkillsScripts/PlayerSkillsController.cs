using System.Collections.Generic;

namespace Player.PlayerSystems.PlayerSkillsScripts
{
    public class PlayerSkillsController : IPlayerSystem
    {

        public List<IPlayerSkill> PlayerSkills { get; set; }
        
        public void UpdatePlayerSystem(DummyEntryPoint context, float deltaTime)
        {
            foreach (var playerSkill in PlayerSkills)
            {
                playerSkill.UpdatePlayerSkills(context, deltaTime);
            }
        }
    }
}
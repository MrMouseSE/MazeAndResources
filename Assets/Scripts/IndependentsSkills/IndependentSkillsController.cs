using System.Collections.Generic;
using IndependentsSkills.SkillsScripts;

namespace IndependentsSkills
{
    public class IndependentSkillsController : IGradableMechanicColroller
    {
        
        public List<IIndependedSkill> IndependedSkills { get; set; }
        
        public void UpdateGradableMechanicController(DummyEntryPoint context, float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
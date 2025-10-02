using System.Collections.Generic;
using WorkbenchesMechanics.Workbenches;

namespace WorkbenchesMechanics
{
    public class PlayerWorkbenchsController : IGradableMechanicColroller
    {
        
        public List<IWorkbench> Workbenches { get; set; }
        
        public void UpdateGradableMechanicController(DummyEntryPoint context, float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
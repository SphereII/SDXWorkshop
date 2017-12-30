using System;
using SDX.Compiler;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;


public class UMAFixPatches : IPatcherMod
{
   

    // Inorder to update the GetWalk Type, we'll need to mark the GetWalkType to be virtual, so we can over-ride it.
    public bool Patch(ModuleDefinition module)
    {
        Console.WriteLine("==UMAFixes Patcher===");


        var WorkstationClass = module.Types.First(d => d.Name == "ArchetypeTextureCache");
        var method = WorkstationClass.Methods.First(d => d.Name == "LoadFromFile");

      
  
        return true;
    }


    // Called after the patching process and after scripts are compiled.
    // Used to link references between both assemblies
    // Return true if successful
    public bool Link(ModuleDefinition gameModule, ModuleDefinition modModule)
    {
        return true;
    }


    // Helper functions to allow us to access and change variables that are otherwise unavailable.
    private void SetMethodToVirtual(MethodDefinition meth)
    {
        meth.IsVirtual = true;
    }

}

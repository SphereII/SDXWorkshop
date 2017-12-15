using System;
using SDX.Compiler;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;
using System.Collections.Generic;
using SDX.Core;
public class WinterMod : IPatcherMod
{
  
    // Debug Logging
    private bool DebugLog = true;

    public bool Patch(ModuleDefinition module)
    {
        Log("=== Winter Mod Patcher ===");
      
        return true;
    }

    private void FixWorldBlockTicker(ModuleDefinition gameModule, ModuleDefinition modModule)
    {
        // Set the world to be public, so we can access it from our inherited class
        var gm = gameModule.Types.First(d => d.Name == "WorldBlockTicker");
        var field = gm.Fields.First(d => d.FieldType.Name == "World");
        SetFieldToPublic(field);

        Log(" Finding WorldBlockTicker:NZ");
        // Find the code for the Chunk method ( NZ in 16.4)
        var myClass = gameModule.Types.First(d => d.Name == "WorldBlockTicker");
        var myMethod = myClass.Methods.First(d => d.Name == "NZ");

        // Now we need to grab the reference to our mods class

        Log(" Finding NewWroldBlockTicker: BlockTickerPatch");
        var myModule = modModule.Types.First(d => d.Name == "NewWorldBlockTicker");
        var myPatch = gameModule.Import(myModule.Methods.First(d => d.Name == "BlockTickerPatch"));


        Log(" Updating " + myMethod.FullName.ToString());
        Log("My Method: " + myPatch.FullName.ToString());
        var pro = myMethod.Body.GetILProcessor();
        //pro.Body.Instructions.Clear();
        //pro.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
        //pro.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_1));
        //pro.Body.Instructions.Add(Instruction.Create(OpCodes.Call, myPatch));
        //pro.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));

    }




    // Called after the patching process and after scripts are compiled.
    // Used to link references between both assemblies
    // Return true if successful
    public bool Link(ModuleDefinition gameModule, ModuleDefinition modModule)
    {
        Log("Linking...");
       // FixWorldBlockTicker(gameModule, modModule);
        return true;
    }

 
    // Helper functions to allow us to access and change variables that are otherwise unavailable.
    private void SetMethodToVirtual(MethodDefinition meth)
    {
        meth.IsVirtual = true;
    }

    private void SetFieldToPublic(FieldDefinition field)
    {
        field.IsFamily = false;
        field.IsPrivate = false;
        field.IsPublic = true;

    }
    private void SetMethodToPublic(MethodDefinition field)
    {
        field.IsFamily = false;
        field.IsPrivate = false;
        field.IsPublic = true;

    }

    private void Log( String strLogMessage )
    {
        if (this.DebugLog == true)
            SDX.Core.Logging.LogInfo( this.GetType().Name.ToString() + ": " + strLogMessage);

    }
}
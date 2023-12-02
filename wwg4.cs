using UnityEngine;
using System.Reflection;

//mod class.
public class WizardWith4Guns : BaseUnityPlugin {

    //Start based on enabling.
    void Start() {
        //Decompile Assembly-CSharp.dll using a decompiler tool
        //Identify the necessary class and method responsible for co-op gameplay
        //Update the class and method names accordingly in the following code
        
        //Finding necessary class.
        Type coOpClass = Type.GetType("Assembly_CSharp.Coop.CoOpClass");
        MethodInfo methodInfo = coOpClass.GetMethod("Enable2PlayerCoOp", BindingFlags.NonPublic | BindingFlags.Instance);
        
        //Patch the method to enable 4-player co-op.
        MonoMod.RuntimeDetour.HookGen.HookEndpointManager.Modify(methodInfo, delegate(MonoMod.RuntimeDetour.HookGen.HookMethodDelegate orig, object o) {
            //Change the maximum player count to 4.
            coOpClass.GetField("maxPlayerCount").SetValue(o, 4);
            //Call the original method to enable co-op.
            return orig(o);
        });
    }

    //Unpatch the mod when disabled.
    void OnDisable() {
        MonoMod.RuntimeDetour.HookGen.HookEndpointManager.UnmodifyAll();
    }
}

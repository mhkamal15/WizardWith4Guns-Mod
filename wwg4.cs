//Declare necessary using statements
using UnityEngine;
using System.Reflection;

//Declare the mod class.
public class WizardWith4Guns : BaseUnityPlugin {

    //Start method runs on enabling the mod.
    void Start() {
        //Find the necessary class using reflection.
        Type coOpClass = Type.GetType("Assembly-CSharp.CoOpClass");
        MethodInfo methodInfo = coOpClass.GetMethod("Enable4PlayerCoOp", BindingFlags.NonPublic | BindingFlags.Instance);
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

using UnityEngine;
using System.Reflection;

// Mod class
public class WizardWith4Guns : BaseUnityPlugin
{
    // Start based on enabling
    void Start()
    {
        // Decompile Assembly-CSharp.dll using a decompiler tool (e.g., dnSpy)
        // Identify the necessary class and method responsible for co-op gameplay

        // Find necessary class
        Type coOpClass = Type.GetType("Assembly_CSharp.Coop.CoOpClass");
        MethodInfo enableCoOpMethod = coOpClass.GetMethod("EnableCoOp", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo enable2PlayerCoOpMethod = coOpClass.GetMethod("Enable2PlayerCoOp", BindingFlags.NonPublic | BindingFlags.Instance);

        // Patch the EnableCoOp method
        if (enableCoOpMethod != null)
        {
            MonoMod.RuntimeDetour.HookGen.HookEndpointManager.Modify(enableCoOpMethod, delegate (MonoMod.RuntimeDetour.HookGen.HookMethodDelegate orig, object o)
            {
                // Call the original method first
                orig(o);

                // Patch the internal player limit
                FieldInfo maxPlayersField = coOpClass.GetField("maxPlayers", BindingFlags.NonPublic | BindingFlags.Instance);
                if (maxPlayersField != null)
                {
                    maxPlayersField.SetValue(o, 4);
                }
                else
                {
                    Debug.LogError("Failed to find maxPlayers field!");
                }

                // Additional patches if needed (e.g., spawn points, UI elements)
            });
        }
        else
        {
            Debug.LogError("Failed to find EnableCoOp method!");
        }

        // Disable 2-player co-op method (optional)
        if (enable2PlayerCoOpMethod != null)
        {
            MonoMod.RuntimeDetour.HookGen.HookEndpointManager.Unpatch(enable2PlayerCoOpMethod);
        }
    }

    // Unpatch the mod when disabled
    void OnDisable()
    {
        MonoMod.RuntimeDetour.HookGen.HookEndpointManager.UnmodifyAll();
    }
}

﻿using Harmony;
using LunaCommon.Enums;
using PreFlightTests;
// ReSharper disable All

namespace LunaClient.Harmony
{
    /// <summary>
    /// This harmony patch is intended to fix the tests that are run before launching a vessel.
    /// When launching a vessel from editor or when clicking the runway KSC checks if there are vessels there.
    /// For LMP we just ignore that check and return true always
    /// </summary>
    [HarmonyPatch(typeof(LaunchSiteClear))]
    [HarmonyPatch("Test")]
    public class LaunchSiteClearTestPatch
    {
        [HarmonyPostfix]
        private static void PostFixTest(ref bool __result)
        {
            if (MainSystem.NetworkState < ClientState.Connected) return;

            __result = true;
        }
    }
}

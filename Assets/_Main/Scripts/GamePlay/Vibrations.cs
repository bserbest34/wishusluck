using Dlite.Games.Managers;
using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrations
{
    public static void Failure()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.Failure);
    }

    public static void Heavy()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.HeavyImpact);
    }

    public static void Light()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.LightImpact);
    }

    public static void Warning()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.Warning);
    }

    public static void Medium()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.MediumImpact);
    }

    public static void Soft()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.SoftImpact);
    }

    public static void Rigid()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.RigidImpact);
    }

    public static void Succes()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.Success);
    }

    public static void Selection()
    {
        HapticManager.Haptic((Dlite.Games.HapticType)HapticTypes.Selection);
    }
}
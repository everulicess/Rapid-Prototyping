using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract class Events
{
    public static UnityAction<bool> OnPlateDestroyed;
    public static UnityAction<int> OnHighscvoreChanged;
    public static UnityAction<ChoiceScenes> OnSceneFiished;
    public static UnityAction<Options> OnWeaponSelected;
}

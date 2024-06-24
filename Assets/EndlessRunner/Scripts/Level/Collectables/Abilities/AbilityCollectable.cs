using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum Abilities
{
    Jump,
    Shield,
    Fly,
    Goldx2
}
[Serializable]
public class Ability
{
    public Abilities AbilityName;
    public float Duration;
    public Sprite Icon;
    public GameObject Effect;
}
public class AbilityCollectable : MonoBehaviour
{
    [SerializeField] Ability[] AbilitiesArr;
    [SerializeField] Ability thisAbility = new();
    int abilitieNum;

    [SerializeField] Image[] Icons;
    void Start()
    {
        abilitieNum = UnityEngine.Random.Range(0, AbilitiesArr.Length);
        thisAbility = AbilitiesArr[abilitieNum];

        foreach (Image image in Icons)
            image.sprite = thisAbility.Icon;
    }
    private void OnTriggerEnter(Collider other)
    {
        OnAbilityCollected evt = new();
        evt.UnlockedAbility = thisAbility;
        EventManager.Broadcast(evt);
        gameObject.SetActive(false);
    }
}

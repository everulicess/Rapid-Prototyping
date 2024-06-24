using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [Header("references")]
    [SerializeField] Image Icon;
    [SerializeField] Image Background;
    [SerializeField] Image cooldownImage;

    Ability thisAbility;
    bool isSelected;
    Sprite defaultIcon;
    private void Start()
    {
        defaultIcon = Icon.sprite;
    }
    public void SetData(Ability ability)
    {
        thisAbility = ability;
        Icon.sprite = ability.Icon;
    }
    public void SetSelected(bool isSelected)
    {
        Background.color = isSelected ? Color.yellow : Color.white;
    }
    public void ResetVisuals()
    {
        thisAbility = null;
        Icon.sprite = defaultIcon;
        Background.color = Color.white;
    }

    internal void SetCoolDown(float timeLeft)
    {
        cooldownImage.fillAmount = (thisAbility.Duration-timeLeft) / thisAbility.Duration;
    }
}

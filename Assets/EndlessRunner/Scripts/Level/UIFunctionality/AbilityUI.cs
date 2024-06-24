using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityUI : MonoBehaviour
{
    [Header("references")]
    [SerializeField] Image Icon;
    [SerializeField] Image Background;
    [SerializeField] Image cooldownImage;
    [SerializeField] TextMeshProUGUI abilityText;
    [SerializeField] string letterToPress;
    Ability thisAbility;
    bool isSelected;
    Sprite defaultIcon;
    private void Start()
    {
        defaultIcon = Icon.sprite;
        abilityText.text = $"[{letterToPress}]";
    }
    public void SetData(Ability ability)
    {
        if (thisAbility != null)
            return;
        thisAbility = ability;
        Icon.sprite = ability.Icon;
        abilityText.text = $"[{letterToPress}]: {ability.AbilityName}";
    }
    public void SetSelected(bool isSelected)
    {
        if (thisAbility == null)
            return;
        Background.color = isSelected ? Color.yellow : Color.white;
    }
    public void ResetVisuals()
    {
        thisAbility = null;
        Icon.sprite = defaultIcon;
        Background.color = Color.white;
        abilityText.text = $"[{letterToPress}]";
    }

    internal void SetCoolDown(float timeLeft)
    {
        if (thisAbility == null)
            return;
        cooldownImage.fillAmount = (thisAbility.Duration-timeLeft) / thisAbility.Duration;
    }
}

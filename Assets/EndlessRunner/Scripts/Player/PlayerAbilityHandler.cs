using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityHandler : MonoBehaviour
{
    [SerializeField] List<Ability> PlayerAbilities = new();
    int selectedNum;
    int activeNum;
    [SerializeField] Ability selectedAbility=null;

    float currentCooldown;

    bool isAbilityActive = false;

    [Header("Abilities UI")]
    [SerializeField] List<AbilityUI> AbilityPanels = new();
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener<OnAbilityCollected>(StoreUnlockedAbility);
    }

    private void StoreUnlockedAbility(OnAbilityCollected evt)
    {
        if (PlayerAbilities.Count == 2)
            return;
        PlayerAbilities.Add(evt.UnlockedAbility);
        
        for (int i = 0; i < PlayerAbilities.Count; i++) 
        {
            AbilityPanels[i].SetData(PlayerAbilities[i]);
        }
        
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<OnAbilityCollected>(StoreUnlockedAbility);
    }
    IEnumerator ActivateCooldown()
    {
        Debug.Log($"ability activated: {PlayerAbilities[activeNum].AbilityName}");

        currentCooldown = selectedAbility.Duration;
        yield return new WaitForSeconds(PlayerAbilities[activeNum].Duration);
        OnAbilityActivated evt = new();
        evt.abilityActive = PlayerAbilities[activeNum].AbilityName;
        evt.isActive = false;
        isAbilityActive = false;
        Debug.Log($"ability finished: {selectedAbility.AbilityName}");

        if (PlayerAbilities.Contains(selectedAbility))
            PlayerAbilities.Remove(selectedAbility);


        AbilityPanels[activeNum].ResetVisuals();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            selectedNum--;
        if (Input.GetKeyDown(KeyCode.E))
            selectedNum++;
        if (selectedNum < 0)
            selectedNum = PlayerAbilities.Count - 1;
        if (selectedNum > PlayerAbilities.Count - 1)
            selectedNum = 0;
        SetSelectedAbility();
        if (Input.GetKeyDown(KeyCode.Space) && !isAbilityActive)
        {

            isAbilityActive = true;
            StartCoroutine(ActivateCooldown());
            activeNum = selectedNum;
            selectedAbility = PlayerAbilities[selectedNum];
            OnAbilityActivated evt = new();
            evt.abilityActive = selectedAbility.AbilityName;
            evt.isActive = true;
        }
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            AbilityPanels[activeNum].SetCoolDown(currentCooldown);
        }
        //if(PlayerAbilities.Count>0)
        //Debug.Log($"Ability selected = {PlayerAbilities[selectedNum].AbilityName}");

    }

    private void SetSelectedAbility()
    {
        //int panelToUse = selectedNum==1?
        foreach (AbilityUI item in AbilityPanels)
        {
            item.SetSelected(false);
        }
        
        AbilityPanels[selectedNum].SetSelected(true);
    }
}

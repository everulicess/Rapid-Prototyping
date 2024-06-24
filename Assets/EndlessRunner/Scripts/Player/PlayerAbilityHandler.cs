using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityHandler : MonoBehaviour
{
    [SerializeField] List<Ability> PlayerAbilities = new();
    //int selectedNum;
    int activeNum;
    Ability selectedAbility = null;

    float currentCooldown;

    bool isAbilityActive = false;

    [Header("Abilities UI")]
    [SerializeField] List<AbilityUI> AbilityPanels = new();
    AbilityUI selectedPanel;
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
        //if (PlayerAbilities.Count == 1)
        //{
        //    selectedAbility = PlayerAbilities[0];
        //}
        //else
        //{
        //    selectedAbility=PlayerAbilities[activeNum];
        //}
        Debug.Log($"ability activated: {selectedAbility.AbilityName}");
        currentCooldown = selectedAbility.Duration;
        yield return new WaitForSeconds(selectedAbility.Duration);
        OnAbilityActivated evt = new();
        evt.abilityActive = selectedAbility.AbilityName;
        evt.isActive = false;
        EventManager.Broadcast(evt);
        
        Debug.Log($"ability finished: {selectedAbility.AbilityName}");

        if (PlayerAbilities.Contains(selectedAbility))
            PlayerAbilities.Remove(selectedAbility);

        selectedPanel.ResetVisuals();
        //AbilityPanels[activeNum].ResetVisuals();
        isAbilityActive = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            selectedPanel.SetCoolDown(currentCooldown);
        }
        if (isAbilityActive || PlayerAbilities.Count <= 0)
            return;
        if (Input.GetKeyDown(KeyCode.X)&& PlayerAbilities.Count > 0)
        {
            Debug.Log($"X pressed");

            isAbilityActive = true;
            OnAbilityActivated evt = new();
            evt.abilityActive = PlayerAbilities[0].AbilityName;
            evt.isActive = true;
            EventManager.Broadcast(evt);
            selectedPanel = AbilityPanels[0];
            selectedAbility = PlayerAbilities[0];
            StartCoroutine(ActivateCooldown());
        }
        if (Input.GetKeyDown(KeyCode.C) )
        {
            int oneToGet = PlayerAbilities.Count > 1 ? 1 : 0;
            Debug.Log($"C pressed");

            isAbilityActive = true;
            OnAbilityActivated evt = new();
            evt.abilityActive = PlayerAbilities[oneToGet].AbilityName;
            evt.isActive = true;
            EventManager.Broadcast(evt);
            selectedPanel = AbilityPanels[1];
            selectedAbility = PlayerAbilities[oneToGet];
            StartCoroutine(ActivateCooldown());
        }



        //if (Input.GetKeyDown(KeyCode.Q))
        //    selectedNum--;
        //if (Input.GetKeyDown(KeyCode.E))
        //    selectedNum++;
        //if (selectedNum < 0)
        //    selectedNum = PlayerAbilities.Count - 1;
        //if (selectedNum > PlayerAbilities.Count - 1)
        //    selectedNum = 0;
        //SetSelectedAbility();
        if (Input.GetKeyDown(KeyCode.Space) && !isAbilityActive && PlayerAbilities.Count>0)
        {
            isAbilityActive = true;
            //activeNum = selectedNum;
            //selectedAbility = PlayerAbilities[selectedNum];
            OnAbilityActivated evt = new();
            //evt.abilityActive = PlayerAbilities[selectedNum].AbilityName;
            evt.isActive = true;
            EventManager.Broadcast(evt);
            StartCoroutine(ActivateCooldown());
        }
       
        //if(PlayerAbilities.Count>0)
        //Debug.Log($"Ability selected = {PlayerAbilities[selectedNum].AbilityName}");

    }

    private void SetSelectedAbility()
    {
        //int panelToUse = selectedNum==1?
        //foreach (AbilityUI item in AbilityPanels)
        //{
        //    item.SetSelected(false);
        //}
        //if (PlayerAbilities.Count == 1)
        //{
        //    AbilityPanels[1].SetSelected(true);
        //    AbilityPanels[0].SetSelected(true);
        //    selectedAbility = PlayerAbilities[0];
        //}
        //else
        //{
        //    AbilityPanels[selectedNum].SetSelected(true);

        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Shop")]
    [SerializeField] GameObject ShopPanel;
    [Header("Sections")]
    [SerializeField] GameObject Section_1;
    [SerializeField] GameObject Section_2;
    [SerializeField] GameObject Section_3;
    // Start is called before the first frame update
    void Start()
    {
        ShopPanel.SetActive(false);
        //EventManager.AddListener<OnShopBuy>(OnShopBuy);
    }
   
    public void OpenSection(int section)
    {
        HideAllSections();
        switch (section)
        {
            case 1:
                Section_1.SetActive(true);
                break;
            case 2:
                Section_2.SetActive(true);
                break;
            case 3:
                Section_3.SetActive(true);
                break;
            default:
                break;
        }
    }
    private void HideAllSections()
    {
        Section_1.SetActive(false);
        Section_2.SetActive(false);
        Section_3.SetActive(false);
    }

    public void ToggleShop()
    {
        ShopPanel.SetActive(!ShopPanel.activeInHierarchy);
    }
}

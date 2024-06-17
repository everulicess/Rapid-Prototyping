using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public int Gold;
    public static GeneralManager Singleton;
    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener<OnShopBuy>(OnBuyShop);
    }
    private void OnDestroy()
    {
        EventManager.RemoveListener<OnShopBuy>(OnBuyShop);
    }
    private void OnBuyShop(OnShopBuy evt)
    {
        Gold -= evt.Price;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

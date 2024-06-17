using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    List<Button> options = new();
    Button thisButton;
    bool isSelected;
    [SerializeField] Options weapon;
    // Start is called before the first frame update
    void Start()
    {
        this.name = weapon.ToString();
        foreach (GameObject option in GameObject.FindGameObjectsWithTag("Option"))
            options.Add(option.GetComponentInChildren<Button>());

        thisButton = this.GetComponentInChildren<Button>();

        if (options.Contains(thisButton))
            options.Remove(thisButton);
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelected();
    }
    void CheckSelected()
    {
        isSelected = (thisButton.image.color == Color.white);
    }
    public void OnOptionClicked()
    {
        PlateGameplayManager.instance.hasSelected = true;
        thisButton.image.color = Color.white;
        foreach (Button item in options)
        {
            item.image.color = Color.red;
        }
        CheckSelected();
    }
    private void OnDisable()
    {
        if (isSelected)
        {
            OnWeaponSelectedEvent evt = new();
            evt.selectedWeapon = weapon;
            EventManager.Broadcast(evt);
            Debug.Log($"you've selected: a {this.gameObject.transform.name}");
        }
    }
}

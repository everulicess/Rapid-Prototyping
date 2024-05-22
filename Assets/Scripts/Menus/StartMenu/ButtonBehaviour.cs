using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    Button myButton;

    float hoverscale = 1.25f;
    private void Start()
    {
        myButton = SceneManager.GetActiveScene().name == "Menu" ? GetComponent<Button>() : GetComponentInChildren<Button>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        myButton.transform.localScale *= hoverscale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myButton.transform.localScale /= hoverscale;
    }
}

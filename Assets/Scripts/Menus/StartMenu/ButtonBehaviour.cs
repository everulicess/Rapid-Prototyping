using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Button myButton;
    Vector3 myscale;
    float hoverscale = 1.25f;
    private void Awake() 
    {
        myButton = SceneManager.GetActiveScene().name == "Menu" ? GetComponent<Button>() : GetComponentInChildren<Button>();
        myscale = myButton.transform.localScale;
    }
    private void OnEnable()
    {
        myButton.transform.localScale = myscale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        myButton.transform.localScale *= hoverscale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myButton.transform.localScale = myscale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        myButton.transform.localScale = myscale;
    }
}

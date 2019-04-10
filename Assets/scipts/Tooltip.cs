using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    new UnityEngine.Camera camera;

    GameObject tooltip;
    private bool isMouseOver;

    public Item CurrentItem { get; set; }
    void Awake()
    {
        this.camera = UnityEngine.Camera.main;
        tooltip = GameObject.FindWithTag("TooltipUI");
        //tooltip.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (CurrentItem == null)
            return;
        
        isMouseOver = true;
        tooltip.SetActive(true);
        tooltip.GetComponentInChildren<UnityEngine.UI.Text>().text = CurrentItem.GetTooltipDescription();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
        tooltip.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CurrentItem == null)
            return;

        var inventory = Object.FindObjectOfType<Inventory>();

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventory.UseItem(CurrentItem);        
        }
        else
        {
            inventory.DropItem(CurrentItem);
        }
    }

    // void Update()
    // {
    //     if(isMouseOver)
    //     {
    //         var mouse = Input.mousePosition;
    //         var coordinates = camera.ScreenToWorldPoint(mouse) / 100;

    //     }
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public Item item;
    public string nameOfItem;
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool isEmpty = false;

    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;
    EventSystem eventSystem;
    Canvas canvas;
  
    Text infoBox;

    private void Start()
    {

        canvas = GetComponentInParent<Canvas>();
        infoBox = canvas.GetComponent<Text>();
        raycaster = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }
    private void Update()
    {

        OnMouseOver();
    }

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;

    }

   
    public void RemoveItemFromSlot()
    {  
        this.item = null;
        this.description = null;
        this.nameOfItem = null;
        this.ID = 0;

        this.type = null;
        this.icon = null;
        this.description = null;
        this.isEmpty = true;
        UpdateSlot();
     }

    private void OnMouseOver()
    {
        List<RaycastResult> results = ReturnGUIInput();

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Slot>() != null)
            {
                Slot hoveredOver = result.gameObject.GetComponent<Slot>();

                if (hoveredOver.item != null)
                {
                    infoBox.text = hoveredOver.item.nameOfItem;

                }
            }

        }
    }
    private List<RaycastResult> ReturnGUIInput()
    {
        //Set up the new Pointer Event
        pointerEventData = new PointerEventData(eventSystem);
        //Set the Pointer Event Position to that of the mouse position
        pointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        raycaster.Raycast(pointerEventData, results);
        return results;

    }


}

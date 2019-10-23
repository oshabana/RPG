using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled;
    public GameObject inventory;
    Transform player;
    private int allSlots = 15;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHolder;
    
    
    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;
    EventSystem eventSystem;
    Canvas canvas;

    Text infoBox;


    private void Start()
    {
        canvas = inventory.GetComponentInParent<Canvas>();
        infoBox = canvas.GetComponent<Text>();
        raycaster = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();

        player = GetComponentInParent<Transform>();

        slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().isEmpty = true;
            }
        }
    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
       
        MiddleMouseButton();


    }

    
    public void AddItem(Item itemObject)
    {
        Slot thisSlot;
        for (int i = 0; i < allSlots; i++)
        {
         
            if (slot[i].GetComponent<Slot>().isEmpty)
            {// This section only triggers if a free spot is found
                //Adds item to empty slot
                thisSlot = slot[i].GetComponent<Slot>(); //First free slot found
                itemObject.pickedUp = true;
                
                thisSlot.item = itemObject;
                thisSlot.nameOfItem = itemObject.nameOfItem;
                thisSlot.icon = itemObject.icon;
                thisSlot.type = itemObject.type;
                thisSlot.description = itemObject.description;
                thisSlot.ID = itemObject.ID;

                itemObject.transform.parent = slot[i].transform;
                itemObject.gameObject.SetActive(false);

                thisSlot.UpdateSlot();
                thisSlot.isEmpty = false;

                UpdateInventory();// Only updates when the inventory is open
                return;
            }
        }
    }
    public void RemoveItem(Slot slot) {
        Item item = slot.GetComponent<Item>();

        item.description = null;
        item.name = null;
        item.type = null;
        item.icon = null;
        item.description = null;
        item.gameObject.SetActive(false);

    }
    public void UpdateInventory() {
        // Only for use when inventory is active (Open on the display)
        // It fixes a bug where having the inventory open while picking up items
        // Normally the inventory doesn't update the new items just the sprites
        if (inventoryEnabled)
        {
            inventory.SetActive(false);
            inventory.SetActive(true);
        }
    }
    public bool isItemPresent(string itemName) {
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>() != null && // if there is an item present that fits the name
                slot[i].GetComponent<Slot>().item.nameOfItem.Equals(itemName))
            {
                Debug.Log("Item found!");
                return true;
            }
            
        }
        return false;

    }
    public bool isItemPresent(int itemID)
    {
        //Debug.Log(slot[i].GetComponent<Item>().nameOfItem);
        for (int i = 0; i < allSlots; i++)
        {
            
            if (slot[i].GetComponent<Slot>().item.ID == itemID)
            {
                Debug.Log("Item found!");
                return true;
            }
        }
        return false;

    }

    void MiddleMouseButton() {
        // Drops item
        List<RaycastResult> results = ReturnGUIInput();

        
        if (Input.GetMouseButtonDown(2)) {
           
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<Slot>())
                {
                    Slot slot = result.gameObject.GetComponent<Slot>();
                    //Item itemInSlot = slot.GetComponent<Item>();
                    slot.item.gameObject.SetActive(true);
                    slot.item.GetComponent<Transform>().position = player.position + new Vector3(4,1,0);
            
                    slot.RemoveItemFromSlot();
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

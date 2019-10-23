using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string nameOfItem;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp = false;


    void RemoveParameters(Item item) {
        item.ID = 0;
        item.nameOfItem = null;
        item.type = null;
        item.description = null;
        item.icon = null;
        item.pickedUp = false;
    }

    public static Item CreateItem(string name, int ID, string type, string description, bool pickedUp = false)
    {
        Item item = new Item();

        item.nameOfItem = name;
        item.ID = ID;
        item.description = description;
        item.type = type;
        item.pickedUp = pickedUp;

        return item;
    }
    
}

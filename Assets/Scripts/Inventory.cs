using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public List<ItemInventory> items = new List<ItemInventory>();
    public GameObject gameObjShow;
    public GameObject InventoryMainObject;
    public int maxCount;

    public void AddGraphics()
    {
        for (int i=0;i<maxCount;i++)
        {
            GameObject newItem=Instantiate(gameObjShow,InventoryMainObject.transform) as GameObject;
            newItem.name = i.ToString();
        }
    }
}

[System.Serializable]

public class ItemInventory
{
    public GameObject itemGameObj;
    public int id;
    public int count;
    
}
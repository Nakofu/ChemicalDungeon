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

    public void AddItem(int id, Item item, int count)
    {
        items[id].id = item.id;
        items[id].count=count;
        items[id].itemGameObj.GetComponent<Image>().sprite = item.image;

        if (count > 1 && item.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }
    /*
    public void AddInventoryItem(int id, ItemInventory invItem, int count)
    {
        items[id].id = invItem.id;
        items[id].count=count;
        items[id].itemGameObj.GetComponent<Image>().sprite = invItem.image;

        if (count > 1 && item.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }
    */
    public void AddGraphics()
    {
        for (int i=0;i<maxCount;i++)
        {
            GameObject newItem=Instantiate(gameObjShow,InventoryMainObject.transform) as GameObject;
            newItem.name = i.ToString();
            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;
            
            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            
            Button tempButton = newItem.GetComponent<Button>();
            items.Add(ii);
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
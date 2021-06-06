using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Item> items = new List<Item>();


}

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public Sprite image;
}
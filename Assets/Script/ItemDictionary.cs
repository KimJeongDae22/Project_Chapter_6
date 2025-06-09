using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemDictionary : Singleton<ItemDictionary>
{
    [SerializeField] private List<Item> itemDictionary = new List<Item>();

    public Item GetItemOfDictionary(int itemCodeIndex)
    {
        Item item = new Item();
        item = itemDictionary[itemCodeIndex].DeepCopy();
        return item;
    }
}

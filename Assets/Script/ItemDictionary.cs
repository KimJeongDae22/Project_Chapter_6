using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemDictionary : Singleton<ItemDictionary>
{
    [SerializeField] private List<Item> itemDictionary;

    public Item GetItemOfDictionary(int itemCodeIndex)
    {
        return itemDictionary[itemCodeIndex];
    }
}

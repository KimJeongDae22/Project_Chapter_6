using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private int _itemQuantity;

    public ItemData GetItemData()
    { return _itemData; }
    public int GetItemQuantity()
    { return _itemQuantity; }
}

public class Player_Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> _invenList;
    public List<Item> InvenList => _invenList;
    void Start()
    {
    }

    void Update()
    {
    }
}

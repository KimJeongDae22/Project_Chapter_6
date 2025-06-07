using System;
using UnityEngine;
public enum ItemType
{
    EquipAble,
    ConsumAble,
    Resource
}
public enum ConsumType
{
    HpHeal,
    ManaHeal
}
[Serializable]
public class ItemDataConsumAble
{
    [SerializeField] private ConsumType type;
    [SerializeField] private float value;

    public ConsumType GetConsumType()
    { return type; }
    public float GetConsumValue()
    { return value; }
}
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("정보")]
    [SerializeField] private string _itemName;
    [SerializeField] private string _info;
    [SerializeField] private ItemType _type;
    [SerializeField] private Sprite _icon;

    [Header("복수 소지 가능")]
    [SerializeField] private bool _stackAble;
    [SerializeField] private int _maxStackAmount;

    [Header("소모품")]
    [SerializeField] private ItemDataConsumAble[] _consumAbles;

    [Header("장착")]
    [SerializeField] private bool _equiped;

    
    public string GetName()
    { return _itemName; }
    public string GetInfo()
    { return _info; }
    public ItemType GetItemType()
    { return _type; }
    public Sprite GetIconSprite()
    { return _icon; }
    public bool GetStackAble()
    { return _stackAble; }
    public int GetMaxStackAmount()
    { return _maxStackAmount; }
    public ItemDataConsumAble[] GetConsumAbles()
    { return _consumAbles; }
    public bool GetEquiped()
    { return _equiped; }
}

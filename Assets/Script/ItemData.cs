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
    [SerializeField] private int _gold;

    [Header("복수 소지 가능")]
    [SerializeField] private bool _stackAble;
    [SerializeField] private int _maxStackAmount;

    [Header("소모품")]
    [SerializeField] private ItemDataConsumAble[] _consumAbles;

    [Header("장착 관련")]
    [SerializeField] private bool _equipAverageAble;
    [SerializeField] private float _equipAverageAtk;
    [SerializeField] private float _equipAverageArm;
    [SerializeField] private float _equipAverageCri;
    // 장비 능력치 편차 
    [SerializeField] private int _equipStatDeviation;
    public int EquipStatDeviation => _equipStatDeviation;

    // 아이템 도감에 들어가는 평균적인 장비 능력치 (장비가 생성될 때 장비 능력치가 조금씩 다르도록 설정)
    public float GetEquipAverageAtk()
    { return _equipAverageAtk; }
    public float GetEquipAverageArm()
    { return _equipAverageArm; }
    public float GetEquipAverageCri()
    { return _equipAverageCri; }

    public string GetName()
    { return _itemName; }
    public string GetInfo()
    { return _info; }
    public ItemType GetItemType()
    { return _type; }
    public Sprite GetIconSprite()
    { return _icon; }
    public int GetGold()
    { return _gold; }
    public bool GetStackAble()
    { return _stackAble; }
    public int GetMaxStackAmount()
    { return _maxStackAmount; }
    public ItemDataConsumAble[] GetConsumAbles()
    { return _consumAbles; }
}

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
public enum EquipType
{
    None,
    Weapon,
    Shield,
    Accessory
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
    [SerializeField] private EquipType _equipType;

    [SerializeField] private float _equipAverageAtk;
    [SerializeField] private float _equipAverageArm;
    [SerializeField] private float _equipAverageCri;
    [SerializeField] private float _equipAverageMaxHp;
    // 장비 능력치 편차 
    [SerializeField] private int _equipStatDeviation;
    public int EquipStatDeviation => _equipStatDeviation;

    // 아이템 도감에 들어가는 평균적인 장비 능력치 (장비가 생성될 때 장비 능력치가 조금씩 다르도록 설정)
    public EquipType EquipType { get { return _equipType; } }
    public float EquipAverageAtk { get { return _equipAverageAtk; } }
    public float EquipAverageArm { get { return _equipAverageArm; } }
    public float EquipAverageCri { get { return _equipAverageCri; } }
    public float EquipAverageMaxHp { get { return _equipAverageMaxHp; } }
    public string ItemName { get { return _itemName; } }
    public string Info { get { return _info; } }
    public ItemType Type { get { return _type; } }
    public Sprite IconSprite { get { return _icon; } }
    public int Gold { get { return _gold; } }
    public bool StackAble {  get { return _stackAble; } }
    public int MaxStackAmount {  get { return _maxStackAmount; } }
    public ItemDataConsumAble[] ConsumAbles { get { return _consumAbles; } }
}

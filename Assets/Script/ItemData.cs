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
    [SerializeField] private GameObject _dropItem;

    [Header("복수 소지 가능")]
    [SerializeField] private bool _stackAble;
    [SerializeField] private int _maxStackAmount;

    [Header("소모품")]
    [SerializeField] private ItemDataConsumAble[] _consumAbles;

    [Header("장착")]
    [SerializeField] private GameObject _equipPrefab;


    public string GetName() { return _itemName; }
    public string GetInfo() { return _info; }
    public ItemType GetItemType() { return _type; }
    public Sprite GetIcon() { return _icon; }
    public bool GetStackAble() { return _stackAble; }
    public int GetMaxStackAmount() { return _maxStackAmount; }
    public GameObject DropItem() { return _dropItem; }
    public ItemDataConsumAble[] GetConsumAbles() { return _consumAbles; }
    public GameObject GetEquipPrefab() { return _equipPrefab; }
}

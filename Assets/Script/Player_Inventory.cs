using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Stat
{
    [SerializeField] private float _equipAtk;
    [SerializeField] private float _equipArm;
    [SerializeField] private float _equipCri;
    [SerializeField] private float _equipMaxHp;
    public float GetEquipAtk()
    { return _equipAtk; }
    public float GetEquipArm()
    { return _equipArm; }
    public float GetEquipCri()
    { return _equipCri; }
    public float GetEquipMaxHp()
    { return _equipMaxHp; }
    public void SetEquipAtk(float a)
    {
        if (a < 0)
        {
            a = 0;
        }
        _equipAtk = a;
    }
    public void SetEquipArm(float a)
    {
        if (a < 0)
        {
            a = 0;
        }
        _equipArm = a;
    }
    public void SetEquipCri(float a)
    {
        if (a < 0)
        {
            a = 0;
        }
        _equipCri = a;
    }
    public void SetEquipMaxHp(float a)
    {
        if (a < 0)
        {
            a = 0;
        }
        _equipMaxHp = a;
    }
}
[Serializable]
public class Item
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private int _itemQuantity;
    [SerializeField] private Stat _stat;
    [SerializeField] private bool _isEquipped;
    public ItemData ItemData => _itemData;
    public int ItemQuantity => _itemQuantity;
    public Stat Stat => _stat;
    public bool IsEquipped => _isEquipped;
    public Item DeepCopy()
    {
        Item item = new Item();
        item.SetItemData(this._itemData);
        item.SetItemQuantity(this._itemQuantity);
        item.SetInitStat(this._itemData);
        return item;
    }    // 깊은 복사 매서드
    public void SetInitStat(ItemData itemdata)
    {
        int statDeviation = itemdata.EquipStatDeviation;
        // 장비 능력치가 각 장비마다 있는 편차값만큼 랜덤으로 결정
        // 장비 능력치가 0일 경우 편차 적용 없이 0으로 설정 (삼항 연산자 사용)
        float initAtk = _itemData.EquipAverageAtk == 0 ? 0 : _itemData.EquipAverageAtk + CustomMathod.RandomRangeSymmetry(statDeviation);
        float initArm = _itemData.EquipAverageArm == 0 ? 0 : _itemData.EquipAverageArm + CustomMathod.RandomRangeSymmetry(statDeviation);
        float initCri = _itemData.EquipAverageCri == 0 ? 0 : _itemData.EquipAverageCri + CustomMathod.RandomRangeSymmetry(statDeviation);
        float initMaxHp = _itemData.EquipAverageMaxHp == 0 ? 0 : _itemData.EquipAverageMaxHp + CustomMathod.RandomRangeSymmetry(statDeviation * 5);
        // 초기값이 0이 아니지만 편차로 인해 음수값이 될 경우의 처리는 아래 함수들에 포함되어 있음
        _stat.SetEquipAtk(initAtk);
        _stat.SetEquipArm(initArm);
        _stat.SetEquipCri(initCri);
        _stat.SetEquipMaxHp(initMaxHp);
    }
    public void SetItemQuantity(int a)
    { _itemQuantity = a; }
    public void SetItemData(ItemData itemData)
    { _itemData = itemData; }
    public void SetIsEquipped(bool a)
        { _isEquipped = a; }
}

public class Player_Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> _invenList = new List<Item>();
    [SerializeField] private int _invenGold;

    public List<Item> InvenList  { get { return _invenList; } }
    public int InvenGold { get { return _invenGold; } set { _invenGold = value; } }
    public void DeletInvenItem(int index)
    {  _invenList.RemoveAt(index); }
}

using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Stat
{
    [SerializeField] private float _equipAtk;
    [SerializeField] private float _equipArm;
    [SerializeField] private float _equipCri;
    public float GetEquipAtk()
    { return _equipAtk; }
    public float GetEquipArm()
    { return _equipArm; }
    public float GetEquipCri()
    { return _equipCri; }
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
}
[Serializable]
public class Item
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private int _itemQuantity;

    public ItemData ItemData => _itemData;
    public int ItemQuantity => _itemQuantity;

    [SerializeField] private Stat _stat;
    public Stat Stat => _stat;

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
        // 장비 능력치가 각 장비마다 있는 편차값만큼 랜덤으로 결정
        int statDeviation = UnityEngine.Random.Range(-itemdata.EquipStatDeviation, itemdata.EquipStatDeviation + 1);

        // 장비 능력치가 0일 경우 편차 적용 없이 0으로 설정 (삼항 연산자 사용)
        float initAtk = _itemData.GetEquipAverageAtk() == 0 ? 0 : _itemData.GetEquipAverageAtk() + statDeviation;
        float initArm = _itemData.GetEquipAverageArm() == 0 ? 0 : _itemData.GetEquipAverageArm() + statDeviation;
        float initCri = _itemData.GetEquipAverageCri() == 0 ? 0 : _itemData.GetEquipAverageCri() + statDeviation;

        _stat.SetEquipAtk(initAtk);
        _stat.SetEquipArm(initArm);
        _stat.SetEquipCri(initCri);
    }
    public void SetItemQuantity(int a)
    { _itemQuantity = a; }
    public void SetItemData(ItemData itemData)
    { _itemData = itemData; }
}

public class Player_Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> _invenList = new List<Item>();
    public List<Item> InvenList => _invenList;
}

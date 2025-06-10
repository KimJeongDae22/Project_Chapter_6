using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [Header("골드")]
    [SerializeField] private TextMeshProUGUI _playerGold;
    [Header("SlotBG")]
    [SerializeField] private Transform _itemSlot;
    [SerializeField] private Player_Inventory _playerInven;
    [SerializeField] private int _addSlotNum;
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private RectTransform _slotContent;

    [Header("InfoBG")]
    [SerializeField] private int _selectedItemIndex;
    [SerializeField] private Image _selectedItemIcon;
    [SerializeField] private TextMeshProUGUI _selectedItemName;
    [SerializeField] private TextMeshProUGUI _selectedItemType;
    [SerializeField] private TextMeshProUGUI _selectedItemInfo;
    [SerializeField] private TextMeshProUGUI _selectedItemStat;
    [SerializeField] private GameObject _btnEquip;
    [SerializeField] private GameObject _btnSell;
    
    public Image SelectedItemIcon { get { return _selectedItemIcon; } set { _selectedItemIcon = value; } }
    public int SelectedItemIndex { get { return _selectedItemIndex; } set { _selectedItemIndex = value; } }

    [Header("아이템 슬롯")]
    [SerializeField] private List<ItemSlot> _slots;


    void Start()
    {
        this.gameObject.SetActive(false);
        _playerInven = Singleton<Player>.Instance.Inventory;
        SlotUpdate();
        InfoClear();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SlotUpdate();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem(Singleton<ItemDictionary>.Instance.GetItemOfDictionary(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddItem(Singleton<ItemDictionary>.Instance.GetItemOfDictionary(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddItem(Singleton<ItemDictionary>.Instance.GetItemOfDictionary(2));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AddItem(Singleton<ItemDictionary>.Instance.GetItemOfDictionary(3));
        }
    }
    public void SlotUpdate()
    {
        if (_slots == null)
        {
            return;
        }
        _slots = _itemSlot.GetComponentsInChildren<ItemSlot>().ToList();

        // 플레이어가 가지고 있는 아이템 수가 현재 인벤토리 슬롯 수보다 많으면 슬롯 보충
        while (_playerInven.InvenList.Count > _slots.Count)
        {
            AddSlots();
            // UI 에 있는 아이템 슬롯만큼 리스트로 생성
            _slots = _itemSlot.GetComponentsInChildren<ItemSlot>().ToList();
        }

        for (int i = 0; i < _slots.Count; i++)
        {
            // 플레이어가 가지고 있는 아이템이 최소 1개 and 플레이어 인벤 인덱스 초과 방지
            if (_playerInven.InvenList.Count > 0 && i < _playerInven.InvenList.Count)
            {
                // 리스트 공간은 있지만 안에 데이터가 없을 경우의 예외 처리(데이터 X, 소지 개수 0)
                if (_playerInven.InvenList[i].ItemData != null && _playerInven.InvenList[i].ItemQuantity > 0)
                {
                    // 플레이어 인벤에서 정보를 가져와 인벤 슬롯에 설정
                    _slots[i].SetDataItemSlot(_playerInven.InvenList[i], i);
                }
                else
                {
                    _slots[i].SetDataItemSlot(null, i);
                }
            }
            else
            {
                _slots[i].SetDataItemSlot(null, i);
            }
            _slots[i].Set();
            _playerGold.text = _playerInven.InvenGold.ToString() + " G";
        }
    }
    public void InfoUpdate(Item item, int index)
    {
        if (item.ItemData != null)
        {
            _selectedItemIcon.sprite = item.ItemData.IconSprite;
            _selectedItemIcon.enabled = true;
            _selectedItemIndex = index;
            _selectedItemName.text = item.ItemData.ItemName;
            _selectedItemInfo.text = item.ItemData.Info;
            if (item.ItemData.Type == ItemType.EquipAble)
            {
                _selectedItemStat.text = $"공격력 : {item.Stat.GetEquipAtk()}\n방어력 : {item.Stat.GetEquipArm()}\n";
                _selectedItemStat.text += $"치명타 확률 : {item.Stat.GetEquipCri()}\n최대 체력 : {item.Stat.GetEquipMaxHp()}";
                _btnEquip.SetActive(true);
            }
            else
            {
                _selectedItemStat.text = $"소지 개수 : {item.ItemQuantity}";
                _btnEquip.SetActive(false);
            }
            _btnEquip.GetComponentInChildren<TextMeshProUGUI>().text = item.IsEquipped ? "해제하기" : "장착하기";
            _btnSell.SetActive(true);
        }
        else
        {
            InfoClear();
        }
    }
    public void InfoClear()
    {
        _selectedItemIcon.enabled = false;
        _selectedItemIndex = 0;
        _selectedItemType.text = string.Empty;
        _selectedItemName.text = string.Empty;
        _selectedItemInfo.text = string.Empty;
        _selectedItemStat.text = string.Empty;
        _btnEquip.SetActive(false);
        _btnSell.SetActive(false);
    }
    public void AddItem(Item item)
    {
        // 장착 장비가 아닌 경우
        if (item.ItemData.Type != ItemType.EquipAble)
        {
            bool added = false;
            // 추가하려는 아이템이 플레이어 인벤에 이미 존재하는지 확인
            for (int i = 0; i < _playerInven.InvenList.Count; i++)
            {
                Item checkedItem = _playerInven.InvenList[i];
                if (checkedItem.ItemData == item.ItemData)
                {
                    if (checkedItem.ItemData.StackAble)
                    {
                        checkedItem.SetItemQuantity(checkedItem.ItemQuantity + 1);
                        added = true;
                    }
                }
            }
            // 추가하려는 아이템이 기존에 없는 아이템인 경우
            if (added == false)
            {
                _playerInven.InvenList.Add(item);
            }
        }
        // 장착 장비인 경우
        else
        {
            _playerInven.InvenList.Add(item);
        }
        SlotUpdate();
        InfoUpdate(_slots[_selectedItemIndex].Item, _selectedItemIndex);
    }
    public void AddSlots()
    {
        // _addSlotNum 가 인벤토리 크기에 맞게 추가되는 아이템 슬롯 단위이므로 현재 아이템 슬롯 개수에 맞춰 단위 조정
        int addNum = _addSlotNum - _slots.Count % _addSlotNum;
        for (int i = 0; i < addNum; i++)
        {
            GameObject.Instantiate(_slotPrefab).transform.SetParent(_itemSlot.transform);
        }
        int contentHeight = _slots.Count / _addSlotNum;
        _slotContent.sizeDelta = new Vector2(_slotContent.rect.width, 165 + contentHeight * 145);
    }
    public void Btn_EquipItem()
    {
        Item item = _playerInven.InvenList[_selectedItemIndex];
        ItemSlot itemSlot = _slots[_selectedItemIndex];
        if (item.ItemData != null && item != null)
        {
            if (!item.IsEquipped)
            {
                // 중복 부위 착용 시 기존 장착 장비 해제 반복문
                for (int i = 0; i < _playerInven.InvenList.Count; i++)
                {
                    // 착용하고자 하는 장비는 제외
                    if (i != _selectedItemIndex)
                    {
                        if (item.ItemData == _playerInven.InvenList[i].ItemData && _playerInven.InvenList[i].IsEquipped == true)
                        {
                            _playerInven.InvenList[i].SetIsEquipped(false);
                            Singleton<Player>.Instance.Stat.SetEquipStat(_playerInven.InvenList[i], false);
                            _slots[i].Set();
                        }
                    }
                }
                item.SetIsEquipped(true);
                Singleton<Player>.Instance.Stat.SetEquipStat(item, true);
            }
            else
            {
                item.SetIsEquipped(false);
                Singleton<Player>.Instance.Stat.SetEquipStat(item, false);
            }
            // 장착 여부에 따른 외곽선 활성화 토글
            itemSlot.Set();
        }
        InfoUpdate(item, _selectedItemIndex);
    }
    public void Btn_SellItem()
    { 
        Item item = _slots[_selectedItemIndex].Item;
        int itemgold = _playerInven.InvenList[_selectedItemIndex].ItemData.Gold;
        if (item.ItemData != null && item != null)
        {
            if (item.ItemData.Type == ItemType.EquipAble)
            {
                if (_playerInven.InvenList[_selectedItemIndex].IsEquipped)
                {
                    item.SetIsEquipped(false);
                    Singleton<Player>.Instance.Stat.SetEquipStat(item, false);
                    _slots[_selectedItemIndex].Set();
                }

                _playerInven.InvenGold += itemgold;
                _playerInven.DeletInvenItem(_selectedItemIndex);
                InfoClear();
            }
            else
            {
                if (item.ItemQuantity > 1)
                {
                    _playerInven.InvenList[_selectedItemIndex].SetItemQuantity(item.ItemQuantity - 1);
                    _playerInven.InvenGold += itemgold;
                    InfoUpdate(_slots[_selectedItemIndex].Item, _selectedItemIndex);
                }
                else
                {
                    _playerInven.DeletInvenItem(_selectedItemIndex);
                    InfoClear();
                }
            }
            SlotUpdate();
        }
    }
}

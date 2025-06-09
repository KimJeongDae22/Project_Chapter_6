using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Transform _itemSlot;
    [SerializeField] private Player_Inventory _playerInven;
    [SerializeField] private int _addSlotNum = 5;
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private RectTransform _slotContent;


    [Header("아이템 슬롯")]
    [SerializeField] private List<ItemSlot> _slots;


    void Start()
    {
        _playerInven = Singleton<Player>.Instance.Inventory;
        InvenUpdate();
    }

    public void InvenUpdate()
    {
        if (_slots == null)
        {
            return;
        }
        // UI 에 있는 아이템 슬롯만큼 리스트로 생성
        _slots = _itemSlot.GetComponentsInChildren<ItemSlot>().ToList();

        for (int i = 0; i < _slots.Count; i++)
        {
            // 플레이어가 가지고 있는 아이템이 최소 1개 and 플레이어 인벤 인덱스 초과 방지
            if (_playerInven.InvenList.Count > 0 && i < _playerInven.InvenList.Count)
            {
                // 리스트 공간은 있지만 안에 데이터가 없을 경우의 예외 처리(데이터 X, 소지 개수 0)
                if (_playerInven.InvenList[i].GetItemData() != null && _playerInven.InvenList[i].GetItemQuantity() > 0)
                {
                    // 플레이어 인벤에서 정보를 가져와 인벤 슬롯에 설정
                    _slots[i].SetDataItemSlot(_playerInven.InvenList[i]); 
                }
                else
                {
                    _slots[i].SetDataItemSlot(null);
                }
            }
            else
            {
                _slots[i].SetDataItemSlot(null);
            }
            _slots[i].Set();
        }
    }
    public void AddItem(Item item)
    {
        // 장착 장비가 아닌 경우
        if (item.GetItemData().GetItemType() != ItemType.EquipAble)
        {
            bool added = false;
            // 추가하려는 아이템이 플레이어 인벤에 이미 존재하는지 확인
            for (int i = 0; i < _playerInven.InvenList.Count; i++)
            {
                Item checkedItem = _playerInven.InvenList[i];
                if (checkedItem.GetItemData() == item.GetItemData())
                {
                    if (checkedItem.GetItemData().GetStackAble())
                    {
                        checkedItem.SetItemQuantity(checkedItem.GetItemQuantity() + 1);
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
        if (_playerInven.InvenList.Count > _slots.Count)
        {
            AddSlots();
        }
        InvenUpdate();
    }
    public void AddSlots()
    {
        for (int i = 0; i < _addSlotNum; i++)
        {
            GameObject.Instantiate(_slotPrefab).transform.SetParent(_itemSlot.transform);
        }
        int contentHeight = _slots.Count / 4;
        _slotContent.sizeDelta = new Vector2(_slotContent.rect.width, 165 + contentHeight * 145);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvenUpdate();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem(Singleton<ItemDictionary>.Instance.GetItemOfDictionary(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddItem(Singleton<ItemDictionary>.Instance.GetItemOfDictionary(1));
        }
    }
}

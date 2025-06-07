using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Transform _itemSlot;
    [SerializeField] private Player_Inventory _playerInven;
    [Header("아이템 슬롯")]
    [SerializeField] private List<ItemSlot> _slots;

    void Start()
    {
        _playerInven = Singleton<Player>.Instance.Inventory;
        InvenUpdate();
    }

    void InvenUpdate()
    {
        if (_slots == null)
        {
            return;
        }
        // UI 에 있는 아이템 슬롯만큼 리스트로 생성
        _slots = _itemSlot.GetComponentsInChildren<ItemSlot>().ToList();

        for (int i = 0; i < _slots.Count; i++)
        {
            Debug.Log(_slots.Count);
            Debug.Log(_playerInven.InvenList.Count);
            Debug.Log(i);
            // 플레이어가 가지고 있는 아이템이 최소 1개 and 플레이어 인벤 인덱스 초과 방지
            if (_playerInven.InvenList.Count > 0 && i < _playerInven.InvenList.Count)
            {
                // 리스트 공간은 있지만 안에 데이터가 없을 경우의 예외 처리(데이터 X, 소지 개수 0)
                if (_playerInven.InvenList[i].GetItemData() != null && _playerInven.InvenList[i].GetItemQuantity() > 0)
                {
                    // 플레이어 인벤에서 정보를 가져와 인벤 슬롯에 설정
                    Debug.Log("소지 개수 : " + _playerInven.InvenList[i].GetItemQuantity());
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvenUpdate();
        }
    }
}

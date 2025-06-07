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

        for (int i = 0; i < _slots.Count - 1; i++)
        {
            if (_playerInven.InvenList.Count > 0)
            {
                // 플레이어 인벤에서 정보를 가져와 인벤 슬롯에 설정
                Debug.Log(_playerInven.InvenList.Count);
                _slots[i].SetDataItemSlot(_playerInven.InvenList[i]);
                _slots[i].Set();
            }
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

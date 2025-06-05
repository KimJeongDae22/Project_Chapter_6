using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> _invenList;
    public List<ItemData> InvenList => _invenList;
    void Start()
    {

    }

    void Update()
    {
    }
    public ItemData GetPlayerItem(int index)
    { 
        return _invenList[index]; 
    }
}

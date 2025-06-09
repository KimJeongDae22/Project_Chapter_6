using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _uiDefault;
    [SerializeField] private GameObject _uiInventory;

    private void Start()
    {

    }
    public void Btn_OnDefaultUI()
    {
        _uiDefault.SetActive(true);
        _uiInventory.SetActive(false);
    }
    public void Btn_OnInventoryUI()
    {
        _uiInventory.SetActive(true);
        _uiDefault.SetActive(false);
    }
}

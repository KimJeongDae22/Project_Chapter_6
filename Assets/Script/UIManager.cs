using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _uiDefault;
    [SerializeField] private GameObject _uiInventory;
    [SerializeField] private GameObject _uiStatus;
    [SerializeField] private TextMeshProUGUI _uiStatusAtk;
    [SerializeField] private TextMeshProUGUI _uiStatusArm;
    [SerializeField] private TextMeshProUGUI _uiStatusCri;
    [SerializeField] private TextMeshProUGUI _uiStatusMaxHp;

    public GameObject UIDefault { get { return _uiDefault; } }
    public UI_Inventory UIInventory { get { return _uiInventory.GetComponent<UI_Inventory>(); } }
    public GameObject UIStatus { get { return _uiStatus; } }
    private void Start()
    {
        PlayerInfoUpdate();
        _uiStatus.SetActive(false);
    }
    public void PlayerInfoUpdate()
    {
        _uiDefault.GetComponentInChildren<UI_PlayerInfo>().SetPlayerInfo();
    }
    public void StatusUpdate()
    {
        CommonStat playerstat = Singleton<Player>.Instance.Stat.PlayerStat;

        _uiStatusAtk.text = $"공격력 : {playerstat.TotalAtk}\t [ + {playerstat.EquipAtk}]";
        _uiStatusArm.text = $"방어력 : {playerstat.TotalArm}\t [ + {playerstat.EquipArm}]";
        _uiStatusCri.text = $"치명타 확률 : {playerstat.TotalCri}\t [ + {playerstat.EquipCri}]";
        _uiStatusMaxHp.text = $"최대 체력 : {playerstat.TotalMaxHp}\t [ + {playerstat.EquipMaxHp}]";
    }
    public void Btn_OnDefaultUI()
    {
        PlayerInfoUpdate();
        _uiDefault.SetActive(true);
        _uiInventory.SetActive(false);
        _uiStatus.SetActive(false);
    }
    public void Btn_OnInventoryUI()
    {
        _uiInventory.SetActive(true);
        _uiDefault.SetActive(false);
    }
    public void Btn_OnStatusUI()
    {
        StatusUpdate();
        _uiStatus.SetActive(true);
        _uiDefault.SetActive(false);
    }
}

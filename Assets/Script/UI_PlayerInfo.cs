using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _className;
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _expAmount;
    [SerializeField] private Slider _expAmountSlider;

    public void SetPlayerInfo()
    {
        Player_Stat playerstat = Singleton<Player>.Instance.Stat;
        _className.text = $"전직명 : {playerstat.GetPlayerClass(playerstat.PlayerClass)}";
        _playerName.text = playerstat.PlayerStat.Name;
        _expAmount.text = $"{playerstat.Exp} / {playerstat.MaxExp}";
        _expAmountSlider.value = (float) playerstat.Exp / (float) playerstat.MaxExp;
        Debug.Log(playerstat.Exp / playerstat.MaxExp);
    }
}

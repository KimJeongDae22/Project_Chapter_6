using UnityEngine;
public enum PlayerClassType
{
    None,
    Traveler,
    Explorer,
    Adventurer
}
public class Player_Stat : MonoBehaviour
{
    /*
    public string PlayerName => _name;
    public StatType PlayerType => _type;
    */
    [SerializeField] private CommonStat _playerStat;
    [SerializeField] private PlayerClassType _playerClass;
    [SerializeField] private int _MaxExp;
    [SerializeField] private int _exp;

    public CommonStat PlayerStat { get { return _playerStat; } }
    public PlayerClassType PlayerClass { get { return _playerClass; } set { _playerClass = value; } }
    public int MaxExp { get { return _MaxExp; } set { _MaxExp = value; } }
    public int Exp { get { return _exp; } set { _exp = value; } }


    public void SetEquipStat(Item item, bool plusStat)
    {
        // plusStat 변수의 참과 거짓에 따라 해당 장비 능력치가 증감되도록 설정
        _playerStat.EquipAtk += plusStat ? (int)item.Stat.GetEquipAtk() : -(int)item.Stat.GetEquipAtk();
        _playerStat.EquipArm += plusStat ? (int)item.Stat.GetEquipArm() : -(int)item.Stat.GetEquipArm();
        _playerStat.EquipCri += plusStat ? (int)item.Stat.GetEquipCri() : -(int)item.Stat.GetEquipCri();
        _playerStat.EquipMaxHp += plusStat ? (int)item.Stat.GetEquipMaxHp() : -(int)item.Stat.GetEquipMaxHp();
    }
    public string GetPlayerClass(PlayerClassType playerclass)
    {
        switch (playerclass)
        {
            case PlayerClassType.None:
                return "없음";
            case PlayerClassType.Traveler:
                return "여행자";
            case PlayerClassType.Explorer:
                return "탐험가";
            case PlayerClassType.Adventurer:
                return "모험가";
            default:
                return string.Empty;
        }
    }

}

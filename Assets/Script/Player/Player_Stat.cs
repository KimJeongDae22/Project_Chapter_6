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
    // 원래 CommonStat 을 상속받아서 하려 했으나 인스펙터 창이 너무 길어져서 불-편하므로 생성자로 구현함. 
    // 인스펙터에서 구조체의 표시를 토글로 할 수 있어서 좋긴 하지만 코드적으로는 상속이 더 좋아보임.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : Creature
{
    public string PlayerName => _name;
    public CreatureType PlayerType => _type;
    public int Level => _level;

    public int Atk => _atk;
    public int EquipAtk => _equipAtk;

    public int Arm => _arm;
    public int EquipArm => _equipArm;

    public int Cri => _cri;
    public int EquipCri => _equipCri;

    public int Hp => _hp;
    public int MaxHp => _maxHp;
    public int EquipMaxHp => _equipMaxHp;

    public void SetEquipStat(Item item, bool plusStat)
    {
        // plusStat 변수의 참과 거짓에 따라 해당 장비 능력치가 증감되도록 설정
        _equipAtk += plusStat ? (int)item.Stat.GetEquipAtk() : -(int)item.Stat.GetEquipAtk();
        _equipArm += plusStat ? (int)item.Stat.GetEquipArm() : -(int)item.Stat.GetEquipArm();
        _equipCri += plusStat ? (int)item.Stat.GetEquipCri() : -(int)item.Stat.GetEquipCri();
    }
}

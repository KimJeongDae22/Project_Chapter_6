using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StatType
{
    Other = -1,
    Player = 0,
    Monster
}
[Serializable]
public class CommonStat
{
    [SerializeField] private string _name;
    [SerializeField] private StatType _type;
    [SerializeField] private int _level;

    [Header("능력치")]
    [Space(10f)]
    [Header("공격")]
    [SerializeField] private int _atk;
    [SerializeField] private int _equipAtk;
    private int _otherAtk;
    public int TotalAtk => _atk + _equipAtk + _otherAtk;

    [Space(10f)]
    [Header("방어")]
    [SerializeField] private int _arm;
    [SerializeField] private int _equipArm;
    private int _otherArm;
    public int TotalArm => _arm + _equipArm + _otherArm;

    [Space(10f)]
    [Header("치명타")]
    [SerializeField] private int _cri;
    [SerializeField] private int _equipCri;
    private int _otherCri;
    public int TotalCri => _cri + _equipCri + _otherCri;

    [Space(10f)]
    [Header("최대 체력")]
    [SerializeField] private int _hp;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _equipMaxHp;
    private int _otherMaxHp;
    public int TotalMaxHp => _maxHp + _equipMaxHp + _otherMaxHp;

    public int Level => _level;

    public int Atk { get { return _atk; } set { _atk = value; } }
    public int EquipAtk { get { return _equipAtk; } set { _equipAtk = value; } }

    public int Arm { get { return _arm; } set { _arm = value; } }
    public int EquipArm { get { return _equipArm; } set { _equipArm = value; } }

    public int Cri { get { return _cri; } set { _cri = value; } }
    public int EquipCri { get { return _equipCri; } set { _equipCri = value; } }

    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int EquipMaxHp { get { return _equipMaxHp; } set { _equipMaxHp = value; } }

    public void SetStat(ValueType a)
    {

    }
    public virtual void InitStat(int atk, int arm, int cri, int maxHp, StatType type)
    {
        _atk = atk;
        _arm = arm;
        _cri = cri;
        _maxHp = maxHp;
        _hp = maxHp;
        _type = type;
    }
}

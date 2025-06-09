using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CreatureType
{
    Other = -1,
    Player = 0,
    Monster
}
public class Creature : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected CreatureType _type;
    [SerializeField] protected int _level;

    [Header("능력치")]
    [Space(10f)]
    [Header("공격")]
    [SerializeField] protected int _atk;
    [SerializeField] protected int _equipAtk;
    protected int _otherAtk;
    public int TotalAtk => _atk + _equipAtk + _otherAtk;

    [Space(10f)]
    [Header("방어")]
    [SerializeField] protected int _arm;
    [SerializeField] protected int _equipArm;
    protected int _otherArm;
    public int TotalArm => _arm + _equipArm + _otherArm;

    [Space(10f)]
    [Header("치명타")]
    [SerializeField] protected int _cri;
    [SerializeField] protected int _equipCri;
    protected int _otherCri;
    public int TotalCri => _cri + _equipCri + _otherCri;

    [Space(10f)]
    [Header("최대 체력")]
    [SerializeField] protected int _hp;
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _equipMaxHp;
    protected int _otherMaxHp;
    public int TotalMaxHp => _maxHp + _equipMaxHp + _otherMaxHp;

    public virtual void InitStat(int atk, int arm, int cri, int maxHp, CreatureType type)
    {
        _atk = atk;
        _arm = arm;
        _cri = cri;
        _maxHp = maxHp;
        _hp = maxHp;
        _type = type;
    }
}

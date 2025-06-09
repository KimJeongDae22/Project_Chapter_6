using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CreatureType
{
    Other = -1,
    Player = 0,
    Monster
}
public class Creature
{
    private string _name;
    private CreatureType _type;
    private int _level;

    [Header("")]
    private int _atk;
    private int _equipAtk;
    private int _otherAtk;
    public int _totalAtk => _atk + _equipAtk + _otherAtk;

    private int _arm;
    private int _equipArm;
    private int _otherArm;
    public int _totalArm => _arm + _equipArm + _otherArm;

    private int _cri;
    private int _equipCri;
    private int _otherCri;
    public int _totalCri => _cri + _equipCri + _otherCri;
}

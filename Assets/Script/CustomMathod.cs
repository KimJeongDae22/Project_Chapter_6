using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomMathod
{
    public static int RandomRangeIncludeMax(int min , int max)
    {
        int a = Random.Range(min, max + 1);
        return a;
    }
    public static int RandomRangeSymmetry(int value)
    {
        int a = Random.Range(-value, value + 1);
        return a;
    }
}

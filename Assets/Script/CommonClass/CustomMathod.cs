using UnityEngine;

public static class CustomMathod
{
    public static int RandomRangeIncludeMax(int min, int max)
    {
        int a = Random.Range(min, max + 1);
        return a;
    }
    public static int RandomRangeSymmetry(int value)
    {
        int a = Random.Range(-value, value + 1);
        return a;
    }
    public static string ItemTypeString(Item item)
    {
        string returnString;

        switch (item.ItemData.Type)
        {
            case ItemType.EquipAble:
                switch (item.ItemData.EquipType)
                {
                    case EquipType.None:
                        returnString = string.Empty;
                        break;
                    case EquipType.Weapon:
                        returnString = "무기";
                        break;
                    case EquipType.Shield:
                        returnString = "방어구";
                        break;
                    case EquipType.Accessory:
                        returnString = "악세서리";
                        break;
                    default:
                        returnString = string.Empty;
                        break;
                }
                break;
            case ItemType.ConsumAble:
                returnString = "소모품";
                break;
            case ItemType.Resource:
                returnString = "재료";
                break;
            default:
                returnString = string.Empty;
                break;
        }
        return returnString;
    }
}

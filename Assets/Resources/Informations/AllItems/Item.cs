using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;

    public int cost;
    public int hunger;
    public int thirsty;
    public int health;
    public int mental;
    public int attack;
    public int number;

    public int GetCost()
    {
        return cost;
    }

    public int GetHunger()
    {
        return hunger;
    }

    public int GetThirsty()
    {
        return thirsty;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetNumber()
    {
        return number;
    }

    public Sprite GetIcon()
    {
        return icon;
    }
}

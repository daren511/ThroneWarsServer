using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory
{
    public List<Potion> _potions = new List<Potion>();
    public List<EquipableItem> _equips = new List<EquipableItem>();

    public PlayerInventory()
    {

    }

    public PlayerInventory(List<Potion> potions)
    {
        _potions = potions;
    }

}
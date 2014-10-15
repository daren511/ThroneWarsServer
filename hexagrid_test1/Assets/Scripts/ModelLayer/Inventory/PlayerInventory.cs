using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory
{
    public List<UseableItem> _invent = new List<UseableItem>();

    public PlayerInventory(List<UseableItem> items)
    {
        _invent = items;
    }

}
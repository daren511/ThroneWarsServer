using UnityEngine;
using System.Collections;

public class Item
{
    public int _levelRequ { get; private set; }
    public string _classRequ { get; private set; }
    public string _itemName { get; private set; }
    public string _itemDescription { get; private set; }
    public int _quantity { get; private set; }

    public Item(int lvlReq, string classReq, string name, string descr, int qte)
    {
        _levelRequ = lvlReq;
        _classRequ = classReq;
        _itemName = name;
        _itemDescription = descr;
        _quantity = qte;
    }

    public bool CanEquipUse(Character c)
    {
        return _levelRequ == c._characterClass._classLevel && c._characterClass._className == _classRequ;
    }
    
}
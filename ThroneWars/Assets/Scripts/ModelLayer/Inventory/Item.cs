using UnityEngine;
using System.Collections;

public class Item
{
    public int _itemID { get; set; }
    public int _levelRequ { get;  set; }
    public string _classRequ { get;  set; }
    public string _itemName { get;  set; }
    public string _itemDescription { get;  set; }
    public int _quantity { get;  set; }
    public int _bonusPhysAtk { get; set; }
    public int _bonusPhysDef { get; set; }
    public int _bonusMagicAtk { get; set; }
    public int _bonusMagicDef { get; set; }
    public Item(int id, int lvlReq, string classReq, string name, int patk, int pdef, int matk, int mdef, string descr, int qte)
    {
        _itemID = id;
        _levelRequ = lvlReq;
        _classRequ = classReq;
        _itemName = name;
        _itemDescription = descr;
        _bonusPhysAtk = patk;
        _bonusPhysDef = pdef;
        _bonusMagicAtk = matk;
        _bonusMagicDef = mdef;
        _quantity = qte;
    }
    public bool CanEquipUse(Character c)
    {
        return _levelRequ <= c._characterClass._classLevel && (c._characterClass._className == _classRequ || _classRequ == "");
    }    
}
using UnityEngine;
using System.Collections;

public class EquipableItem : Item
{

    string _affectedStat { get;  set; }
    int _bonus { get;  set; }
    
    public EquipableItem(int lvlReq, string classReq, string name, string descr, string stat, int bonus, string loc, int qte)
        :base(lvlReq, classReq, name, descr, qte)
    {
        _affectedStat = stat;
        _bonus = bonus;
    }
}

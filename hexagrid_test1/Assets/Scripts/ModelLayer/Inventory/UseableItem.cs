using UnityEngine;
using System.Collections;

public class UseableItem : Item
{
    string _affectedStat { get;  set; }
    int _bonus { get;  set; }
    int _duration { get;  set; }

    public UseableItem(int lvlReq, string classReq, string name, string descr, string stat, int bonus, int duration, int qte)
        :base(lvlReq, classReq, name, descr, qte)
    {
        _affectedStat = stat;
        _bonus = bonus;
        _duration = duration;
    }
}

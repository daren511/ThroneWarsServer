using UnityEngine;
using System.Collections;

public class Potion : Item
{
    public int _bonusPhysAtk { get; set; }
    public int _bonusPhysDef { get; set; }
    public int _bonusMagicAtk { get; set; }
    public int _bonusMagicDef { get; set; }
    public int _lifeRestore { get; set; }
    int _duration { get;  set; }

    public Potion(int lvlReq, string classReq, string name, string descr, int duration, int qte,
        int bPhysA, int bPhysD, int bMagA, int bMagDef, int life):base(lvlReq = 1, classReq = "", name, descr, qte)
    {
        _duration = duration;
        _bonusPhysAtk = bPhysA;
        _bonusPhysDef = bPhysD;
        _bonusMagicAtk = bMagA;
        _bonusMagicDef = bMagDef;
        _lifeRestore = life;
    }
}

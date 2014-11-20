using UnityEngine;
using System.Collections;

public class Potion : Item
{

    public int _lifeRestore { get; set; }
    int _duration { get;  set; }

    public Potion(int id, int lvlReq, string classReq, string name, string descr, int duration, int qte,
        int bPhysA, int bPhysD, int bMagA, int bMagDef, int life):base(id, lvlReq = 1, classReq = "", name, bPhysA, bPhysD, bMagA, bMagDef, descr, qte)
    {
        _duration = duration;
        _lifeRestore = life;
    }
}

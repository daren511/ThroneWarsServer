using UnityEngine;
using System.Collections;

public class EquipableItem : Item
{
    public EquipableItem(int id, int lvlReq, string classReq, string name, string descr, int pAtk, int pDef, int mAtk, int mDef, int qte)
        : base(id, lvlReq = 1, classReq = "", name, pAtk, pDef, mAtk, mDef, descr, qte)
    {

    }
}

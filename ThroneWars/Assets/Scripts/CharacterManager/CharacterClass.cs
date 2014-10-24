using UnityEngine;
using System.Collections;

public class CharacterClass  {

    public string _className;//{get;  private set;}
	public int _classLevel ;//{get; private set;}
    public int _exp;
	public CharacterClass(string name, int lvl) {
		this._className = name;
		this._classLevel = lvl;
	}
    public CharacterClass(CharacterClass orig)
    {
        this._classLevel = orig._classLevel;
        this._className = orig._className;
    }
    public CharacterClass(string name, int lvl, int xp)
    {
        this._className = name;
        this._classLevel = lvl;
        this._exp = xp;
    }
    public CharacterClass GetCharacterClass()
    {
        return this;
    }
}

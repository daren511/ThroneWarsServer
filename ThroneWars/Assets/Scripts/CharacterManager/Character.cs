using UnityEngine;
using System.Collections;
/*
 * Character
 * par Charles Hunter-Roy, 2014
 * modele représentant un personnage
 * outils utilisés : Tile Map and Nav , par Leslie Young
 * */
public class Character : NaviUnit
{
    public static Character CreateCharacter(string charName, string className, int level, int move, int range,int hp, int mp, CharacterInventory invent, int patk, int pdef, int matk, int mdef)
    {
        var thisObj = CharOBJ.AddComponent<Character>();

        //calls Start() on the object and initializes it.
        thisObj._name = charName;

        thisObj._characterClass = new CharacterClass(className, level);
        thisObj._moves = move;
        thisObj.attackRange = range;

        thisObj._maxHealth = hp;
        thisObj._currHealth = hp;

        thisObj._maxMagic = mp;
        thisObj._currMagic = mp;

        thisObj._characterInventory = invent;
        thisObj._physAttack = patk;
        thisObj._physDefense = pdef;
        thisObj._magicAttack = matk;
        thisObj._magicDefense = mdef;

        return thisObj;
    }
    public static Character CreateCharacter(string charName, string className, int level, int xp, int move, int range, int hp, int mp, 
        CharacterInventory invent, int patk, int pdef, int matk, int mdef)
    {
        var thisObj = CharOBJ.AddComponent<Character>();

        //calls Start() on the object and initializes it.
        thisObj._name = charName;

        thisObj._characterClass = new CharacterClass(className, level, xp);
        thisObj._moves = move;
        thisObj.attackRange = range;

        thisObj._maxHealth = hp;
        thisObj._currHealth = hp;

        thisObj._maxMagic = mp;
        thisObj._currMagic = mp;

        thisObj._characterInventory = invent;
        thisObj._physAttack = patk;
        thisObj._physDefense = pdef;
        thisObj._magicAttack = matk;
        thisObj._magicDefense = mdef;

        return thisObj;
    }

    // ====================================================================================================================
    #region inspector properties


    private static GameObject charObj;
    public static GameObject CharOBJ
    {
        get
        {
            if (charObj == null)
            {
                charObj = new GameObject("Character");
            }
            return charObj;
        }
    }


    public int playerSide = 1;			// player-1 and player-2
    public int attackRange = 1;			// range it can attack at
    public Vector3 targetingOffset = Vector3.zero; // where missile should hit it
    public CharacterClass _characterClass;// { get; private set; }

    public int _moves; //{ get;  set; }
    public int _maxHealth; //{ get;  set; }
    public int _maxMagic;// { get;  set; }

    public int _currHealth;
    public int _currMagic;

    public int _physAttack;// { get;  set; }
    public int _physDefense;//{ get;  set; }
    public int _magicAttack;// { get;  set; }
    public int _magicDefense;// { get;  set; }

    public int _currPhysAttack;// { get;  set; }
    public int _currPhysDefense;//{ get;  set; }
    public int _currMagicAttack;// { get;  set; }
    public int _currMagicDefense;// { get;  set; }

    public int _kills = 0;
    public bool _isAlive { get { return _currHealth > 0; } set { } }
    public string _name;

    public bool _isCasting = false;
    public Vector3 _lookDirection = Vector3.zero;

    public SampleWeapon weapon;

    #endregion

    // ====================================================================================================================
    #region vars

    [HideInInspector]
    public int currMoves = 0; // how many moves this unit has left

    public bool didAttack { get; set; }
    public bool didMove { get; set; }


    #endregion

    public CharacterInventory _characterInventory;

    // ====================================================================================================================
    #region pub
    public Character(string className, int level, int move,int range, int hp, int mp, CharacterInventory invent, int patk, int pdef, int matk, int mdef)
    {
        _characterClass = new CharacterClass(className, level);
        this._moves = move;
        this._maxHealth = hp;
        this._maxMagic = mp;
        this.attackRange = range;

        this._currHealth = hp;
        this._currMagic = mp;
        this._isAlive = _currHealth > 0;

        this._characterInventory = invent;

        this._physAttack = patk;
        this._physDefense = pdef;
        this._magicAttack = matk;
        this._magicDefense = mdef;

        this._currPhysAttack = patk;
        this._currPhysDefense = pdef;
        this._currMagicAttack = matk;
        this._currMagicDefense = mdef;
    }

    public override void Start()
    {
        base.Start();
        DontDestroyOnLoad(this);

        //weapon.Init(OnAttackDone);
    }
    public override void Update()
    {
        base.Update();
    }

    /// <summary>Should be called right after unit was spawned</summary>
    public override void Init(UnitEventDelegate callback)
    {
        base.Init(callback);
        this.Reset();
    }

    /// <summary>Reset some values</summary>
    public void Reset()
    {
        currMoves = _moves;
        didAttack = false;
        didMove = false;
    }

    /// <summary>Check if target can be attacked by this unit</summary>
    public bool CanAttack(Character target)
    {
        if (didAttack) return false; // can't attack again in this turn
        if (target.playerSide == this.playerSide) return false; // can't attack a friend
        if (this.node.units.Contains(target)) return false; // can't shoot at unit on same tile, for example a flying unit over opponent land unit

        // finally check if target is in range
        return this.node.IsInRange(target.node, this.attackRange);
    }

    /// <summary>Makes an attack on the target. Unit event callback will be passed an eventCode of 2</summary>
    public bool Attack(Character target)
    {
        if (!CanAttack(target)) return false;

        didAttack = true;
        didMove = true;
        // turn to face target
        Vector3 direction = target.transform.position - transform.position; direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);

        this.GetComponent<Billboard>().AttackAnimation();
        weapon.Play(target);

        /*
         * TRAITER L'ATTAQUE, EN L'ENVOYANT AU SERVEUR ET AFFECTER LES 2 CLIENTS
         * 
         * */


        return true;
    }
    /// <summary>called by the weapon when it is done doing its thing</summary>
    private void OnAttackDone(NaviUnit unit, int eventCode)
    {
        // tell whomever is listening that I am done with my attack. eventCode 2
        if (onUnitEvent != null) onUnitEvent(this, 2);
    }
    /// <summary>
    /// Reçoit des dégâts
    /// </summary>
    /// <param name="dmg"> Le nombre de dégâts reçus, provient du serveur</param>
    public void ReceiveDamage(int dmg)
    {
        GameObject.Find("StatusIndicator").GetComponent<StatusIndicator>().Show(dmg, "Damage");
        if (_isAlive)
        {
            if (_currHealth - dmg < 0)
            {
                _currHealth = 0;
            }
            else
            {
                _currHealth -= dmg;
            }
            if(_currHealth == 0)
                isDying();
        }
        else
            isDying();
    }

    public void isDying()
    {
        this.GetComponent<Billboard>().DyingAnimation();
    }

    public void ReceiveExperience(int xp)
    {
        GameObject.Find("StatusIndicator").GetComponent<StatusIndicator>().Show(xp, "Exp");
        _characterClass._exp += xp;
    }

    public void ReceiveGold(int amt)
    {
        GameObject.Find("StatusIndicator").GetComponent<StatusIndicator>().Show(amt, "Gold");
        PlayerManager._instance._gold += amt;
    }
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pot">Les caractéristiques de la potion (vie restorée, bonus aux statistiques)
    /// sont ajoutés à celles du personnage</param>
    public void UsePotion(Potion pot)
    {
        if(pot._lifeRestore > 0)
        {
            if (_currHealth + pot._lifeRestore > _maxHealth)
            {
                _currHealth = _maxHealth;
            }
            else
            {
                _currHealth += pot._lifeRestore;
            }
            GameObject.Find("StatusIndicator").GetComponent<StatusIndicator>().Show(pot._lifeRestore, "Health");
        }

        if(pot._bonusPhysAtk > 0)
        {
            if (_currPhysAttack + pot._bonusPhysAtk < 0)
            {
                _currPhysAttack = 0;
            }
            else
            {
                _currPhysAttack += pot._bonusPhysAtk;
            }
        }
        if(pot._bonusPhysDef > 0)
        {
            if (_currPhysDefense + pot._bonusPhysDef < 0)
            {
                _currPhysDefense = 0;
            }
            else
            {
                _currPhysDefense += pot._bonusPhysDef;
            }
        }
        if(pot._bonusMagicAtk > 0)
        {
            if (_currMagicAttack + pot._bonusMagicAtk < 0)
            {
                _currMagicAttack = 0;
            }
            else
            {
                _currMagicAttack += pot._bonusMagicAtk;
            }
        }
        if(pot._bonusMagicDef > 0)
        {
            if (_currMagicDefense + pot._bonusMagicDef < 0)
            {
                _currMagicDefense = 0;
            }
            else
            {
                _currMagicDefense += pot._bonusMagicDef;
            } 
        }       
    }
    /// <summary>
    /// Augmente la défense de n points jusqu'au prochain tour
    /// </summary>
    public void Defend()
    {
        //todo:augmenter la défense de n points jusqu'au prochain tour

        currMoves = 0;
        didMove = true;
        didAttack = true;
    }
    /// <summary>
    /// Détermine si le personnage à utiliser toutes ses actions
    /// </summary>
    /// <returns>Si le personnage a fini son tour</returns>
    public bool TurnDone()
    {
        return didMove && didAttack;
    }
    #endregion
    // ====================================================================================================================
}
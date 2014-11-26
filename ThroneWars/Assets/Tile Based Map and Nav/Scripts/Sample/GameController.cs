// ====================================================================================================================
//
// Created by Leslie Young
// http://www.plyoung.com/ or http://plyoung.wordpress.com/
// ====================================================================================================================

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameController : TMNController 
{
	// ====================================================================================================================
	#region inspector properties

	public CameraMove camMover;					// used to move camera around (like make it follow a transform)
	public SelectionIndicator selectionMarker;	// used to indicate which unit is active/selected
	public RadiusMarker attackRangeMarker;		// show how far the selected unit can attack at

	public GameObject[] unitFabs;				// unit prefabs
	public int spawnCount = 8;					// how many units to spawn

    public static GameObject[] unitsFabs;
    public static GameObject[] enemyFabs;

	// these are samples of ways you might like to handle the visible markers
	// please optimise to your needs by removing this and the if() statements
	public bool hideSelectorOnMove = true;		// hide the selection marker when a unit moves?
	public bool hideMarkersOnMove = true;		// hide the node markers when a unit moves?

	public bool useTurns = false;				// show example of using limited moves?

	public bool combatOn = false;				// combat is only shown in sample 1, so turn of for other

	public bool randomMovement = false;			// demo with random movement on?

    public bool movementAllowed = false;
    public bool attackAllowed = false;

    private int activeCharacterIndex = 0;

	#endregion
	// ====================================================================================================================
	#region vars

    private enum State : byte { Init = 0, Running, DontRun }
	private State state = State.Init;

    private Character selectedUnit = null;	// currently selected unit
	private TileNode hoverNode = null;	// that that mouse is hovering over
	private TileNode prevNode = null;	// helper during movement

	public bool allowInput { get; set; }

    private List<Character>[] units = {
		new List<Character>(),	// player 1's units
		new List<Character>()	// player 2's units
	};

    public int currPlayerTurn { get; set; }		// which player's turn it is, only if useTurns = true;

	#endregion
	// ====================================================================================================================
	#region start/init

	public override void Start()
	{
		base.Start();
		allowInput = false;
		currPlayerTurn = 0;
		state = State.Init;
	}

	private void SpawnRandomUnits(int count)
	{
		for (int i = 0; i < count; i++)
		{
			// choose a unit
			int r = Random.Range(0, unitFabs.Length);
            Character unitFab = unitFabs[r].GetComponent<Character>();

			// find an open spot for the unit on the map
			int tries = 0;
			TileNode node = null;
			while (node == null)
			{
				r = Random.Range(0, map.Length);
				if (unitFab.CanStandOn(map[r], true))
				{
					node = map[r];
				}
				tries++;
				if (tries > 10) break;
			}

			if (node == null) continue;
			
			// spawn the unit
            Character unit = (Character)Character.SpawnUnit(unitFab.gameObject, map, node);
			unit.Init(OnUnitEvent);
			unit.name = "unit-" + i;
            units[unit.playerSide - 1].Add(unit);

		}
	}

    //todo: trouver une façon intelligente de placer les personnages en formation prédeterminé par le joueur sur la carte
    private TileNode CalculateStartingPosition()
    {
        if (PlayerManager._instance._playerSide == 1)
        {

        }
        else
        {

        }
        return map[0];
    }
    private void SpawnUnits()
    {
        for (int i = 0; i < PlayerManager._instance._chosenTeam.Count; ++i)
        {
            Character unitFab = unitsFabs[i].GetComponent<Character>();

            TileNode node = null;

            //unitFab._name = PlayerManager._instance._chosenTeam[i]._name;
            //unitFab._maxHealth = PlayerManager._instance._chosenTeam[i]._maxHealth;
            //unitFab._currHealth = PlayerManager._instance._chosenTeam[i]._currHealth - 20;
            //unitFab._isAlive = unitFab._currHealth > 0;
            //unitFab._maxMagic = PlayerManager._instance._chosenTeam[i]._maxMagic;
            //unitFab._currMagic = PlayerManager._instance._chosenTeam[i]._currMagic;

            //unitFab._magicAttack = PlayerManager._instance._chosenTeam[i]._magicAttack;
            //unitFab._magicDefense = PlayerManager._instance._chosenTeam[i]._magicDefense;
            //unitFab._currMagicAttack = PlayerManager._instance._chosenTeam[i]._magicAttack;
            //unitFab._currMagicDefense = PlayerManager._instance._chosenTeam[i]._magicDefense;
            //unitFab._moves = PlayerManager._instance._chosenTeam[i]._moves;
            //unitFab.attackRange = PlayerManager._instance._chosenTeam[i].attackRange;
            //unitFab._physAttack = PlayerManager._instance._chosenTeam[i]._physAttack;
            //unitFab._physDefense = PlayerManager._instance._chosenTeam[i]._physDefense;
            //unitFab._currPhysAttack = PlayerManager._instance._chosenTeam[i]._physAttack;
            //unitFab._currPhysDefense = PlayerManager._instance._chosenTeam[i]._physDefense;

            while (node == null)
            {
                if (unitFab.CanStandOn(map[i], true))
                {
                    node = map[(((GameManager._instance._playerPositions[i] % 5 + 1)) * 24) + 280];
                }
            }
            
            // spawn the unit
            Character unit = (Character)Character.SpawnUnit(unitFab.gameObject, map, node);
            //unit._characterClass = PlayerManager._instance._chosenTeam[i]._characterClass.GetCharacterClass();
            //unit._characterInventory = PlayerManager._instance._chosenTeam[i]._characterInventory;
            unit.Init(OnUnitEvent);
            unit.playerSide = PlayerManager._instance._playerSide;
            unit.name = "unit-" + i;
            units[unit.playerSide - 1].Add(unit);
        }


    }
    private void SpawnEnemyUnits()
    {

        GameManager._instance._enemyPositions.Add(378);
        GameManager._instance._enemyPositions.Add(402);
        GameManager._instance._enemyPositions.Add(403);
        GameManager._instance._enemyPositions.Add(379);

        for (int i = 0; i < GameManager._instance._enemyTeam.Count; ++i)
        {
            Character unitFab = enemyFabs[i].GetComponent<Character>();

            TileNode node = null;

            //unitFab._name = GameManager._instance._enemyTeam[i]._name;
            //unitFab._maxHealth = GameManager._instance._enemyTeam[i]._maxHealth;
            //unitFab._currHealth = 1;//GameManager._instance._enemyTeam[i]._currHealth;
            //unitFab._isAlive = unitFab._currHealth > 0;
            //unitFab._maxMagic = GameManager._instance._enemyTeam[i]._maxMagic;
            //unitFab._currMagic = GameManager._instance._enemyTeam[i]._currMagic;

            //unitFab._magicAttack = GameManager._instance._enemyTeam[i]._magicAttack;
            //unitFab._magicDefense = GameManager._instance._enemyTeam[i]._magicDefense;
            //unitFab._currMagicAttack = GameManager._instance._enemyTeam[i]._magicAttack;
            //unitFab._currMagicDefense = GameManager._instance._enemyTeam[i]._magicDefense;
            //unitFab._moves = GameManager._instance._enemyTeam[i]._moves;
            //unitFab.attackRange = GameManager._instance._enemyTeam[i].attackRange;
            //unitFab._physAttack = GameManager._instance._enemyTeam[i]._physAttack;
            //unitFab._physDefense = GameManager._instance._enemyTeam[i]._physDefense;
            //unitFab._currPhysAttack = GameManager._instance._enemyTeam[i]._physAttack;
            //unitFab._currPhysDefense = GameManager._instance._enemyTeam[i]._physDefense;

            while (node == null)
            {
                if (unitFab.CanStandOn(map[i], true))
                {
                    node = map[GameManager._instance._enemyPositions[i]];
                }
            }

            // spawn the unit
            Character unit = (Character)Character.SpawnUnit(unitFab.gameObject, map, node);
            //unit._characterClass = GameManager._instance._enemyTeam[i]._characterClass.GetCharacterClass();
            //unit._characterInventory = GameManager._instance._enemyTeam[i]._characterInventory;
            unit.Init(OnUnitEvent);
            unit.name = "enemy-" + i;
            unit.playerSide = GameManager._instance._enemySide;
            units[unit.playerSide - 1].Add(unit);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="atker">L'unité qui attaque</param>
    /// <param name="defender">L'unité qui recoit les dégâts</param>
    /// <param name="magic">Si on doit se servir des attaques et défenses magiques</param>
    /// <returns>Le nombre de dégâts</returns>
    private int CalculateDamage(Character atker, Character defender, bool magic)
    {
        int total = 1;
        if (magic)
        {
            total = atker._currMagicAttack - defender._currMagicDefense > 0 ? atker._currMagicAttack - defender._currMagicDefense : 1; 
        }
        else
        {
            total = atker._currPhysAttack - defender._currPhysDefense > 0 ? atker._currPhysAttack - defender._currPhysDefense : 1;
        }
        total += Random.Range(atker._characterClass._classLevel, atker._characterClass._classLevel * 2);
        return total;
    }
    /// <summary>
    /// Calcule l'expérience gagné par le personnage
    /// </summary>
    /// <param name="atker">Le personnage qui attaque</param>
    /// <param name="defender">Le personnage qui défend</param>
    /// <param name="dmg">Les dégâts infligés</param>
    /// <param name="atkLvl">Le niveau de l'attaque (1 pour une attaque ordinaire)</param>
    /// <returns></returns>
    private int CalculateExperience(Character atker, Character defender, int dmg, int atkLvl = 1)
    {
        int exp = ((dmg * atkLvl) * defender._characterClass._classLevel) / atker._characterClass._classLevel;
        //L'attaquant a vaincu l'adversaire, il gagne 10% d'expérience supplémentaire
        if (defender._currHealth == 0)
        {
            exp += int.Parse((exp * 0.1f).ToString());
        }
        //pour rajouter une touche aléatoire
        exp += Random.Range(atker._characterClass._classLevel, atker._characterClass._classLevel * 2);
        return exp;
    }
    private int CalculateMoneyGain(Character atker, Character defender, int dmg, int atkLvl = 1)
    {
        int gain = dmg * atkLvl * defender._characterClass._classLevel + atker._characterClass._classLevel;
        // L'attaquant a vaincu l'adversaire, il gagne 25% d'argents supplémentaire
        if (defender._currHealth == 0)
        {
            gain += int.Parse((gain * 0.25f).ToString());
        }
        return gain;
    }
    private void DoCombat(Character atker, Character defender)
    {
        if (atker.Attack(defender))
        {
            int dmg = CalculateDamage(selectedUnit, defender, false);
            int exp = CalculateExperience(selectedUnit, defender, dmg);
            int gold = CalculateMoneyGain(selectedUnit, defender, dmg);
            Debug.Log(selectedUnit._name + "  attaque " + defender._name + ", et inflige " + dmg.ToString() + " de dégâts!");
            Debug.Log(selectedUnit._name + " gagne " + exp.ToString() + " d'expérience.");
            Debug.Log("Vous gagnez " + gold + " d'or.");
            GameObject.Find("StatusIndicator").transform.position = defender.transform.position;
            defender.ReceiveDamage(dmg);
            selectedUnit.ReceiveExperience(exp);
            selectedUnit.ReceiveGold(gold);
            allowInput = false;
            attackRangeMarker.HideAll();
            StartCoroutine(WaitForAttack());
            CombatMenu.FindObjectOfType<CombatMenu>().winner = CheckGameOver();
        }
    }
    public int CountAliveCharacters(Character[] tab)
    {
        int alive = 0;
        for (int i = 0; i < tab.Length; ++i)
        {
            if (tab[i]._isAlive)
                alive++;
        }
        return alive;
    }
    private bool PlayerTurnDone()
    {
        bool done = true;

        for (int i = 0; i < PlayerManager._instance._chosenTeam.Count && done; ++i)
        {
            if (!units[PlayerManager._instance._playerSide][i].TurnDone())
            {
                done = false;
            }
        }
        return done;
    }
    /// <summary>
    /// Vérifie le nombre de personnages vivant dans chacune des deux équipes   
    /// </summary>
    /// <returns>Le numéro du joueur (1 ou 2)</returns>
    private int CheckGameOver()
    {        
        int gameOver = 0;

        if(CountAliveCharacters(units[PlayerManager._instance._playerSide - 1].ToArray()) == 0)
        {
            gameOver = GameManager._instance._enemySide;
        }
        else if (CountAliveCharacters(units[GameManager._instance._enemySide - 1].ToArray()) == 0)
        {
            gameOver = PlayerManager._instance._playerSide;
        }

        return gameOver;

    }
    public void ClickNextActiveCharacter()
    {
        int done = 0;
        bool stillActive = false;

        while (done < PlayerManager._instance._chosenTeam.Count && !stillActive)
        {
            if (activeCharacterIndex == PlayerManager._instance._chosenTeam.Count - 1)
            {
                activeCharacterIndex = 0;
            }
            else
            {
                activeCharacterIndex++;
            }
            if (units[PlayerManager._instance._playerSide - 1][activeCharacterIndex].didAttack &&
                units[PlayerManager._instance._playerSide - 1][activeCharacterIndex].didMove ||
                !units[PlayerManager._instance._playerSide - 1][activeCharacterIndex]._isAlive)
            {
                done++;
            }
            else
            {
                stillActive = true;
            }
        }
        if (done == PlayerManager._instance._chosenTeam.Count && PlayerManager._instance._playerSide == currPlayerTurn + 1)
        {
            //tour du joueur terminer
            Debug.Log("Tour terminé!");

            //TEMPORAIRE POUR TESTS/BETA, ON RECOMMENCE LE TOUR DU JOUEUR UNIQUE
            foreach (Character u in units[currPlayerTurn])
            {
                u.Reset();
            }
        }
        OnNaviUnitClick(units[PlayerManager._instance._playerSide - 1][activeCharacterIndex].gameObject);
        if (PlayerManager._instance._playerSide - 1 == currPlayerTurn)
        {
            CombatMenu.FindObjectOfType<CombatMenu>().characterChosen = true;
        }
        else
        {
            CombatMenu.FindObjectOfType<CombatMenu>().characterChosen = false;
        }
    }

	#endregion
	// ====================================================================================================================
	#region update/input

	public void Update()
	{
		if (state == State.Running && !randomMovement)
		{
			// check if player clicked on tiles/units. You could choose not to call this in certain frames,
			// for example if your GUI handled the input this frame and you don't want the player 
			// clicking 'through' GUI elements onto the tiles or units

            if (allowInput)
            {
                this.HandleInput();
            }
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                ClickNextActiveCharacter();
            }
		}
		else if (state == State.Init)
		{
			state = State.Running;
            SpawnUnits();
            SpawnEnemyUnits();

            OnNaviUnitClick(units[PlayerManager._instance._playerSide - 1][activeCharacterIndex].GetComponent<Character>().gameObject);
            if (PlayerManager._instance._playerSide == 1)
            {
                CombatMenu.FindObjectOfType<CombatMenu>().characterChosen = true;
            }
            else
            {
                CombatMenu.FindObjectOfType<CombatMenu>().characterChosen = false;
            }

		}
	}

	#endregion
	// ====================================================================================================================
	#region pub

	public void ChangeTurn()
	{
		currPlayerTurn = (currPlayerTurn == 0 ? 1 : 0);

		// unselect any selected unit
		OnClearNaviUnitSelection(null);

		// reset active player's units
		foreach (Character u in units[currPlayerTurn])
		{
			u.Reset();
		}
	}

	#endregion
	// ====================================================================================================================
	#region input handlers - click tile

	protected override void OnTileNodeClick(GameObject go)
	{

		base.OnTileNodeClick(go);
		TileNode node = go.GetComponent<TileNode>();
        allowInput = true;

		if (selectedUnit != null && node.IsVisible)
		{
			prevNode = selectedUnit.node; // needed if unit is gonna move
			if (selectedUnit.MoveTo(node, ref selectedUnit.currMoves))
			{
                selectedUnit._lookDirection = node.transform.position - prevNode.transform.position;
                //selectedUnit._lookDirection =  selectedUnit._lookDirection.normalized;

				// dont want the player clicking around while a unit is moving
                //allowInput = true;

				// hide the node markers when unit is moving. Note that the unit is allready linked with
				// the destination node by now. So use the cached node ref
                if (hideMarkersOnMove) prevNode.ShowNeighbours(((Character)selectedUnit)._moves, false);

				// hide the selector
				if (hideSelectorOnMove) selectionMarker.Hide();

				// hide the attack range indicator
				//if (combatOn) 
                    attackRangeMarker.HideAll();
                    selectedUnit.didMove = true;
				// camera should follow the unit that is moving
				camMover.Follow(selectedUnit.transform);               
			}
		}
	}

	protected override void OnTileNodeHover(GameObject go)
	{
		base.OnTileNodeHover(go);
		if (go == null)
		{	// go==null means TMNController wanna tell that mouse moved off but not onto another visible tile
			if (hoverNode != null)
			{
				hoverNode.OnHover(false);
				hoverNode = null;
			}
			return;
		}

		TileNode node = go.GetComponent<TileNode>();
		if (selectedUnit != null && node.IsVisible)
		{
			if (hoverNode != node)
			{
				if (hoverNode != null) hoverNode.OnHover(false);
				hoverNode = node;
				node.OnHover(true);
			}
		}
		else if (hoverNode != null)
		{
			hoverNode.OnHover(false);
			hoverNode = null;
		}
	}

	#endregion
	// ====================================================================================================================
	#region input handlers - click unit

    public void FakeUnitClick(GameObject go)
    {
        this.OnNaviUnitClick(go);
    }

	protected override void OnNaviUnitClick(GameObject go)
	{
        Character unit = go.GetComponent<Character>();
        if (unit._isAlive)
        {
		base.OnNaviUnitClick(go);
        attackRangeMarker.HideAll();
        map.ShowAllTileNodes(false);
        


		// jump camera to the unit that was clicked on
		camMover.Follow(go.transform);
        
		// -----------------------------------------------------------------------
		// using turns sample?
		if (useTurns)
		{
			// is active player's unit that was clicked on?
                if (unit.playerSide == (PlayerManager._instance._playerSide))
			{
                CombatMenu.FindObjectOfType<CombatMenu>().go = unit.gameObject;

                    if (PlayerManager._instance._playerSide == currPlayerTurn)
                    CombatMenu.FindObjectOfType<CombatMenu>().characterChosen = true;

                CombatMenu.FindObjectOfType<CombatMenu>().itemEnabled = false;
                selectedUnit = go.GetComponent<Character>();

				// move selector to the clicked unit to indicate it's selection
				selectionMarker.Show(go.transform);

				// show the nodes that this unit can move to
                //if(movementAllowed)
                //{
                //    selectedUnit.node.ShowNeighbours(selectedUnit.currMoves, selectedUnit.tileLevel, true, true);
                //}

                //// show how far this unit can attack at, if unit did not attack yet this turn
                //if (!selectedUnit.didAttack)
                //{
                //    if (attackAllowed)
                //        attackRangeMarker.Show(selectedUnit.transform.position, selectedUnit.attackRange);
                //    else
                //        attackRangeMarker.HideAll();
                //}
			}

			// else, not active player's unit but his opponent's unit that was clicked on
                else if (selectedUnit != null && combatOn && unit._isAlive)
			{
                DoCombat(selectedUnit, unit);
			}
		}

		// -----------------------------------------------------------------------
		// not using turns sample
        //else
        //{
        //    bool changeUnit = true;

        //    // first check if opposing unit was clicked on that can be attacked
        //    if (selectedUnit != null && combatOn)
        //    {
        //        if (selectedUnit.Attack(unit))
        //        {
        //            changeUnit = false;
        //            allowInput = false;

        //            // if not using turns sample, then reset didAttack now so it can attack again if it wanted to
        //            selectedUnit.didAttack = false;

        //            attackRangeMarker.HideAll();
        //        }
        //    }

        //    if (changeUnit)
        //    {
        //        selectedUnit = unit;

        //        // move selector to the clicked unit to indicate it's selection
        //        selectionMarker.Show(go.transform);

        //        // show the nodes that this unit can move to
        //        selectedUnit.node.ShowNeighbours(selectedUnit.currMoves, selectedUnit.tileLevel, true, true);

        //        // show how far this unit can attack at, if unit did not attack yet this turn
        //        if (combatOn) attackRangeMarker.ShowOutline(selectedUnit.transform.position, selectedUnit.attackRange);

        //        // show how far this unit can attack at, if unit did not attack yet this turn
        //        if (!selectedUnit.didAttack && combatOn)
        //        {
        //            attackRangeMarker.Show(selectedUnit.transform.position, selectedUnit.attackRange);
        //        }
        //    }
        //}
	}
        else
        {
            //TODO: traiter le revive ici
        }
    }

    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(1.5f);
        ClickNextActiveCharacter();
    }
	protected override void OnClearNaviUnitSelection(GameObject clickedAnotherUnit)
	{
		base.OnClearNaviUnitSelection(clickedAnotherUnit);
		bool canClear = true;

		// if clicked on another unit i first need to check if can clear
		if (clickedAnotherUnit != null && selectedUnit != null)
		{
            Character unit = clickedAnotherUnit.GetComponent<Character>();
			if (useTurns)
			{
				// Don't clear if opponent unit was cleared and using Turns example.
				if (unit.playerSide != selectedUnit.playerSide) canClear = false;
			}

            //else
            //{
            //    // in this case, only clear if can't attack the newly clicked unit
            //    if (selectedUnit.CanAttack(unit)) canClear = false;
            //}
		}

		// -----------------------------------------------------------------------
		if (canClear)
		{
			// hide the selection marker
			selectionMarker.Hide();

			// hide targeting marker
			//if (combatOn) 
                attackRangeMarker.HideAll();

			if (selectedUnit != null)
			{
				// hide the nodes that where shown when unit was clicked, this way I only touch the nodes that I kow I activated
				// note that map.DisableAllTileNodes() could also be used by would go through all nodes
                selectedUnit.node.ShowNeighbours(((Character)selectedUnit)._moves, false);
				selectedUnit = null;
			}
			else
			{
				// just to be sure, since OnClearNaviUnitSelection() was called while there was no selected unit afterall
				map.ShowAllTileNodes(false);
			}
		}
	}

	#endregion
	// ====================================================================================================================
	#region callbacks

	/// <summary>called when a unit completed something, like moving to a target node</summary>
	private void OnUnitEvent(NaviUnit unit, int eventCode)
	{
		// eventcode 1 = unit finished moving
		if (eventCode == 1)
		{
            Character u = (unit as Character);

            //if (randomMovement)
            //{
            //    // choose a new spot to move to
            //    //u.ChooseRandomTileAndMove();
            //}
            //else
            //{
                //if (!useTurns)
                //{
                //    // units can't use their moves up in this case, so reset after it moved
                //    u.currMoves = u._moves;
                //}

				if (!hideMarkersOnMove && prevNode != null)
				{	// the markers where not hidden when the unit started moving,
					// then they should be now as they are invalid now
                    prevNode.ShowNeighbours(((Character)selectedUnit)._moves, false);
				}

                movementAllowed = false;
                CombatMenu.FindObjectOfType<CombatMenu>().moveEnabled = false;
				// do a fake click on the unit to "select" it again
				this.OnNaviUnitClick(unit.gameObject);
				//allowInput = true; // allow input again
			//}
		}

		// eventcode 2 = unit done attacking
		if (eventCode == 2)
		{
			//allowInput = true; // allow input again

            //if (!useTurns)
            //{
				this.OnNaviUnitClick(unit.gameObject);
			// }
		}
        if (unit.GetComponent<Character>().TurnDone())
        {
            ClickNextActiveCharacter();
        }
	}

	#endregion
	// ====================================================================================================================


}

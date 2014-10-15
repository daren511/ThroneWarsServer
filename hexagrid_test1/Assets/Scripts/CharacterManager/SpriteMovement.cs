using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteMovement : MonoBehaviour {

	//speed in meters per second
	public float speed = 3.0F;
	//distance between character and tile position when we assume we reached it and start looking for the next. Explained in detail later on
	public static float MinNextTileDist = 0.06f;

	//position of the tile we are heading to
	Vector3 curTilePos;
	Tile curTile;
	List<Tile> path;
	public bool IsMoving { get; private set; }
	Transform myTransform;
	public static SpriteMovement instance = null;

	Animator anim;
	// Use this for initialization
	void Start () {
		instance = this;
		myTransform = transform;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	/*void Update () {
		if (!IsMoving)
			return;

		//if the distance between the character and the center of the next tile is short enough
		if ((curTilePos - myTransform.position).sqrMagnitude < MinNextTileDist * MinNextTileDist)
		{
			//if we reached the destination tile
			if (path.IndexOf(curTile) == 0)
			{
				IsMoving = false;
				switchOriginAndDestinationTiles();
				return;
			}
			//curTile becomes the next one
			curTile = path[path.IndexOf(curTile) - 1];
			curTilePos = calcTilePos(curTile);
		}
		
		MoveTowards(curTilePos);
		ChangeFrame(curTilePos);

	}*/
	void FixedUpdate()  
	{
		if (!IsMoving)
			return;
		
		//if the distance between the character and the center of the next tile is short enough
		if ((curTilePos - myTransform.position).sqrMagnitude < MinNextTileDist * MinNextTileDist)
		{
			//if we reached the destination tile
			if (path.IndexOf(curTile) == 0)
			{
				IsMoving = false;
				switchOriginAndDestinationTiles();
				return;
			}
			//curTile becomes the next one
			curTile = path[path.IndexOf(curTile) - 1];
			curTilePos = calcTilePos(curTile);
		}
		ChangeFrame(curTilePos);
		MoveTowards(curTilePos);

	}
	
	//gets tile position in world space
	Vector3 calcTilePos(Tile tile)
	{
		//y / 2 is added to convert coordinates from straight axis coordinate system to squiggly axis system
		Vector2 tileGridPos = new Vector2(tile.X + tile.Y / 2, tile.Y);
		Vector3 tilePos = GridManager.instance.calcWorldCoord(tileGridPos);
		//y coordinate is disregarded
		tilePos.y = myTransform.position.y;
		return tilePos;
	}
	void ChangeFrame (Vector3 position)
	{
		Vector3 direction = position - transform.position;
		// this makes the length of dir 1 so that you can multiply by it.			
		direction = direction.normalized;

		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);
		float time = state.normalizedTime;

		Debug.Log ("(X = " + direction.x + ", Z = " + direction.z + ")");

		if(direction.x > 0 && direction.z > 0) 
		{
			anim.CrossFade("Walk Back", 0f);
		}
		else if(direction.x < 0 && direction.z < 0)
		{
			anim.CrossFade("Walk Front", 0f);
		}
		else if(direction.x > -1 && direction.z < 0.1f)
		{
			anim.CrossFade("Walk Right", 0f);				
		}
		else if(direction.x < 1 && direction.z < 0.1f)
		{
			anim.CrossFade("Walk Left", 0f);
		}
	}
	//method argument is a list of tiles we got from the path finding algorithm
	public void StartMoving(List<Tile> path)
	{
		if (path.Count == 0)
			return;
		//the first tile we need to reach is actually in the end of the list just before the one the character is currently on
		curTile = path[path.Count - 2];
		curTilePos = calcTilePos(curTile);
		IsMoving = true;
		this.path = path;
	}

	void MoveTowards(Vector3 position)
	{		
		if (IsMoving) {
			Vector3 direction = position - transform.position;

			// magnitude is the total length of a vector.
			// getting the magnitude of the direction gives us the amount left to move
			float dist = direction.magnitude;

			// this makes the length of dir 1 so that you can multiply by it.			
			direction = direction.normalized;

			// the amount we can move this frame			
			float move = speed * Time.smoothDeltaTime;
			// limit our move to what we can travel.			
			if (move > dist)
				move = dist;
			
			// apply the movement to the object.
			transform.position = Vector3.MoveTowards(transform.position, position, move);
		}
	}

	//Method used to switch destination and origin tiles after the destination is reached
	void switchOriginAndDestinationTiles()
	{
		GridManager GM = GridManager.instance;
		Material originMaterial = GM.originTileTB.renderer.material;
		GM.originTileTB.renderer.material = GM.destTileTB.defaultMaterial;
		GM.originTileTB = GM.destTileTB;
		GM.originTileTB.renderer.material = originMaterial;
		GM.destTileTB = null;
		GM.generateAndShowPath();
	}
}

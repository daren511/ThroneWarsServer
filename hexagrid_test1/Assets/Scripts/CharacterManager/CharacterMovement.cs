using UnityEngine;
using System.Collections.Generic;

public class CharacterMovement: MonoBehaviour
{
	//speed in meters per second
	public float speed = 0.0025F;
	public float rotationSpeed = 0.004F;
	//distance between character and tile position when we assume we reached it and start looking for the next. Explained in detail later on
	public static float MinNextTileDist = 0.25f;
	
	private CharacterController controller;
	public static CharacterMovement instance = null;
	//position of the tile we are heading to
	Vector3 curTilePos;
	Tile curTile;
	List<Tile> path;
	public bool IsMoving { get; private set; }
	Transform myTransform;
	
	void Awake()
	{
		//singleton pattern here is used just for the sake of simplicity. Messenger (http://goo.gl/3Okkh) should be used in cases when this script is attached to more than one character
		instance = this;
		IsMoving = false;
	}
	
	void Start()
	{
		controller = this.GetComponent<CharacterController>();
		//all the animations by default should loop
		animation.wrapMode = WrapMode.Loop;
		//caching the transform for better performance
		myTransform = transform;
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
	
	//method argument is a list of tiles we got from the path finding algorithm
	public void StartMoving(List<Tile> path)
	{
		Debug.Log ("Je commence a bouger, longueur du chemin: " + (path.Count-1).ToString());
		if (path.Count == 0)
			return;
		//the first tile we need to reach is actually in the end of the list just before the one the character is currently on
		curTile = path[path.Count - 2];
		curTilePos = calcTilePos(curTile);
		IsMoving = true;
		this.path = path;
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
	
	void Update()
	{
		if (!IsMoving)
			return;
		//Debug.Log (curTilePos + " - " + myTransform.position + " = " + (curTilePos - myTransform.position));
		Debug.Log ((curTilePos - myTransform.position).sqrMagnitude + " < " + (MinNextTileDist * MinNextTileDist) + " ?") ;
		//Debug.Log ((curTilePos - myTransform.position).sqrMagnitude < MinNextTileDist * MinNextTileDist);
		//Debug.Log (MinNextTileDist * MinNextTileDist);

		//if the distance between the character and the center of the next tile is short enough
		if ((curTilePos - myTransform.position).sqrMagnitude < MinNextTileDist * MinNextTileDist)
		{
			Debug.Log("Je suis a " + path.IndexOf(curTile) + " tuile(s) de ma destination");
			//if we reached the destination tile
			if (path.IndexOf(curTile) == 0)
			{
				Debug.Log("J'ai atteint ma destination");
				IsMoving = false;
				animation.CrossFade("idle");
				switchOriginAndDestinationTiles();
				return;
			}
			//curTile becomes the next one
			curTile = path[path.IndexOf(curTile) - 1];
			curTilePos = calcTilePos(curTile);
			//Debug.Log(curTilePos);
		}
		
		MoveTowards(curTilePos);
	}
	
	void MoveTowards(Vector3 position)
	{
		//movement direction
		Vector3 dir = position - myTransform.position;

		//Debug.Log (myTransform.rotation + " " + dir);
		//Debug.Log ("angle du pc: " + myTransform.rotation.ToString() + " quaternion.lookrotation(dir):" + Quaternion.LookRotation(dir)
		//           + " vitesse:" + rotationSpeed * Time.deltaTime);

		// Rotate towards the target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
		                                        Quaternion.LookRotation(dir), rotationSpeed * Time.smoothDeltaTime);

		//Debug.Log ("angle du pc: " + myTransform.rotation.ToString ());

		Vector3 forwardDir = myTransform.forward;

		forwardDir = forwardDir * speed;

		//Debug.Log (forwardDir);
		//Debug.Log (dir);

		float speedModifier = Vector3.Dot(dir.normalized, myTransform.forward);
		forwardDir *= speedModifier;

		//Debug.Log (speedModifier);
		//Debug.Log (forwardDir);

		if (speedModifier > 0.95f)
		{
			controller.SimpleMove(forwardDir);
			if (!animation["walk"].enabled)
				animation.CrossFade("walk");
		}
		else if (!animation["idle"].enabled)
			animation.CrossFade("idle");
	}
}
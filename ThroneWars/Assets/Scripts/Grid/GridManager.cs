using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class GridManager: MonoBehaviour
{
	public GameObject Hex;
	//This time instead of specifying the number of hexes you should just drop your ground game object on this public variable
	public GameObject Ground;

	private float hexWidth;
	private float hexHeight;
	private float hexDepth;

	private float groundWidth;
	private float groundHeight;
	private float groundDepth;

	private int actualPlayer = 0;


	//selectedTile stores the tile mouse cursor is hovering on
	public Tile selectedTile = null;
	//TB of the tile which is the start of the path
	public TileBehaviour originTileTB = null;
	//TB of the tile which is the end of the path
	public TileBehaviour destTileTB = null;
	
	public static GridManager instance = null;
	//Line should be initialised to some 3d object that can fit nicely in the center of a hex tile and will be used to indicate the path. For example, it can be just a simple small sphere with some material attached to it. Initialise the variable using inspector pane.
	public GameObject Line;
	//List to hold "Lines" indicating the path
	List<GameObject> path;
	GameObject player;
	Tile playerTile;

	void Awake()
	{
		instance = this;
		//ICI: modifier cette affectation pour s'ajuster au personnage actuel
		player = GameObject.Find ("Player").transform.GetChild(actualPlayer).gameObject;

	}
	void setSizes()
	{
		hexWidth = Hex.renderer.bounds.size.x;
		hexHeight = Hex.renderer.bounds.size.z; //modif z->y
		hexDepth = Hex.renderer.bounds.size.y;

		Debug.Log(Ground.renderer.transform.position.ToString ());

		groundWidth = Ground.renderer.bounds.size.x + 10;
		groundHeight = Ground.renderer.bounds.size.z + 10;
		groundDepth = Ground.renderer.bounds.size.y + 1;
	}
	
	//The method used to calculate the number hexagons in a row and number of rows
	//Vector2.x is gridWidthInHexes and Vector2.y is gridHeightInHexes
	Vector2 calcGridSize()
	{
		//According to the math textbook hexagon's side length is half of the height
		float sideLength = hexHeight / 2; //switch hexHeight->hexDepth

		//the number of whole hex sides that fit inside inside ground height
		int nrOfSides = (int)(groundHeight / sideLength);
		//Debug.Log (nrOfSides);

		//I will not try to explain the following calculation because I made some assumptions, which might not be correct in all cases, to come up with the formula. So you'll have to trust me or figure it out yourselves.
		int gridHeightInHexes = (int)( nrOfSides * 2 / 3);
		//When the number of hexes is even the tip of the last hex in the offset column might stick up.
		//The number of hexes in that case is reduced.
		if (gridHeightInHexes % 2 == 0
		    && (nrOfSides + 0.5f) * sideLength > groundHeight)
			gridHeightInHexes--;
		//gridWidth in hexes is calculated by simply dividing ground width by hex width
		return new Vector2((int)(groundWidth / hexWidth), gridHeightInHexes);
	}
	//Method to calculate the position of the first hexagon tile
	//The center of the hex grid is (0,0,0)
	Vector3 calcInitPos()
	{
		float mapY = Ground.transform.position.y;

		Vector3 initPos;
		initPos = new Vector3(-groundWidth / 2 + hexWidth / 2, mapY,
		                      groundHeight / 2 - hexWidth / 2);

		//Debug.Log ("initPos = (" + initPos.x + ", " + initPos.y + ", " + initPos.z + ")");
		return initPos;
	}
	
	public Vector3 calcWorldCoord(Vector2 gridPos)
	{
		Vector3 initPos = calcInitPos();
		float offset = 0;
		if (gridPos.y % 2 != 0)
			offset = hexWidth / 2;
		
		float x = initPos.x + offset + gridPos.x * hexWidth;
		float z = initPos.z - gridPos.y * hexHeight * 0.75f;

		//If your ground is not a plane but a cube you might set the y coordinate to sth like groundDepth/2 + hexDepth/2
		float y = (hexDepth / 2) + (groundDepth / 2);
		//float y = initPos.y;
		return new Vector3(x, y, z);
	}
	
	//Methods in GridManager class to be modified
	void createGrid()
	{
		Vector2 gridSize = calcGridSize();
		GameObject hexGridGO = new GameObject("HexGrid");
		//board is used to store tile locations
		Dictionary<Point, Tile> board = new Dictionary<Point, Tile>();

		Vector3 playerPosition = player.transform.position;
		
		double playerX = double.Parse(Math.Round(playerPosition.x, 2).ToString());
		double playerY = double.Parse(Math.Round(playerPosition.y, 2).ToString()); //modif z->y

		
		for (float y = 0; y < gridSize.y; y++)
		{
			float sizeX = gridSize.x;
			//if the offset row sticks up, reduce the number of hexes in a row
			if (y % 2 != 0 && (gridSize.x + 0.5) * hexWidth > groundWidth)
				sizeX--;
			for (float x = 0; x < sizeX; x++)
			{
				bool passable = false;

				GameObject hex = (GameObject)Instantiate(Hex);
				Vector2 gridPos = new Vector2(x, y);
				hex.transform.position = calcWorldCoord(gridPos);
				hex.transform.parent = hexGridGO.transform;
				var tb = (TileBehaviour)hex.GetComponent("TileBehaviour");

				float terrainHeight = Terrain.activeTerrain.SampleHeight(hex.transform.position);
				float limitBottom = 0.4f ;//player.transform.position.y  + terrainHeight;
				float limitTop = 0.45f;
				
//				if(Math.Abs(terrainHeight - player.transform.position.y) < limit)
//				{
//					passable = true;
//				}
				if(terrainHeight > limitBottom && terrainHeight < limitTop)
				{
					passable = true;
				}
				if(!passable)  
				{
					tb.renderer.material.color = Color.cyan;
				}

				//y / 2 is subtracted from x because we are using straight axis coordinate system
				tb.tile = new Tile((int)x - (int)(y / 2), (int)y, passable);
				board.Add(tb.tile.Location, tb.tile);

				double tileX = double.Parse(Math.Round(calcWorldCoord(gridPos).x, 2).ToString());
				double tileY = double.Parse(Math.Round(calcWorldCoord(gridPos).y, 2).ToString()); //modif z->y


				//Mark originTile as the tile with the player coordinates
				if (tileX == playerX && tileY == playerY)
				{
					playerTile = tb.tile;

					tb.renderer.material = tb.OpaqueMaterial;
					Color red = Color.red;
					red.a = 158f / 255f;
					tb.renderer.material.color = red;
					originTileTB = tb;
				}
			}
		}
		//variable to indicate if all rows have the same number of hexes in them
		//this is checked by comparing width of the first hex row plus half of the hexWidth with groundWidth
		bool equalLineLengths = (gridSize.x + 0.5) * hexWidth <= groundWidth;
		//Neighboring tile coordinates of all the tiles are calculated
		//int i = 0;
		foreach (Tile tile in board.Values) 
		{
			tile.FindNeighbours (board, gridSize, equalLineLengths);
			//Debug.Log(board.Values.ElementAt(i));
			//++i;
		}
		//traceWalkable (board);
	}
//	void traceWalkable(Dictionary<Point, Tile> board) 
//	{
//		int move = player.gameObject.GetComponent<Character>()._moveSpeed;
//		Vector2 gridSize = calcGridSize();
//		Tile neighbourTile;
//		Point point;
//
//		for (int i = 1; i < move; ++i) {
//
//			if(playerTile.X + i < gridSize.x && playerTile.Y + i < gridSize.y) 
//			{
//				point = new Point(playerTile.X + i, playerTile.Y + i);
//				Debug.Log("allo");
//				Debug.Log (board[point]);
//
//				//neighbourTile = new Tile(playerTile.X + i, playerTile.Y + i);
//				//var myValue = board.FirstOrDefault(x => x.Value == neighbourTile).Key;
//				//Debug.Log (myValue);
//				//Debug.Log(board[myValue]);
//			}
//			if(playerTile.X - i >= 0 && playerTile.Y + i < gridSize.y) 
//			{
//				point = new Point(playerTile.X - i, playerTile.Y + i);
//				Debug.Log("bonjour");
//				Debug.Log (board[point]);
//
//				//neighbourTile = new Tile(playerTile.X - i, playerTile.Y + i);				
//				//var myValue = board.FirstOrDefault(x => x.Value == neighbourTile).Key;
//				//Debug.Log (myValue);
//				//Debug.Log(board[myValue]);
//			}
//			if(playerTile.X + i < gridSize.x && playerTile.Y - i >= 0) 
//			{
//				point = new Point(playerTile.X + i, playerTile.Y - i);
//				Debug.Log("comment ca-va");
//				Debug.Log (board[point]);
//
//				//neighbourTile = new Tile(playerTile.X + i, playerTile.Y - i);				
//				//var myValue = board.FirstOrDefault(x => x.Value == neighbourTile).Key;
//				//Debug.Log (myValue);
//				//Debug.Log(board[myValue]);
//			}
//			if(playerTile.X - i >= 0 && playerTile.Y - i >= 0) 
//			{
//				point = new Point(playerTile.X - i, playerTile.Y - i);
//				Debug.Log("bien");
//				Debug.Log (board[point]);
//
//				//neighbourTile = new Tile(playerTile.X - i, playerTile.Y - i);				
//				//var myValue = board.FirstOrDefault(x => x.Value == neighbourTile).Key;
//				//Debug.Log (myValue);
//				//Debug.Log(board[myValue]);
//			}
//
//			//Debug.Log ("(" + (playerTile.X + i).ToString() + ", " + (playerTile.Y + i).ToString() + ")");
//			//Debug.Log ("(" + (playerTile.X - i).ToString() + ", " + (playerTile.Y + i).ToString() + ")");
//			//Debug.Log ("(" + (playerTile.X + i).ToString() + ", " + (playerTile.Y - i).ToString() + ")");
//			//Debug.Log ("(" + (playerTile.X - i).ToString() + ", " + (playerTile.Y - i).ToString() + ")");
//			Debug.Log (i);
//		}
//	}

	public double calcDistance(Tile tile)
	{
		Tile destTile = destTileTB.tile;
		//Formula used here can be found in Chris Schetter's article
		float deltaX = Mathf.Abs(destTile.X - tile.X);
		float deltaY = Mathf.Abs(destTile.Y - tile.Y);
		int z1 = -(tile.X + tile.Y);
		int z2 = -(destTile.X + destTile.Y);
		float deltaZ = Mathf.Abs(z2 - z1);
		
		return Mathf.Max(deltaX, deltaY, deltaZ);
	}
	private void DrawPath(IEnumerable<Tile> path)
	{
		if (this.path == null)
			this.path = new List<GameObject>();
		//Destroy game objects which used to indicate the path
		this.path.ForEach(Destroy);
		this.path.Clear();
		
		//Lines game object is used to hold all the "Line" game objects indicating the path
		GameObject lines = GameObject.Find("Lines");
		if (lines == null)
			lines = new GameObject("Lines");


		foreach (Tile tile in path)
		{
			var line = (GameObject)Instantiate(Line);
			//calcWorldCoord method uses squiggly axis coordinates so we add y / 2 to convert x coordinate from straight axis coordinate system
			Vector2 gridPos = new Vector2(tile.X + tile.Y / 2, tile.Y);
			line.transform.position = calcWorldCoord(gridPos);
			this.path.Add(line);
			line.transform.parent = lines.transform;
		}
	}
	
	public void generateAndShowPath()
	{
		//Don't do anything if origin or destination is not defined yet
		if (originTileTB == null || destTileTB == null)
		{
			DrawPath(new List<Tile>());
			return;
		}
		//We assume that the distance between any two adjacent tiles is 1

		//If you want to have some mountains, rivers, dirt roads or something else which might slow down the player 
		//you should replace the function with something that suits better your needs
		Func<Tile, Tile, double> distance = (node1, node2) => 1;
		
		var path = PathFinder.FindPath(originTileTB.tile, destTileTB.tile, 
		                               distance, calcDistance);
		DrawPath(path);
		SpriteMovement.instance.StartMoving(path.ToList());

	}
	void Start()
	{
		setSizes();
		createGrid();
		generateAndShowPath();

	}
}
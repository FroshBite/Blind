using UnityEngine;
using System.Collections;

public class DungeonMaster : MonoBehaviour {
	
	private EnemyOverworld[] enemies;
	private Obstacle[] obstacles;
	private GameObject floor;
	public Player player;
	
	private Vector3[,] gameNodes;
	private float NodeSpacing;
	private int Columns;
	private int Rows;

	public bool playerTurn;
	private bool inBattle;

	// Use this for initialization
	void Start () {
		floor = (GameObject)Resources.Load("Floor");

		Columns = 100;
		Rows = 100;
		gameNodes = new Vector3[Rows, Columns];

		playerTurn = true;
		inBattle = false;

		for(int y = 0; y < Columns; y++){
			for( int x = 0; x < Rows; x++ ){
				gameNodes[x, y] = new Vector3(x, y, transform.position.z);
			}
		}

		obstacles = FindObjectsOfType(typeof(Obstacle)) as Obstacle[];
		enemies = FindObjectsOfType(typeof(EnemyOverworld)) as EnemyOverworld[];

		player.StartGame(this, 50, 50, gameNodes[50,50]);

		for(int i=0; i<enemies.Length; i++){
			enemies[i].StartGame(51, 50+i, gameNodes[51, 50+i]);
		}

		for(int i=0; i<obstacles.Length; i++){
			int xPos = obstacles[i].getPosition()[0];
			int yPos = obstacles[i].getPosition()[1];

			obstacles[i].StartGame(checkFloor(xPos + 1, yPos),
			                       checkFloor(xPos, yPos - 1),
			                       checkFloor(xPos + 1, yPos - 1));
		}



		for(int y = 0; y < Columns; y++){
			for( int x = 0; x < Rows; x++ ){
				if(checkFloor(x, y)){
					Vector3 Location = new Vector3(gameNodes[x, y].x, gameNodes[x, y].y, 10);
					Instantiate(floor, Location, Quaternion.identity);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (!inBattle){
			for (int i = 0; i < enemies.Length; i++){
				if((enemies[i].getPosition()[0] == player.getPosition()[0]) &&
				   (enemies[i].getPosition()[1] == player.getPosition()[1])){
					PlayerStats.enemyName = enemies[i].enemyName;
					Destroy (enemies[i].gameObject);
					enemyDeath(i);
					Application.LoadLevel(1);
					inBattle = true;
					playerTurn = true;
				}
			}
		}

		if (playerTurn && !player.isMoving){

			if(Input.GetKeyDown(KeyCode.W))
				movePlayer(player.getPosition()[0], player.getPosition()[1]+1);

			else if(Input.GetKeyDown(KeyCode.A))
				movePlayer(player.getPosition()[0]-1, player.getPosition()[1]);

			else if(Input.GetKeyDown(KeyCode.S))
				movePlayer(player.getPosition()[0], player.getPosition()[1]-1);

			else if(Input.GetKeyDown(KeyCode.D))
				movePlayer(player.getPosition()[0]+1, player.getPosition()[1]);
		}

		else if (!player.isMoving){
			for(int i=0; i<enemies.Length; i++){
				int direction;

				if(enemies[i].getPosition()[1] == player.getPosition()[1]-1)
					direction = 0;
				else if(enemies[i].getPosition()[0] == player.getPosition()[0]+1)
					direction = 1;
				else if(enemies[i].getPosition()[1] == player.getPosition()[1]+1)
					direction = 2;
				else if(enemies[i].getPosition()[0] == player.getPosition()[0]-1)
					direction = 3;
				else if((enemies[i].getPosition()[0] == player.getPosition()[0]) && 
				        (enemies[i].getPosition()[1] == player.getPosition()[1]))
					direction = 4;
				else
					direction = Random.Range(0,4);

				if(direction == 0)
					moveEnemy(enemies[i], enemies[i].getPosition()[0], enemies[i].getPosition()[1]+1);
				else if(direction == 1)
					moveEnemy(enemies[i], enemies[i].getPosition()[0]-1, enemies[i].getPosition()[1]);
				else if(direction == 2)
					moveEnemy(enemies[i], enemies[i].getPosition()[0], enemies[i].getPosition()[1]-1);
				else if(direction == 3)
					moveEnemy(enemies[i], enemies[i].getPosition()[0]+1, enemies[i].getPosition()[1]);
			}
			playerTurn = true;
		}
	}

	void movePlayer(int xPos, int yPos){
		if(checkFloor(xPos, yPos))
			player.Move (xPos, yPos, gameNodes [xPos, yPos]);
	}

	void moveEnemy(EnemyOverworld enemy, int xPos, int yPos){
		for (int i = 0; i < enemies.Length; i++){
			if((enemies[i].getPosition()[0] == xPos) && 
			   (enemies[i].getPosition()[1] == yPos))
				return;
		}

		if(checkFloor(xPos, yPos))
			enemy.Move (xPos, yPos, gameNodes [xPos, yPos]);
	}

	bool checkFloor(int xPos, int yPos){
		for (int i = 0; i < obstacles.Length; i++) {
			if((obstacles[i].getPosition()[0] == xPos) && 
			   (obstacles[i].getPosition()[1] == yPos))
				return false;
		}
		return true;
	}

	void enemyDeath(int i){
		EnemyOverworld[] tempArray=new EnemyOverworld[enemies.Length-1];
		for (int a = 0; a<i; a++) {
			tempArray[a]=enemies[a];
		}
		for(int b=i+1;b<enemies.Length;b++){
			tempArray[b-1]=enemies[b];
		}
		enemies = tempArray;

	}
}
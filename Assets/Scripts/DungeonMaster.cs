using UnityEngine;
using System.Collections;

public class DungeonMaster : MonoBehaviour {

	public Player player;
	public EnemyOverworld[] enemies;
	public Obstacle[] obstacles;

	private int Columns = 100;
	private int Rows = 100;

	public float NodeSpacing = 0.25f;
	private Vector3[,] gameNodes;

	private bool drawGizmos = false;
	public bool playerTurn = true;
	private bool inBattle = false;

	// Use this for initialization
	void Start () {
		gameNodes = new Vector3[Rows, Columns];

		for(int y = 0; y < Columns; y++){
			for( int x = 0; x < Rows; x++ ){

				float xPos = (x * 1.0f) * NodeSpacing;
				float yPos = (y * 1.0f) * NodeSpacing;

				gameNodes[x, y] = new Vector3(xPos, yPos, transform.position.z);
			}
		}

		player.StartGame(this, 50, 50, gameNodes[50,50]);

		for(int i=0; i<enemies.Length; i++){
			enemies[i].StartGame(this, 51, 50+i, gameNodes[51, 50+i]);
		}

		for(int i=0; i<obstacles.Length; i++){
			obstacles[i].StartGame(this, gameNodes[obstacles[i].position[0], obstacles[i].position[1]]);
		}

		drawGizmos = true;
	}

	void OnDrawGizmos()
	{
		if(drawGizmos)
		{
			for(int y = 0; y < Columns; y++){
				for( int x = 0; x < Rows; x++ ){
					Gizmos.color = Color.white;
					Gizmos.DrawWireSphere(gameNodes[x, y], 0.25f);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (!inBattle){
			for (int i = 0; i < enemies.Length; i++){
				if((enemies[i].currentPosition[0] == player.currentPosition[0]) &&
				   (enemies[i].currentPosition[1] == player.currentPosition[1])){
					Application.LoadLevelAdditive(1);
					inBattle = true;
					playerTurn = true;
				}
			}
		}

		if (playerTurn && !player.isMoving){

			if(Input.GetKeyDown(KeyCode.W))
				movePlayer(player.currentPosition[0], player.currentPosition[1]+1);

			else if(Input.GetKeyDown(KeyCode.A))
				movePlayer(player.currentPosition[0]-1, player.currentPosition[1]);

			else if(Input.GetKeyDown(KeyCode.S))
				movePlayer(player.currentPosition[0], player.currentPosition[1]-1);

			else if(Input.GetKeyDown(KeyCode.D))
				movePlayer(player.currentPosition[0]+1, player.currentPosition[1]);
		}

		else if (!player.isMoving){
			for(int i=0; i<enemies.Length; i++){
				int direction;

				if(enemies[i].currentPosition[1] == player.currentPosition[1]-1)
					direction = 0;
				else if(enemies[i].currentPosition[0] == player.currentPosition[0]+1)
					direction = 1;
				else if(enemies[i].currentPosition[1] == player.currentPosition[1]+1)
					direction = 2;
				else if(enemies[i].currentPosition[0] == player.currentPosition[0]-1)
					direction = 3;
				else if((enemies[i].currentPosition[0] == player.currentPosition[0]) && 
				        (enemies[i].currentPosition[1] == player.currentPosition[1]))
					direction = 4;
				else
					direction = Random.Range(0,4);

				if(direction == 0)
					moveEnemy(enemies[i], enemies[i].currentPosition[0], enemies[i].currentPosition[1]+1);
				else if(direction == 1)
					moveEnemy(enemies[i], enemies[i].currentPosition[0]-1, enemies[i].currentPosition[1]);
				else if(direction == 2)
					moveEnemy(enemies[i], enemies[i].currentPosition[0], enemies[i].currentPosition[1]-1);
				else if(direction == 3)
					moveEnemy(enemies[i], enemies[i].currentPosition[0]+1, enemies[i].currentPosition[1]);
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
			if((enemies[i].currentPosition[0] == xPos) && 
			   (enemies[i].currentPosition[1] == yPos))
				return;
		}

		if(checkFloor(xPos, yPos))
			enemy.Move (xPos, yPos, gameNodes [xPos, yPos]);
	}

	bool checkFloor(int xPos, int yPos){
		 for (int i = 0; i < obstacles.Length; i++) {
			if((obstacles[i].position[0] == xPos) && 
			   (obstacles[i].position[1] == yPos))
				return false;
		}
		return true;
	}
}
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public bool isAlive = true;
	public bool isWaiting = false; // if true, it's not my turn right now
	public bool isVictorious = false; // to be used to see if you won or you escaped
	public bool isPressed = false; // anti-spam bool

	public static int DieCount = 1; // modify for skills and level-ups

	public static int hp=100;
	public static int mp=20;
	public static int diceAtk=10; // stats are all represented by dice size
	public static int diceDef=10; // DAMAGE REDUCTION TO BE IMPLEMENTED LATER
	public int damageCount;
	public int Skill_1;
	public int Skill_2;
	public int Skill_3;
	public int Skill_4;
	
	public static int currentHP=100;
	public static int currentMP=20;
	public static float dmgMult=0;

	public static int level=1;

	public static string enemyName = "Gorilla";


	public GameObject enemyObject;
	Enemy enemy;

	public AudioSource[] sounds; // sound array
	public AudioSource hitSound;
	public AudioSource deathSound;
	public AudioSource healSound; 
	public AudioSource noMana;
	
	// Use this for initialization
	void Start () {
		sounds = GetComponents<AudioSource> ();
		hitSound = sounds [0];
		deathSound = sounds[1];
		healSound = sounds [2];
		noMana = sounds [3];

		enemy = enemyObject.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemy.isAlive) {
			isVictorious = true;
		}
	
	}


	public void Roll(){
		if(!isWaiting){
			damageCount = 0;
			for (int diceNumber = 1; diceNumber <= DieCount; diceNumber++) {
				int roll = Random.Range (1, diceAtk + 1);
				damageCount += roll;
			}
		}

	}

	public void Attack(){
		if (!isWaiting && isAlive && !isPressed && enemy.isAlive) {
			isPressed = true;
			Roll ();
			int damage = damageCount;
			damage*=(int)(1.0f+dmgMult);
			Debug.Log (string.Format ("HIT FOR {0}", damage));
			enemy.GetHit (damage);
			isWaiting = true;
			enemy.isWaiting = false;
			StartCoroutine(enemy.Turn (1)); // call enemy turn on a 1-second delay
		}
	}

	public void Escape(){
		if (!isWaiting && isAlive && !isPressed) {
			isPressed = true;
			Roll ();
			int escapism = damageCount;
			Debug.Log (string.Format ("ESCAPE CHECK: {0}", damageCount));
			if (escapism > enemy.diceAtk){
				Debug.Log ("ESCAPE SUCCESS");
				Debug.Log ("Application.LoadLevel (0)");
			}
			else if(isAlive && enemy.isAlive){
				Debug.Log ("COULDN'T ESCAPE");
				isWaiting = true;
				enemy.isWaiting = false;
			}

		}
	}

	public IEnumerator HitFlash(float flashTime){
		hitSound.Play ();
		renderer.material.color = Color.red;
		yield return new WaitForSeconds(flashTime);
		renderer.material.color = Color.white;
	}


	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0 && isAlive) {
			deathSound.Play ();
			isAlive = false;
			Debug.Log ("GAME OVER");
			Debug.Log ("ur bad");
		}
		else if(isAlive && enemy.isAlive){
			StartCoroutine(HitFlash (0.1f));
		}
	}

	// ******************** SKILLS ******************** //

	//Offensive skills
	public void Starfall(){ // random roll
		string description = "I'm going to tear this enemy apart! I think. I'll make it up as I go.";
		if (!isWaiting && mp >= level*5) {
			mp -= level*5;
			int selection = Random.Range (1,2*diceAtk);
			int basePower = Random.Range (1,diceAtk);
			if(selection == 2*diceAtk){//Deal Damage
				int dmg = (int)basePower*basePower/2;
				Debug.Log (string.Format ("CRITICAL STRIKE FOR {0}", dmg));
				enemy.GetHit (dmg);
			}else if(selection >= diceAtk){// triple strike
				for(int i =0;i<3;i++){
					int dmg = (int)basePower;
					Debug.Log (string.Format ("FLURRY STRIKE FOR {0}", dmg));
					enemy.GetHit (dmg);
				}
			}else if(selection > 1){ // regular hit
				for(int i =0;i<2;i++){
					int dmg = (int)basePower;
					Debug.Log (string.Format ("FLURRY STRIKE FOR {0}", dmg));
					enemy.GetHit (dmg);
				}
			}else if(selection == 1){
				Debug.Log ("CRITICAL FAILURE, ATTACK MISS");
			}
			isWaiting = true;
			enemy.isWaiting = false;
			StartCoroutine(enemy.Turn (1));
		}
		else if (!isWaiting){
			Debug.Log (string.Format ("NOT ENOUGH MANA. CURRENTLY HAVE {0}, NEED {1}", mp, level*5));
			noMana.Play ();
		}
	}

	// Defensive skills
	public void LesserHeal(){
		string description = "I more or less know how to patch myself with this neat trick. Doctors hate me!";
		if (!isWaiting && mp >=level*5) {
			isPressed = true;
			mp-=level*5;
			healSound.Play ();
			int basePower = Random.Range(1,diceDef);
			if (currentHP + basePower >= hp) {
				currentHP=hp;
			}else{
				currentHP +=basePower;
			}
			Debug.Log (string.Format ("HEALED FOR {0}", basePower));
			isWaiting = true;
			enemy.isWaiting = false;
			StartCoroutine(enemy.Turn (1));
		}
		else if (!isWaiting){
			Debug.Log (string.Format ("NOT ENOUGH MANA. CURRENTLY HAVE {0}, NEED {1}", mp, level*5));
			noMana.Play ();
		}
	}


	// Player stat modifier skills
	public void BlessingOfTheBasedGod(){
		dmgMult += 0.5f;
		Debug.Log ("ATTACK BOLSTERED");
		Debug.Log ("Lil B hears your prayer and blesses you.");
		isWaiting = true;
		enemy.isWaiting = false;
	}
}

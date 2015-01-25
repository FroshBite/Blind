using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthIndicator : MonoBehaviour {

	public GameObject playerObject;
	PlayerStats player;
	
	Text txt;

	// Use this for initialization
	void Start () {
		player = playerObject.GetComponent<PlayerStats>();
		txt = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "OTHER TEST";
	
	}
}

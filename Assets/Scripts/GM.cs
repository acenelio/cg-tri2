using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public float yLive = -10;

	PlayerCtrl player;

	public float timeToRespawn = 2f;
	public Transform spawnPoint;
	public GameObject playerPrefab;

	public UI ui;

	GameData data = new GameData();

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}
	
	void Start() {
		if (player == null) {
			RespawnPlayer();
		}
	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if (obj != null) {
				player = obj.GetComponent<PlayerCtrl>();
			}
		}
		DisplayHudData();
	}

	void DisplayHudData() {
		ui.hud.txtCoinCount.text = "x " + data.coinCount;
	} 

	public void IncrementCoinCount() {
		data.coinCount++;
	}

	public void KillPlayer() {
		if (player != null) {
			Destroy(player.gameObject);
			Invoke("RespawnPlayer", timeToRespawn);
		}
	}

	public void RespawnPlayer() {
		Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}

﻿using UnityEngine;

public class scr_behaviorBlockQuestion : MonoBehaviour {

	Animator anim;
	int timerFrame = 0;
	int hitCount = 0;
	bool isActive = true;

	public int FrameLimit = 30; //10 * 30 = 300

	void Start() {
		anim = GetComponent<Animator> ();
		FrameLimit *= 30;
		this.enabled = false;
	}

	void DoIsEmpty(){
		scr_summon.f_summon.s_object(9, transform.position, transform.eulerAngles);
		Destroy(gameObject);
	}

	void SpawnCoins(int numCoins) {
		Vector3 coinSpawnPos = new Vector3 (transform.position.x, transform.position.y + 0.8f, transform.position.z);
		var coin = scr_summon.f_summon.s_object (0, coinSpawnPos, transform.eulerAngles).GetComponent<scr_behaviorCoin> ();
		coin.currentState = 1;
	}

	void Update() {
		timerFrame++;
		if (timerFrame >= FrameLimit) {
			isActive = false;
			this.enabled = false;
		}
	}

	public void OnTouch(int type) {
		if (type == 1 || type == 4) {
			if (hitCount == 0)
				this.enabled = true;
			anim.Play ("up");
			SpawnCoins (1);
			hitCount++;
			if (!isActive)
				DoIsEmpty ();
		}
	}
}
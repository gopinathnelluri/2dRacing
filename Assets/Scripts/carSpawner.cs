using UnityEngine;
using System.Collections;

public class carSpawner : MonoBehaviour {

	public GameObject[] cars;
	float minPos=-2.01f, maxPos=2.01f;
	public float delayTimer = 1f;
	float timer;

	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 carPos = new Vector3 (Random.Range (minPos, maxPos), transform.position.y, transform.position.z);
			Instantiate (cars[Random.Range(0,5)], carPos, transform.rotation);
			timer = delayTimer;
		}

	}
}

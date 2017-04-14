using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {

	public float carSpeed;
	float minPosition=-2.15f,maxPosition=2.18f;
	Vector3 position;
	public uiManager ui;
	public AudioManager am;

	// Use this for initialization
	void Awake(){
		am.carSound.Play ();
	}
	void Start () {


		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
		position.x = Mathf.Clamp (position.x,minPosition,maxPosition);
		transform.position = position;

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy Car") {
			Destroy (gameObject);
			ui.gameOverNow ();
			am.carSound.Stop ();
		}
	}

}

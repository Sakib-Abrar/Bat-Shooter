using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementBlackBat : MonoBehaviour,IPointerClickHandler {

	public AudioClip deathCry;
	private AudioSource s;
	private float timeDif,timeChange;
	private float randomXCoord;
	private float randomYCoord;
	public Sprite blood,blackBat;
	private Image Bat;
	private int Dead;
	private CanvasGroup batView;
	private GameObject accessMainScript;

	void Start(){
		s = gameObject.AddComponent<AudioSource>();	
		accessMainScript=GameObject.Find("Controller");
		timeChange = 0;
		Dead = 0;
		Vector2 v = new Vector2 (Random.Range (0f, 800.0f), Random.Range (0f, 250.0f));
		transform.Translate(v);
		transform.position =v;
		Bat = this.GetComponent<Image> ();
		batView = this.GetComponent<CanvasGroup> ();
	}

	public void OnPointerClick(PointerEventData eventData){
		StartCoroutine (KillShot ());
	}

	IEnumerator KillShot(){
		Dead = 1;
		Shooter script=accessMainScript.GetComponent<Shooter>();
		if (Bat.overrideSprite != blood) {
			script.Score=script.Score+2;
			s.clip = deathCry;
			s.Play ();
		}
		Bat.overrideSprite = blood;
		yield return new WaitForSeconds (2);
		batView.alpha = 0f;
		batView.blocksRaycasts = false;
		batView.interactable = false;
		Dead = 0;
		yield return new WaitForSeconds (2);
		batView.alpha = 1f;
		batView.blocksRaycasts = true;
		batView.interactable = true;


	}
	void moveBlackBat(){
		if (Bat.overrideSprite == blackBat) {
			Bat.overrideSprite = null;
		} else {
			Bat.overrideSprite = blackBat;
		}

	}
		
	public void Update ()
	{
		if (Dead == 0) {
			if (Time.time - timeChange > 0.2) {
				moveBlackBat ();
				timeChange = Time.time;
			}

			if (Time.time - timeDif > Random.Range (.3f, 1.3f)) {
				float x = Random.Range (-630.0f, 630.0f);
				float y = Random.Range (-280.0f, 290.0f);
				//Generate an x and y value in the range below
				randomXCoord = 670 + x; // with float parameters, a random float
				randomYCoord = 335 + y;//transform.position.y;//+Random.Range(-3,3); // between -2.0 and 2.0 is returned
				timeDif = Time.time;
			}
			transform.Translate (new Vector2 (randomXCoord, randomYCoord));
			transform.position = new Vector2 (randomXCoord, randomYCoord);
		}
	}
}

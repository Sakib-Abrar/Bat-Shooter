using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour{

	public AudioClip gunshot;
	private AudioSource s;
	public Button buttonBack;
	public Text TimerText,ScoreText;
	public Texture2D customCursor;
	private CursorMode cursorMode;
	private Vector2 hotspot;
	private float timeLeft = 60.0f;
	private int minuteLeft=0;
	public int Score=0, HighScore=0, Hard=0;

	void Start () {
		s = gameObject.AddComponent<AudioSource>();
		s.clip = gunshot;
		if (SceneManager.GetActiveScene().name == "EasyScene") {
			HighScore=PlayerPrefs.GetInt ("EasyHighscore", 0);
			Hard = 0;
		} else {
			HighScore=PlayerPrefs.GetInt ("HardHighscore", 0);
			Hard = 1;
		}
		Score = 0;
        cursorMode = CursorMode.ForceSoftware;
		hotspot = new Vector2 (0,0);
		Cursor.SetCursor(customCursor,hotspot,cursorMode);
		Button btnBack = buttonBack.GetComponent<Button> ();
		btnBack.onClick.AddListener (LoadStart);
	}

	void LoadStart(){
		SceneManager.LoadScene ("StartScene",LoadSceneMode.Single);
	}

	public void OnPointerDown(PointerEventData eventData){

	}
		
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			if (minuteLeft != 0) {
				minuteLeft--;
				timeLeft = 59.9f;
			} else {
				LoadStart();
			}
		}
		if (timeLeft < 10) {
			TimerText.text = minuteLeft + ":0" + (int)timeLeft;
		} else {
			TimerText.text = minuteLeft + ":" + (int)timeLeft;
		}
		ScoreText.text = "Score : " + Score;
		if (Score > HighScore) {
			if (Hard == 1) {
				PlayerPrefs.SetInt ("HardHighscore", Score);
			} else {
				PlayerPrefs.SetInt ("EasyHighscore", Score);
			}
		}
		if (Input.GetMouseButtonDown (0) == true) {
			s.Play ();
		}

	}
}

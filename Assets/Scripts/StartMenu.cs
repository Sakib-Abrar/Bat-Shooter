using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
	public CanvasGroup EasyView,EasyHighView,HardHighView, HardView, PlayView;
	public Button buttonPlay,buttonEasy,buttonHard,buttonBack;
	public Text EasyHigh, HardHigh;
	public int HighScore;
	void Start () {
		EasyView.alpha = 0f;
		EasyView.blocksRaycasts = false;
		EasyView.interactable = false;
		HardView.alpha = 0f;
		HardView.blocksRaycasts = false;
		HardView.interactable = false;
		EasyHighView.alpha = 0f;
		EasyHighView.blocksRaycasts = false;
		EasyHighView.interactable = false;
		HardHighView.alpha = 0f;
		HardHighView.blocksRaycasts = false;
		HardHighView.interactable = false;
		Button btnPlay = buttonPlay.GetComponent<Button> ();
		Button btnEasy = buttonEasy.GetComponent<Button> ();
		Button btnHard = buttonHard.GetComponent<Button> ();
		Button btnBack = buttonBack.GetComponent<Button> ();
		btnPlay.onClick.AddListener (ClickedPlay);
		btnEasy.onClick.AddListener (LoadEasy);
		btnHard.onClick.AddListener (LoadHard);
		btnBack.onClick.AddListener (ClickedBack);
		HighScore=PlayerPrefs.GetInt ("EasyHighscore", 0);
		EasyHigh.text = "Highscore : " + HighScore;
		HighScore=PlayerPrefs.GetInt ("HardHighscore", 0);
		HardHigh.text = "Highscore : " + HighScore;
	}
	void ClickedPlay(){
		PlayView.alpha = 0f;
		PlayView.blocksRaycasts = false;
		PlayView.interactable = false;
		EasyView.alpha = 1f;
		EasyView.blocksRaycasts = true;
		EasyView.interactable = true;
		HardView.alpha = 1f;
		HardView.blocksRaycasts = true;
		HardView.interactable = true;
		EasyHighView.alpha = 1f;
		EasyHighView.blocksRaycasts = true;
		EasyHighView.interactable = true;
		HardHighView.alpha = 1f;
		HardHighView.blocksRaycasts = true;
		HardHighView.interactable = true;
	}
	void LoadEasy(){
		SceneManager.LoadScene ("EasyScene",LoadSceneMode.Single);
	}
	void LoadHard(){
		SceneManager.LoadScene ("ShootingScene",LoadSceneMode.Single);
	}
	void ClickedBack(){
		if (PlayView.alpha == 0f) {
			PlayView.alpha = 1f;
			PlayView.blocksRaycasts = true;
			PlayView.interactable = true;
			EasyView.alpha = 0f;
			EasyView.blocksRaycasts = false;
			EasyView.interactable = false;
			HardView.alpha = 0f;
			HardView.blocksRaycasts = false;
			HardView.interactable = false;
			EasyHighView.alpha = 0f;
			EasyHighView.blocksRaycasts = false;
			EasyHighView.interactable = false;
			HardHighView.alpha = 0f;
			HardHighView.blocksRaycasts = false;
			HardHighView.interactable = false;
		} else {
			Application.Quit ();
		}
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}


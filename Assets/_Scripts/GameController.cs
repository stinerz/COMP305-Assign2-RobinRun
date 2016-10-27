using UnityEngine;
using System.Collections;
using UnityEngine.UI;// reference to the UI namespace
using UnityEngine.SceneManagement;// reference to manage my scenes

	public class GameController : MonoBehaviour {
		// PRIVATE INSTANCE VARIABLES ++++++++++++++++++
		private int _livesValue;
		private int _scoreValue;

		[Header("UI Objects")] //++++++++++++++++++++++++
		public Text LivesLabel;
		public Text ScoreLabel;
		public Text GameOverLabel; 
		public Text FinalScoreLabel; 
		public Text WinnerLabel; 
		public Button RestartButton; 
		public GameObject Ninja; 
		public GameObject Castle; 
		public AudioSource CoinSound;
		public AudioSource Hit_Hurt8; 
		public AudioSource awesomeness; 


		// PUBLIC PROPERTIES +++++++++++++++++++++++++++
		public int LivesValue {
			get {
				return this._livesValue;
			}

			set {
				this._livesValue = value;
				if (this._livesValue <= 0) {
				this._gameOver (); 
				} else {
					this.LivesLabel.text = "Lives: " + this._livesValue;
				}
			}
		}

		public int ScoreValue {
			get {
				return this._scoreValue;
			}

			set {
				this._scoreValue = value;
				this.ScoreLabel.text = "Score: " + this._scoreValue;
			}
		}


		// Use this for initialization
		void Start () {
			this.LivesValue = 5;
			this.ScoreValue = 0;
			this.FinalScoreLabel.gameObject.SetActive (false);
			this.RestartButton.gameObject.SetActive (false);
			this.WinnerLabel.gameObject.SetActive (false); 
			this.GameOverLabel.gameObject.SetActive (false); 
		}

		// Update is called once per frame
		void Update () {
		}

	//Method displays final score and restart button once game is over 
	private void _gameOver(){
		this.GameOverLabel.gameObject.SetActive (true); 
		this.FinalScoreLabel.text = "FINAL SCORE: " + this.ScoreValue; 
		this.FinalScoreLabel.gameObject.SetActive (true); 
		this.RestartButton.gameObject.SetActive (true); 


		//will not be displayed on screen 
		this.WinnerLabel.gameObject.SetActive (false); 
		this.ScoreLabel.gameObject.SetActive (false); 
		this.LivesLabel.gameObject.SetActive (false); 
		this.Ninja.SetActive (false); 

	}

	//Method restarts the game when player clicks on the restart button 
	public void RestartGameButton_Click() {
		SceneManager.LoadScene ("Main");
	}

}
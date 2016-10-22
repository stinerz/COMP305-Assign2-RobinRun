using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Load scene when start button is clicked
	public void StartButton_Click() {
		SceneManager.LoadScene ("Main");
	}
}

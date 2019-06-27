using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecaoBandido : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			PlayerPrefs.SetInt("bandido", 1);
			SceneManager.LoadScene("SelecaoMapa");	
        }
		else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
			PlayerPrefs.SetInt("bandido", 2);
			SceneManager.LoadScene("SelecaoMapa");	
        }
		else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
			PlayerPrefs.SetInt("bandido", 3);
			SceneManager.LoadScene("SelecaoMapa");	
        }
		else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
			PlayerPrefs.SetInt("bandido", 4);
			SceneManager.LoadScene("SelecaoMapa");	
        }
		else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
			PlayerPrefs.SetInt("bandido", 5);
			SceneManager.LoadScene("SelecaoMapa");	
        }
		else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
			PlayerPrefs.SetInt("bandido", 6);
			SceneManager.LoadScene("SelecaoMapa");	
        }
		else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
			PlayerPrefs.SetInt("bandido", 7);
			SceneManager.LoadScene("SelecaoMapa");	
        }
		else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
			PlayerPrefs.SetInt("bandido", 8);
			SceneManager.LoadScene("SelecaoMapa");	
        }
		else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
			PlayerPrefs.SetInt("bandido", 9);
			SceneManager.LoadScene("SelecaoMapa");	
        }

	}
}

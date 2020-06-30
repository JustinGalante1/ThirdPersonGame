using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnGUI()
    {


        if (GUI.Button(new Rect(10,10,50,50), "Restart"))
        {
            SceneManager.LoadScene("Game");
        }

        if (GUI.Button(new Rect(10,70,50,50), "Exit"))
        {
            Application.Quit();
        }
    }
}

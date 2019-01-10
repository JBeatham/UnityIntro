using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
    public GameObject p1;
    public GameObject p2;

    // Use this for initialization
    void Start () {
        p1 = GameObject.FindGameObjectWithTag("Player 1");
        p2 = GameObject.FindGameObjectWithTag("Player 2");
    }
	
	// Update is called once per frame
	void Update () {
		if(p1 == null && p2 == null)
        {
            SceneManager.LoadScene("lose");
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        playerControl x = collision.gameObject.GetComponent<playerControl>();
        if (x != null)
        {
            SceneManager.LoadScene("win");
        }

    }
}

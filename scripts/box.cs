using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        ShotScript shot = collision.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            Destroy(shot.gameObject);
            Destroy(this.gameObject);
        }
    }
}

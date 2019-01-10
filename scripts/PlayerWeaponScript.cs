using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponScript : MonoBehaviour {
    
    public Transform projectilePrefab;

    public float shootingRate = 0.25f;

    private float shootCooldown;

	// Use this for initialization
	void Start () {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }	
	}

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            var shotTransform = Instantiate(projectilePrefab) as Transform;

            shotTransform.position = transform.position;
            

            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if(shot!= null)
            {
                shot.isEnemeyShot = isEnemy;
            }

            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if(move != null)
            {
                move.direction = -this.transform.up;
            }
        }
    }
    
}

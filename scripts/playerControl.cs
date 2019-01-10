using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public int player;
    bool shoot = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = GetComponent<Transform>().position.x;
        float y = GetComponent<Transform>().position.y;

        if (player == 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //print("UP");
                transform.position += new Vector3(0.0f, 0.1f, 0.0f);
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0.0f, 0.1f, 0.0f);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(0.1f, 0.0f, 0.0f);
                transform.eulerAngles = new Vector3(0, 0, 90);
            }


            shoot = Input.GetKeyDown(KeyCode.F);
            shoot |= Input.GetKeyDown(KeyCode.F);
        }
        else if(player == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0.0f, 0.1f, 0.0f);
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= new Vector3(0.0f, 0.1f, 0.0f);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.1f, 0.0f, 0.0f);
                transform.eulerAngles = new Vector3(0, 0, 90);
            }


            shoot = Input.GetKeyDown(KeyCode.RightControl);
            shoot |= Input.GetKeyDown(KeyCode.RightControl);
        }
       if (shoot)
        {
            
            PlayerWeaponScript weapon =GetComponentInChildren<PlayerWeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
                SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            Destroy(this.gameObject);            
        }
    }
}

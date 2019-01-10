using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public Transform target;
    public float speed = 100f;
    public GameObject p1;
    public GameObject p2;

    public float thrustForce = 100.0f;
    float countdown = 3;
    int dir;
    
    void Awake()
    {
        dir = Random.Range(0, 4);
        p1 = GameObject.FindGameObjectWithTag("Player 1");
        p2 = GameObject.FindGameObjectWithTag("Player 2");
    }

    void Update () {
        countdown -= Time.deltaTime;

        if (countdown < 0) {
            dir = Random.Range(0, 4);
            countdown = 3;
        }
        if (target == null)
        {
            findTarget();
            shamble();
        }
        else
        {
            if (!inRange(target))
            {
                target = null;
            }
            if (target != null)
            {
                pursue();
            }
        }
    }

    public void setTarget(Transform x)
    {
        this.target = x;
    }

    void findTarget() {
        if (p1 != null && inRange(p1.transform))
        {
            target = p1.transform;
        }
        else if (p2 != null && inRange(p2.transform)){
            target = p2.transform;
        }
    }

    bool inRange(Transform x)
    {
        float magX = (x.transform.position - transform.position).magnitude;
        if(magX < 9)
        {
            return true;
        }
        return false;
    }

    void pursue()
    {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 270;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.03f);
    }

    void shamble() {

        if (dir == 0)
        {
            transform.position += new Vector3(0.0f, 0.02f, 0.0f);
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if(dir == 1)
        {
            transform.position -= new Vector3(0.0f, 0.02f, 0.0f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(dir == 2)
        {
            transform.position -= new Vector3(0.02f, 0.0f, 0.0f);
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        else if(dir == 3)
        {
            transform.position += new Vector3(0.02f, 0.0f, 0.0f);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
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

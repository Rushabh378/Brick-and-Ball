using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject Ball;
    public int force = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setDirection();
        shootBalls();
    }

    void setDirection()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void shootBalls()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject ballInstance = Instantiate(Ball);
            ballInstance.transform.position = transform.position;
            ballInstance.GetComponent<Rigidbody2D>().velocity = Vector2.up * force;
        }
    }
}

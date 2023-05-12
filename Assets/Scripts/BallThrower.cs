using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject Ball;
    public int force = 1;

    public GameObject firePoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //getting mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // setting direction
        takeAimAt(mousePos);
        //shooting balls
        shootBallsAt(mousePos);
    }

    void takeAimAt(Vector3 mousePos)
    {
        if (Input.GetButton("Fire1"))
        {
            transform.LookAt(mousePos,Vector3.forward);
        }
    }

    void shootBallsAt(Vector3 mousePos)
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject ballInstance = Instantiate(Ball, transform.position, Quaternion.identity);
            ballInstance.GetComponent<Rigidbody2D>().AddForce(mousePos, ForceMode2D.Impulse);
        }
    }
}

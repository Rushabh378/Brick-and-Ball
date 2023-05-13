using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject Ball;
    //ball throwing force
    public int force = 50;
    //is player aiming the canon
    bool isAiming = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //getting mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            //taking aim
            isAiming = true;
            transform.LookAt(mousePos, Vector3.forward);
        }
            
        if (Input.GetMouseButtonUp(0) && isAiming)
        {
            isAiming = false;

            //shooting ball towards mouse direction
            GameObject ballInstance = Instantiate(Ball, transform.position, Quaternion.identity);
            ballInstance.GetComponent<Rigidbody2D>().AddForce(mousePos.normalized * force, ForceMode2D.Impulse);
        }  
    }
}

using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private int force = 50;
    [SerializeField][Range(0, 100)] private int ballValue = 20;
    private bool shooting = false;
    private bool isAiming = false;
    private void Update()
    {
        //getting direction to Aim & shoot
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        AimingAt(direction);
        if(shooting == false)
        {
            StartCoroutine(ShootingAt(direction));
        }
    }

    private void AimingAt(Vector3 direction)
    {
        if (Input.GetMouseButton(0))
        {
            isAiming = true;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private IEnumerator ShootingAt(Vector3 direction)
    {
        if (Input.GetMouseButtonUp(0) && isAiming)
        {
            isAiming = false;
            shooting = true;
            GameObject ballInstance;
            for (int i=0; i < ballValue; i++)
            {
                ballInstance = Instantiate(ball, transform.position, Quaternion.identity);
                ballInstance.GetComponent<Rigidbody2D>().AddForce(direction.normalized * force, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.20f);
            }
            shooting = false;
        }
    }
}

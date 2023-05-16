using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball;
    [SerializeField]
    private int Force = 50;
    private bool IsAiming = false;
    void Update()
    {
        //getting direction to shoot
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        AimingAt(MousePos);

        ShootingAt(MousePos);
    }

    private void ShootingAt(Vector3 mousePos)
    {
        if (Input.GetMouseButtonUp(0) && IsAiming)
        {
            IsAiming = false;

            //shooting ball towards mouse direction
            GameObject ballInstance = Instantiate(Ball, transform.position, Quaternion.identity);
            ballInstance.GetComponent<Rigidbody2D>().AddForce(mousePos.normalized * Force, ForceMode2D.Impulse);
        }
    }

    private void AimingAt(Vector3 mousePos)
    {
        if (Input.GetMouseButton(0))
        {
            IsAiming = true;
            transform.LookAt(mousePos, Vector3.forward);
        }
    }
}

using UnityEngine;

public class BallCollector : MonoBehaviour
{
    [SerializeField] private GameObject canon;
    private bool firstBall;
    private void Start()
    {
        firstBall = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CircleCollider2D>() != null && firstBall)
        {
            canon.transform.position = collision.transform.position;
            Destroy(collision.gameObject);
            firstBall = false;
        }
        if(collision.gameObject.GetComponent<CircleCollider2D>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}

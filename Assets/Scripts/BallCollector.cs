using UnityEngine;

public class BallCollector : MonoBehaviour
{
    [SerializeField] private GameObject canon;
    private bool firstBall;
    private int ballsRemaining;
    public bool ballsDestroyed;
    private void Start()
    {
        ballsRemaining = canon.GetComponent<Player>().ballValue;
        firstBall = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CircleCollider2D>() != null && firstBall)
        {
            canon.transform.position = collision.transform.position;
            Destroy(collision.gameObject);
            ballsRemaining--;
            firstBall = false;
        }
        if(collision.gameObject.GetComponent<CircleCollider2D>() != null)
        {
            Destroy(collision.gameObject);
            ballsRemaining--;
        }
        if(ballsRemaining <= 0)
        {
            ballsDestroyed = true;
        }
    }
}

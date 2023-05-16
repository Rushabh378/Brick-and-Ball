using UnityEngine;
using TMPro;
public class BrickFunctionality : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro DefenceText;
    [SerializeField][Range(0, 100)]
    private int Defence = 10;

    private void Start()
    {
        DefenceText.text = Defence.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if brick collided with Ball
        if (collision.gameObject.GetComponent<CircleCollider2D>() == true)
        {
            Defence--;
            DefenceText.text = Defence.ToString();

            if (Defence <= 0)
                Destroy(this.gameObject);
        }
            
    }
}

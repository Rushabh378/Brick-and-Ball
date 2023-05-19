using UnityEngine;

public class BrickWallGenerator : LevelManager
{
    [SerializeField] private GameObject brick;
    [SerializeField] private int length = 5;
    [SerializeField] private int height = 5;
    [SerializeField] private BallCollector balls;
    private int ballsRemaining;
    protected static int bricksValue = 0;
    private void Start()
    {
        LevelPettern();
    }
    private void Update()
    {
        if (bricksValue <= 0 && balls.ballsDestroyed)
        {
            nextLevel();
            LevelPettern();
        }
    }
    private void CreateBrick(int i, int j)
    {
        GameObject obj = Instantiate(brick, transform, false);
        Vector2 perentPos = transform.position;
        obj.transform.position = new Vector2(perentPos.x + i * 2.5f, perentPos.y + j * 1f);
        bricksValue++;
    }
    private void LevelPettern()
    {
        switch (level)
        {
            case Levels.level1:
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if(i == j)
                        {
                            continue;
                        }
                        CreateBrick(i, j);
                    }
                }
                break;
            case Levels.level2:
                for(int i = 0; i < length; i++)
                {
                    for(int j = i; j < height; j++)
                    {
                        CreateBrick(i, j);
                    }
                }
                break;
            case Levels.level3:
                for(int i = length; i>=0; i--)
                {
                    for(int j = i; j >= 0; j--)
                    {
                        CreateBrick(i, j);
                    }
                }
                break;
            default:
                Debug.Log("no more levels.");
                break;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public enum Levels { level1, level2, level3}
public class LevelManager : MonoBehaviour
{
    private LevelManager instance;
    private int maxLevel = 3;
    protected Levels level;

    private void Start()
    {
        level = Levels.level1;
    }

    public void nextLevel()
    {
        level++;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    private MenuManger instance;
    private bool paused = false;
    public MenuManger Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if(paused == false)
        {
            Pause();
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenu.SetActive(true);
            if (paused == false)
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        paused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        paused = false;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (mainMenu.activeSelf)
        {
            mainMenu.SetActive(false);
        }

    }
    public void OnExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}

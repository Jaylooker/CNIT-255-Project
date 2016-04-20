using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private GameObject player;
    private AudioClip gamemusic1;
    private int DemoScene;
    private int MenuScene;

    void Start()
    {
        MenuScene = 0;
        DemoScene = 1;
    }
    
    public void Play()
    {
        SceneManager.LoadScene(DemoScene);
    }
	public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }
}

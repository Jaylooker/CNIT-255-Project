using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private GameObject player;
    private AudioSource audiosource;
    private AudioClip gamemusic1;
    private int DemoScene;
    private int MenuScene;

    void Awake()
    {
        audiosource = gameObject.AddComponent<AudioSource>();
        gamemusic1 = Resources.Load("Assets/Audio/song1") as AudioClip;
        audiosource.clip = gamemusic1;
    }
    void Start()
    {
        MenuScene = 0;
        DemoScene = 1;
    }
    
    public void Play()
    {
        SceneManager.LoadScene(DemoScene);
  
        audiosource.Play();
        
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

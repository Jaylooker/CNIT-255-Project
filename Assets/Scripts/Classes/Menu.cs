using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    
    private int DemoScene;

    void Start()
    {
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
}

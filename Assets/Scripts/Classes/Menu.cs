using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    int DemoScene;

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

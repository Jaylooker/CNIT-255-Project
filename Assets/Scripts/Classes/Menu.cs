using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    Scene DemoLevel;

    void Start()
    {
        DemoLevel = SceneManager.GetSceneByName("Demo Level");
    }
    
    public void Play()
    {
        SceneManager.LoadScene(DemoLevel.name);
    }
	public void Quit()
    {
        Application.Quit();
    }
}

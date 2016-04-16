using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    string GameStartName = "DemoScene";
    private Scene DemoScene;

    void Start()
    {
        DemoScene = SceneManager.GetSceneByName(GameStartName);
    }
    
    public void Play()
    {
        SceneManager.LoadScene(DemoScene.name);
    }
	public void Quit()
    {
        Application.Quit();
    }
}

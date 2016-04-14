using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public void Play(int SceneToPlay)
    {
        SceneManager.LoadScene(SceneToPlay);
    }
	public void Quit()
    {

    }
}

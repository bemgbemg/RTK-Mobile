using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

    void Start()
    {

    }

    public void PlayIGame()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayIIGame()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayIIIGame()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayLearnGame()
    {
        SceneManager.LoadScene(5);
    }
}

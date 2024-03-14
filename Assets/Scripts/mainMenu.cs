using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenu : MonoBehaviour
{
    public string FirstLevel;
    public string Credits;
    public string Options;
    public string MainMenu;
    public string Manual;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void start()
    {

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(FirstLevel);
    }

    public void options()
    {
        SceneManager.LoadScene(Options);
    }
    public void credits()
    {
        SceneManager.LoadScene(Credits);
    }
    public void menu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void manual()
    {
        SceneManager.LoadScene(Manual);
    }

    public void quit()
    {
        Application.Quit();
    }
}


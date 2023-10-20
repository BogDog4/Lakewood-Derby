using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startButtons;
    public GameObject secondMenu;
    public GameObject thirdMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SingleplayerClick()
    {
        GetComponent<Animator>().SetBool("SlideUp", true);
        startButtons.GetComponent<Animator>().SetBool("MenuOpen", true);
        secondMenu.GetComponent<Animator>().SetBool("MenuOpen", true);
    }

    public void GhostRaceClick()
    {
        thirdMenu.GetComponent<Animator>().SetBool("MenuOpen", true);
        secondMenu.GetComponent<Animator>().SetBool("MenuOpen", false);
    }

    public void LonelyTownClick()
    {
        SceneManager.LoadScene("racetrack");
    }
}

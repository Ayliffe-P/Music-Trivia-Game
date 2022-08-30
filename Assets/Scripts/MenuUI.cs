using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MenuUI : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingCanvas;
    public TMP_Dropdown teamNum;
    public TMP_Dropdown genreType;
    public Toggle countryOrgin;
    public Toggle YearOfRelease;
    public Toggle multipleChoice;
    public Slider volumeSlider;

    void Start()
    {
        setValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playButton() {

        SceneManager.LoadScene(01);
        
    }
    public void quitButton()
    {

        Application.Quit();

    }
    public void settingsButton()
    {

        mainCanvas.SetActive(false);
        settingCanvas.SetActive(true);

    }
    public void backButton() {

        setValue();
        mainCanvas.SetActive(true);
        settingCanvas.SetActive(false);

    }

    public void setValue() {

        //Debug.Log((GenreType)genreType.value);
        //Debug.Log(teamNum.value);
        Settings._instance.genreType = (GenreType)genreType.value;
        Settings._instance.numOfTeams = teamNum.value + 1;
        Settings._instance.countryOrigin = countryOrgin.isOn;
        Settings._instance.yearReleased = YearOfRelease.isOn;
        Settings._instance.multipleChoice = multipleChoice.isOn;
        Settings._instance.volume = volumeSlider.value;

    }
}

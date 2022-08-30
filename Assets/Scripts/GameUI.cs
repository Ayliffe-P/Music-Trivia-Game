using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI answerText;
    public GameManager manager;
    public GameObject canvas;
    public Button submitButton;

    void Start()
    {
        StartCoroutine("startGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator startGame() {
        submitButton.enabled = false;
        canvas.SetActive(true);
        mainText.text = "Playing Audio in: ";
        yield return new WaitForSeconds(2);
        mainText.text = "3";
        yield return new WaitForSeconds(1);
        mainText.text = "2";
        yield return new WaitForSeconds(1);
        mainText.text = "1";
        yield return new WaitForSeconds(1);
        mainText.text = "Listen Carefully!";
        yield return new WaitForSeconds(1);
        canvas.SetActive(false);
        manager.playNextSong();
        submitButton.enabled = true;
    }

    public void DisplayAnswers() {

        answerText.text = "You Got " + manager.score + " Answers Right! \n" ;
        int index = 1;

        foreach (var item in manager.gameGenre.songs)
        {

            answerText.text += "Song Number: " + index + "\t| " + item.artist + "\t| " + item.yearOfRelease + "\t| "+ item.countryOfOrigin + "\n";
            index = index + 1;
        }
    }
}

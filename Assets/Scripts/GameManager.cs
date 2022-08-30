using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<string> countries;
    public List<string> years;
    public List<string> artists;

    //List<Song> gameSongs;
    public GameObject dropDownPrefab;
    public GameObject inputFieldPrefab;

    public GameObject yearOfRelease;
    public GameObject countryOrigin;
    public GameObject artistField;

    public Genre allSongs;
    public Genre GenreRB;
    public Genre GenreAlt;
    public Genre gameGenre;

    public int score;

    public GameUI gameUI;

    public int index;

    public System.Random rnd ;

    public AudioSource audioSource;

    public void resetGame() { }

    public void setup() {
        
        switch (Settings._instance.genreType)
        {

            case GenreType.RB:
                Genre temp = GenreRB;
                Debug.Log(temp.songs.Count);
                for (int i = 0; i < 3; i++)
                {
                    Song tempSong = temp.songs[rnd.Next(0, temp.songs.Count)];
                    gameGenre.songs.Add(tempSong);
                    temp.songs.Remove(tempSong);
                }
                break;
            case GenreType.Alt:
                 temp = GenreAlt;
                for (int i = 0; i < 3; i++)
                {
                    Song tempSong = temp.songs[rnd.Next(0, temp.songs.Count)];
                    gameGenre.songs.Add(tempSong);
                    temp.songs.Remove(tempSong);
                }
                break;
            default:
                break;
        }

        if (Settings._instance.multipleChoice == true)
        {
            artistField = Instantiate(dropDownPrefab);
            artistField.transform.parent = answerUI._instance.panel.transform;
            //artistField.GetComponent<TMP_Dropdown>().text = "Enter Artist Name";

            if (Settings._instance.countryOrigin == true)
            {
                countryOrigin = Instantiate(dropDownPrefab);
                countryOrigin.transform.parent = answerUI._instance.panel.transform;
                //countryOrigin.GetComponent<TMP_Dropdown>().text = "Enter Country of Origin";
            }

            if (Settings._instance.yearReleased == true)
            {
                yearOfRelease = Instantiate(dropDownPrefab);
                yearOfRelease.transform.parent = answerUI._instance.panel.transform;
                //yearOfRelease.GetComponent<TMP_Dropdown>().text = "Enter Year of Release";
            }
        }
        else {

            artistField = Instantiate(inputFieldPrefab);
            artistField.transform.parent = answerUI._instance.panel.transform;
            artistField.GetComponent<TMP_InputField>().text = "Enter Artist Name";

            if (Settings._instance.countryOrigin == true)
            {
                countryOrigin = Instantiate(inputFieldPrefab);
                countryOrigin.transform.parent = answerUI._instance.panel.transform;
                countryOrigin.GetComponent<TMP_InputField>().text = "Enter Country of Origin";
            }

            if (Settings._instance.yearReleased == true)
            {
                yearOfRelease = Instantiate(inputFieldPrefab);
                yearOfRelease.transform.parent = answerUI._instance.panel.transform;
                yearOfRelease.GetComponent<TMP_InputField>().text = "Enter Year of Release";
            }
            


        }
        //playNextSong();
        
    
    
    }

    public void playNextSong() {
        audioSource.volume = 0;
        audioSource.clip = gameGenre.songs[index]._audio;
        
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
        StartCoroutine(ChangeVolumeCoroutine(audioSource.clip));

        if (Settings._instance.multipleChoice == true)
        {
            populateAnswers();
        }
       
        //index = index + 1;
        


    }

    public void populateAnswers() {

        {
            List<string> answers = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                string temp = artists[rnd.Next(0, countries.Count)];
                while (answers.Contains(temp) || temp == gameGenre.songs[index].artist.ToLower())
                {
                    temp = artists[rnd.Next(0, artists.Count)];

                }
                answers.Add(temp);
            }

            answers.Insert(rnd.Next(0, 3), gameGenre.songs[index].artist);

            artistField.GetComponent<TMP_Dropdown>().ClearOptions();
            artistField.GetComponent<TMP_Dropdown>().AddOptions(answers);
        }

        if (Settings._instance.countryOrigin == true)
        {
            List<string> answers = new List<string>();

            for (int i = 0; i < 3; i++)
            {
            string temp = countries[rnd.Next(0, countries.Count)];
            while (answers.Contains(temp) || temp == gameGenre.songs[index].countryOfOrigin.ToLower())
            {
                temp = countries[rnd.Next(0, countries.Count)];

            }
                answers.Add(temp);
            }

            answers.Insert(rnd.Next(0, 3), gameGenre.songs[index].countryOfOrigin);

            countryOrigin.GetComponent<TMP_Dropdown>().ClearOptions();
            countryOrigin.GetComponent<TMP_Dropdown>().AddOptions(answers);
        }

        if (Settings._instance.yearReleased == true)
        {
            List<string> answers = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                string temp = years[rnd.Next(0, years.Count)];
                while (answers.Contains(temp) || temp == gameGenre.songs[index].yearOfRelease.ToLower())
                {
                    temp = years[rnd.Next(0, years.Count)];

                }
                answers.Add(temp);
            }

            answers.Insert(rnd.Next(0, 3), gameGenre.songs[index].yearOfRelease);

            yearOfRelease.GetComponent<TMP_Dropdown>().ClearOptions();
            yearOfRelease.GetComponent<TMP_Dropdown>().AddOptions(answers);
        }

       


    }

    private IEnumerator ChangeVolumeCoroutine(AudioClip temp)
    {
        while (audioSource.volume < Settings._instance.volume)
        {
            audioSource.volume += 0.0001f;
            yield return null;
        }
        
    }


    public void checkAnswers() {
       
        if (Settings._instance.multipleChoice == true)
        {
           // Debug.Log(artistField.GetComponent<TMP_Dropdown>().options[artistField.GetComponent<TMP_Dropdown>().value].text);
            if (artistField.GetComponent<TMP_Dropdown>().options[artistField.GetComponent<TMP_Dropdown>().value].text.ToLower() == gameGenre.songs[index].artist.ToLower() )
            {

                score = score + 1;
            }
            if (Settings._instance.yearReleased == true)
            {
                if (yearOfRelease.GetComponent<TMP_Dropdown>().options[yearOfRelease.GetComponent<TMP_Dropdown>().value].text.ToLower() == gameGenre.songs[index].yearOfRelease.ToLower())
                {

                    score = score + 1;
                }
            }
            if (Settings._instance.countryOrigin == true)
            {
                if (countryOrigin.GetComponent<TMP_Dropdown>().options[countryOrigin.GetComponent<TMP_Dropdown>().value].text.ToLower() == gameGenre.songs[index].countryOfOrigin.ToLower())
                {

                    score = score + 1;
                }
            }




        } else if (Settings._instance.multipleChoice == false) {

            if (artistField.GetComponent<TMP_InputField>().text.ToLower() == gameGenre.songs[index].artist.ToLower())
            {
                score = score + 1;
            }

            if (Settings._instance.yearReleased == true)
            {
                if (yearOfRelease.GetComponent<TMP_InputField>().text.ToLower() == gameGenre.songs[index].yearOfRelease.ToLower())
                {
                    score = score + 1;
                }
            }
            if (Settings._instance.countryOrigin == true)
            {
                if (countryOrigin.GetComponent<TMP_InputField>().text.ToLower() == gameGenre.songs[index].countryOfOrigin.ToLower())
                {
                    score = score + 1;
                }
            }

        }

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        Debug.Log(index + " " + gameGenre.songs.Count);
        if (index < gameGenre.songs.Count-1)
        {
            startNextSong();
        }
        else {

            gameUI.DisplayAnswers();
        
        }
      
        
    }

    public void startNextSong() { 
    index = index + 1;
        
    StartCoroutine(gameUI.startGame());

    }





    void Start()
    {
        
        rnd = new System.Random();
        setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

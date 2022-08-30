using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GenreType { RB, Alt }
public class Settings : MonoBehaviour
{
    public static Settings _instance;

    public int numOfTeams;
    public GenreType genreType;
    public bool countryOrigin;
    public bool yearReleased;
    public bool multipleChoice;
    public double volume;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else {
           DontDestroyOnLoad(_instance = this);
        }
    }

    void Start()
    {
        
    }

    public void setSettings(int numTeams) { 
    


    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

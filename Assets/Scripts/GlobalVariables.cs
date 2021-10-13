using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour
{

    public static GlobalVariables Instance;

    public int score;
    public int HighScore;

    public Text Pontos_text;
    public Text HighScore_text;

    public bool jogando = false;

    public AudioSource AS_Music;
    public AudioClip[] Songs = new AudioClip[2];


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("Highscore", 0);
        AS_Music.clip = Songs[0];
        AS_Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(Pontos_text.text != score.ToString())
        {
            Pontos_text.text = score.ToString();
        }

        if(HighScore < score)
        {
            HighScore = score;
        }

        if (HighScore_text.text != HighScore.ToString())
        {
            HighScore_text.text = HighScore.ToString();
        }
    }

    public void Ended()
    {
        PlayerPrefs.SetInt("Highscore", HighScore);
        score = 0;
        jogando = false;
        AS_Music.clip = Songs[0];
        AS_Music.Play();
    }

    public void StartGame()
    {
        jogando = true;
        AS_Music.clip = Songs[1];
        AS_Music.Play();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using System.IO;


public class GameManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    public static bool playerIsDead = false;
    public static bool enemy_killed = false;
    public static float timer = 0f;
    public static int damage_taken = 0;
    public Text time_used_text;
    private Text damage_taken_text;
    private Text Game_end_text;
    private Text Highest_score_text;
    private int menuCounter;
    public GameObject menu;
    [SerializeField]
    int highest_score;
    [SerializeField]
    PlayerData player_data;
    
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            damage_taken_text = GameObject.Find("EndCanvas")?.transform.Find("Persentage")?.GetComponent<Text>();
            time_used_text = GameObject.Find("EndCanvas")?.transform.Find("Time_used")?.GetComponent<Text>();
            Game_end_text = GameObject.Find("EndCanvas")?.transform.Find("GameOver")?.GetComponent<Text>();
            Highest_score_text = GameObject.Find("EndCanvas")?.transform.Find("Highest")?.GetComponent<Text>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            damage_taken = 0;
            timer = 0;
            Time.timeScale = 1;
            menuCounter = 0;
            playerIsDead = false;
            enemy_killed = false;
            player_data = new PlayerData();

        }
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            timer += 1f * Time.deltaTime;
            time_used_text.text = "Time " + Math.Round(timer, 2);
        }
        
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            Time.timeScale = 1;
            if (enemy_killed)
            {
                Game_end_text.text = "Completed";
            }
            player_data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("jsondata"));
            highest_score = player_data.highest_score;
            int score = (int)(damage_taken * 100 / 110);
            if (highest_score< score)
            {
                player_data.highest_score = score;
                highest_score = score;
            }
            PlayerPrefs.SetString("jsondata", JsonUtility.ToJson(player_data));
            Highest_score_text.text = "Highest "+highest_score +"%";
            damage_taken_text.text = score+"%";
            time_used_text.text = "Time " + Math.Round(timer, 2);
            
            
        }
       
        if ((playerIsDead || enemy_killed) & SceneManager.GetActiveScene().buildIndex == 1)
        {
            levelLoader.LoadSpecificScene("End");
        }
    }

    public void PlayerIsDead()
    {
        playerIsDead = true;
    }

    public void Enemy_killed()
    {
        enemy_killed = true;
    }

    public void damage_counter()
    {
        damage_taken += 1;
    }
    



    #region menu
    public void ActivateMenu()
    {
        if (menuCounter == 0)
        {
            StartCoroutine(Menu());
            menuCounter += 1;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            StartCoroutine(DeMenu());
            menuCounter = 0;
        }

    }
    IEnumerator Menu()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        RectTransform menuPos = menu.GetComponent<RectTransform>();
        menuPos.anchoredPosition = new Vector3(0, 0, 0);

    }

    IEnumerator DeMenu()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        RectTransform menuPos = menu.GetComponent<RectTransform>();
        menuPos.anchoredPosition = new Vector3(0, 2300, 0);

    }

    public void BackToHomePage()
    {
        damage_taken = 0;
        timer = 0;
        Time.timeScale = 1;
        menuCounter = 0;
        playerIsDead = false;
        enemy_killed = false;
        levelLoader.LoadSpecificScene("Start");

    }





    public void QuitGame()
    {
        StartCoroutine(QuitG());
    }

    IEnumerator QuitG()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Application.Quit();
    }

   
    #endregion


    [System.Serializable]
    public class PlayerData
    {
        public int highest_score;
    }
}

using System;
using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Image fadeImage;
    //Butonları buton olarak ayarlamama gerek yok çünkü buton fonksiyonlarını yönetmeyeceğiz.
    [SerializeField] private GameObject goMenuBtn; 
    [SerializeField] private GameObject restartBtn;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;

    [SerializeField] GameObject spawner; 
    public int score;
    int highScore;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeImage.gameObject.SetActive(true); // Bunu sonrasında kaldırabiliriz. 
        fadeImage.color = Color.clear;

        goMenuBtn.SetActive(false);
        restartBtn.SetActive(false);
        spawner.SetActive(true);
        highScoreTxt.gameObject.SetActive(false);
        scoreTxt.gameObject.SetActive(false);

        highScore = PlayerPrefs.GetInt("highScore",0);

        //Buraya arka fon müziği gelecek
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode(){

        float elapsed = 0f; 
        float duration = 0.5f;

        while(elapsed<duration){
            float t = Mathf.Clamp01(elapsed/duration);
            fadeImage.color = Color.Lerp(Color.clear,Color.white,t);
            Time.timeScale= 1f-t;

            elapsed += Time.unscaledDeltaTime;
            yield return null;
            
        }
        goMenuBtn.SetActive(true);
        restartBtn.SetActive(true);
        scoreTxt.gameObject.SetActive(true);
        highScoreTxt.gameObject.SetActive(true);
        
    }
    public void GameOver(){
        StartCoroutine(Explode());
        spawner.SetActive(false);
        scoreTxt.text = "Your Score: "+score;
        if(score>highScore){
            PlayerPrefs.SetInt("highScore",score);
            highScoreTxt.text= "New High Score!";
        }else{
            highScoreTxt.text="High Score: "+highScore;
        }
        //Buraya ses gelecek

    }

    public void GoMenu(){
        SceneManager.LoadScene(0);
    }
    public void Restart(){
        SceneManager.LoadScene(1);
    }
}

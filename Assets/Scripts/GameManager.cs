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

    bool isMuted = false;

    [Header("Sound")]
    [SerializeField] AudioSource source1;
    [SerializeField] public AudioSource source2;
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip endMusic;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetInt("mute")==1){
            isMuted=true;
        }else{
            isMuted=false;
        }
        Time.timeScale=1f;
        fadeImage.gameObject.SetActive(true); // Bunu sonrasında kaldırabiliriz. 
        fadeImage.color = Color.clear;

        goMenuBtn.SetActive(false);
        restartBtn.SetActive(false);
        spawner.SetActive(true);
        highScoreTxt.gameObject.SetActive(false);
        scoreTxt.gameObject.SetActive(false);

        highScore = PlayerPrefs.GetInt("highScore",0);


        //arka fon müziği (Müzik henüz bulunmadı)
        //playMusic(source1,gameMusic,isLoop:true);


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            isMuted=!isMuted;
        }
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
        playMusic(source1,endMusic);
    }

    public void GoMenu(){
        SceneManager.LoadScene(0);
    }
    public void Restart(){
        SceneManager.LoadScene(1);
    }


    /// <summary>
    /// Bu fonksiyon, eğer kaynakta ses dosyası varsa kullanılacak.
    /// </summary>
    /// <param name="source">Çalınacak AudioSource objesi.</param>
    public void playMusic(AudioSource source){
        if(!isMuted){
            source.Play();
        }
    }
    /// <summary>
    /// Bu fonksiyon belirli bir AudioSource'taki sesi durdurup başka bir AudioClip ile çalar.
    /// </summary>
    /// <param name="clip">Çalınacak AudioClip objesi.</param>
    /// <param name="source">Çalınacak AudioSource objesi</param>
    public void playMusic(AudioSource source,AudioClip clip,bool isLoop = false){
        if(!isMuted){
            if(source.isPlaying == true){
                source1.Stop();
            }
            source.clip = clip;
            source.loop= isLoop;
            source.Play();
        }
    }
}

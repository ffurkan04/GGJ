using System;
using System.Collections;
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeImage.gameObject.SetActive(true); // Bunu sonrasında kaldırabiliriz. 
        fadeImage.color = Color.clear;

        goMenuBtn.SetActive(false);
        restartBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Explode(){

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
        
    }

    public void GoMenu(){
        SceneManager.LoadScene(0);
    }
    public void Restart(){
        SceneManager.LoadScene(Convert.ToString(SceneManager.GetActiveScene()));
    }
}

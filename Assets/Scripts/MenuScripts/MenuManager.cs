using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]GameObject[] buttons; 
    [SerializeField]GameObject Text; 
    bool isOpen;

    bool isMute=false;
    
    int mute(){
        if(isMute == false){ return 0;}else{return 1;}
    }

    void Start()
    {
        isOpen=false;
        Text.SetActive(false);
    }

    public void GameStart(){
        PlayerPrefs.SetInt("mute",mute());
        SceneManager.LoadScene(1);
    }
    public void setActiveOfGamePlayMenu(){
        if(isOpen == false){
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
            Text.SetActive(true);
            isOpen=true;
        }else if(isOpen == true){
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
                Text.SetActive(false);
                isOpen=false;
            }
        }
    }
    public void Mute(){
        isMute=!isMute;
    }
}

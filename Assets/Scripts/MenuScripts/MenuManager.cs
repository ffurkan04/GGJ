using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]GameObject[] buttons; 
    [SerializeField]GameObject Text; 
    [Header("Mute Button Sprites")]
    [SerializeField] Sprite _unmutedSprite;
    [SerializeField] Sprite _mutedSprite;
    [SerializeField] GameObject _muteButton;
    Image image;
    bool isOpen;

    bool isMute=false;
    
    int mute(){
        if(isMute == false){ return 0;}else{return 1;}
    }

    void Start()
    {
        isOpen=false;
        Text.SetActive(false);
        image = _muteButton.GetComponent<Image>();
        if(isMute==false){ // ses açık
            image.sprite =_unmutedSprite; 
        }else{ //ses kapalı
            image.sprite = _mutedSprite;
        }
    }

    public void GameStart(){
        PlayerPrefs.SetInt("mute",mute());
        SceneManager.LoadScene(2); //Hikaye kısmı
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
        if(isMute==false){ // ses açık
            image.sprite =_unmutedSprite; 
        }else{ //ses kapalı
            image.sprite = _mutedSprite;
        }
    }
}

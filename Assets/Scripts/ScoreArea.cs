using TMPro;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] GameManager manager;
    void Start()
    {
        manager.score = 0; 
        scoreTxt.text="Score: 0";
    }

    // Update is called once per frame
 


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food")){
            manager.score +=5;
            scoreTxt.text="Score: "+manager.score;
            Destroy(collision.gameObject);
        }else if(collision.gameObject.CompareTag("bubble")){
            manager.score -=5;
            scoreTxt.text="Score: "+ manager.score;
            Destroy(collision.gameObject);
        }
        
    
    }
}

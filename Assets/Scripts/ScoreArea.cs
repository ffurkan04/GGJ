using TMPro;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    int score; 
    [SerializeField] TextMeshProUGUI scoreTxt;
    void Start()
    {
        score = 0; 
        scoreTxt.text="Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food")){
            score +=5;
            scoreTxt.text="Score: "+score;
            Destroy(collision.gameObject);
        }
        //eğer bozuk baloncuktan gelen yemek olursa onu da score azaltacak şekilde yapacağız.
    
    }
}

using UnityEngine;

public class Buble : MonoBehaviour
{
    [SerializeField]GameObject[] foods; 
    [SerializeField]AudioClip sound;
    private GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="blade"){
            GameObject prefab = foods[Random.Range(0,foods.Length)];
            //Ses efekti
            manager.playMusic(manager.source2,sound);

            GameObject food = Instantiate(prefab, this.gameObject.transform.position,Quaternion.identity);

            //animasyon kodu burada olacak
            Destroy(this.gameObject);

            
        }
    }
}

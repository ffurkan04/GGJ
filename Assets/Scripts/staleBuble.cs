using UnityEngine;

public class staleBuble : MonoBehaviour
{
    GameManager manager;
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
            Debug.Log("Game is over");
            StartCoroutine(manager.Explode());
        }
    }
}

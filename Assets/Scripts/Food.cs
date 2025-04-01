using UnityEngine;

public class Food : MonoBehaviour
{

    [SerializeField] Sprite[] sprite;
    SpriteRenderer renderer;

    void Awake()
    {
        renderer= GetComponent<SpriteRenderer>();

        renderer.sprite = sprite[Random.Range(0,sprite.Length)];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

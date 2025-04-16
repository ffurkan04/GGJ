using System.Collections;
using Unity.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider2D spawnArea; 
    public GameObject[] bublesPrebs;
    
    public GameObject staleBublePreb; 
    [Range(0f,1f)]public float staleChance= 0.05f;
    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay=1f;

    [SerializeField]public float minAngle =-15f;
    [SerializeField]public float maxAngle = 15f;

    public float minForce =18f;
    public float maxForce = 22f;

    [SerializeField] float maxLifeTime=60f;

    void Awake()
    {
        spawnArea = GetComponent<Collider2D>();
    }

    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn(){
        yield return new WaitForSeconds(2f);

        while(enabled){
            GameObject prefab = bublesPrebs[Random.Range(0,bublesPrebs.Length)];

             if(Random.value<staleChance){
                 prefab = staleBublePreb;
            }

            Vector2 position = new Vector2{
                x=Random.Range(spawnArea.bounds.min.x,spawnArea.bounds.max.x),
                y=Random.Range(spawnArea.bounds.min.y,spawnArea.bounds.max.y),
            };

            Quaternion rotation = Quaternion.Euler(0f,0f,Random.Range(minAngle,maxAngle));

            GameObject buble = Instantiate(prefab,position,rotation);

            Destroy(buble,maxLifeTime);

            float force =Random.Range(minForce,maxForce);

            buble.GetComponent<Rigidbody2D>().AddForce(Vector2.right*force,ForceMode2D.Impulse);
            buble.GetComponent<Rigidbody2D>().AddForce(Vector2.up*1.20f,ForceMode2D.Impulse);
            yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));
            
        }
    }
}

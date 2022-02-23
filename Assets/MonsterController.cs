using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite monster;
    public int score = 0;
    public int count = 0;
    
    
 
    List<GameObject> Monsters= new List<GameObject>();
    
    public GameObject Monster;

    void Start()
    {

      //  print("Drag the Bird and Kill the Monsters\n If all monsters are killed press enter to move to next level");
       Monsters.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
       
     // print(Monsters.Count);
      
    }
    private void Awake()
    {
       
    }



    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdMovement birdMovement = collision.gameObject.GetComponent<BirdMovement>();
        if (birdMovement != null || collision.gameObject.tag == "crate")
        {

           
            GetComponent<SpriteRenderer>().sprite = monster;
            //GetComponent<Rigidbody2D>().gravityScale= 1;
            if (collision.gameObject.tag == "Monster")
            {
                score = score + 10;
                Debug.Log(score);
            }
            Destroy(gameObject);
            KilledMonsters(Monster);





        }
       

    }






    public void KilledMonsters(GameObject monster)
    {


        
        if (Monsters.Contains(monster))
        {
            Monsters.Remove(monster);
        }

        print(Monsters.Count);

        if (Monsters.Count == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
     






}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BirdMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
   // public float speed;
    Vector2 birdStartPosition;
    public float speed;
    float maxDragDistance=3f;
    
     
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.isKinematic = true;
        birdStartPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;

     
    }
    private void OnMouseUp()
    {
        
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 currentPosition = rb.position;
        Vector2 direction= birdStartPosition - currentPosition;
        direction.Normalize();
        rb.isKinematic = false;
        speed = Random.Range(500f, 2000f);
        rb.AddForce(direction *speed);
    }
    private void OnMouseDrag()

    {
     
        Vector3 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
        if(desiredPosition.x>birdStartPosition.x)
        {
            desiredPosition.x = birdStartPosition.x;
        }
        // transform.position = (new Vector3(mousePosition.x, mousePosition.y,transform.position.z));
        float distance = Vector2.Distance(desiredPosition, birdStartPosition);
        if(distance>maxDragDistance)
        {
            Vector2 direction = desiredPosition - birdStartPosition;
            direction.Normalize();
            desiredPosition = birdStartPosition + (direction * maxDragDistance);
        }

       rb.position = desiredPosition;
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());


        
       
    }

    IEnumerator ResetAfterDelay()
    {
       //Debug.Log("This is a  coroutine function");
        yield return new WaitForSeconds(5f);
        //Debug.Log("This is a  coroutine function");
        rb.position = birdStartPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;

    }

}


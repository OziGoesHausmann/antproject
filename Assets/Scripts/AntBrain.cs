using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBrain : MonoBehaviour
{

    [Header("RandomMovement")]
    public float accelerationTime = 2f;
    public float maxSpeed2 = 5f;
    private Vector2 movement;
    private float timeLeft;
    public bool randomMove;

    [Header("PheromoneTrack")]
    public GameObject walkingTrack;
    public GameObject foodTrack;
    private float i = 0;

    [Header("FoodFinder")]
    public bool foodFound;

    // Start is called before the first frame update
    void Start()
    {
        randomMove = true;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(movement * maxSpeed2);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > i)
        {
            i += 0.5f;
            InstantiatePheromone();
        }

        if (randomMove)
        {
            MovingRandom();
        }



    }


    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            randomMove = false;
        }
    }



    void MovingRandom()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }

        Vector2 dir = transform.GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }



    void InstantiatePheromone()
    {
        if (!foodFound)
        {
            Instantiate(walkingTrack, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(foodTrack, transform.position, transform.rotation);
        }
    }

    void FollowTrack()
    {

    }

    void FindFood()
    {

    }

//    1.Raycast in the direction you are moving.
    //2.In your update once the raycast gets within a certain distance say 0.2 unity units..
    //3.dont allow movement in that direction
    //4.and so once the player pushes a button in that direction you raycast to see if there a wall
    //For this setup to work you just will need 8 raycasts two for each direction you can move to define the width of the object.
}


    

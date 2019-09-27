using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Prefab for instantating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    //Distance where the AppleTree moves
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Chance that the Apples will be instantained
    public float secondsBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
        //Dropping apples every second
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);

    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movment
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if ( pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Moves right
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Moves left
        }
       
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //Change Direction
        }
    }
        
}

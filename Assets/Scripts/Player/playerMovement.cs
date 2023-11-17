using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool MoveRight;
    public bool jump;

    // Get movement inputs on update so we don't miss them, apply them on fixed update to keep in sync
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight = true;
        }
    }

    
    void FixedUpdate()
    {
        if(MoveRight)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(3f, 0f));
            MoveRight = false;
        }

        if (jump)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0f, 3f));
            jump = false;
        }
    }

}

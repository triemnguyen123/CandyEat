using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.IncrementScore();
        }
        else if (other.gameObject.tag == "Litmit Screen")
        {
            Destroy(gameObject);
            GameManager.instance.DecreaseLife();
        }
    }

}

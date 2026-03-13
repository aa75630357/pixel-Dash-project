using System.Data;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static float speed = 5f;
    //static可以共享到其他cod裡面做使用


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime(每秒)
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        
        if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}

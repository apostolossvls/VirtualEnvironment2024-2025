using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHello : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name+"Hello World from Start!");
    }

    // Update is called once per frame
    void Update()
    {
        print(gameObject.name + "Hello World from Update!");

        float newX = transform.position.x;
        float newY = transform.position.y;
        float newZ = transform.position.z + speed * Time.deltaTime;

        //1M/FRAME
        //1M/SEC

        transform.position = new Vector3(newX, newY, newZ);
    }
}

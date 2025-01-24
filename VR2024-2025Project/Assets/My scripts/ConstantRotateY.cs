using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotateY : MonoBehaviour
{
    [Header("Properties")]
    [Range(-5f, 100f)]
    public float angularSpeed = 5;
    [Space (20)]
    [SerializeField] private int MyInt = 3;
    protected string MyName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5, 0);
    }
}

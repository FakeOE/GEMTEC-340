using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 7.0f;
    [SerializeField] private float _xLimit = 6.5f;

    [SerializeField] private KeyCode _upKey;
    [SerializeField] private KeyCode _downKey;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_upKey) && transform.position.x < _xLimit)
        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey(_downKey) && transform.position.x > -_xLimit)
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }
}
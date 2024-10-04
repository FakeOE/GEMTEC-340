using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlFlow : MonoBehaviour
{

    public bool flag = false;
   
    // Start is called before the first frame update
    void Start()
    {
        if (flag == true)
            for (int i = 2; i <= 10; i++)
        {
            Debug.Log($"The {i} power of 2 is");Debug.Log(Mathf.Pow(2, i));
            
        }

        if (flag == false){
            
            Debug.Log("Flag is not set.");
            
        }
        
        



    }  








    // Update is called once per frame
    void Update()
    {
        
    }
}

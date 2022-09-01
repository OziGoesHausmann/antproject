using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    void Start()
    {
        ItemManager.Self.AddItem("22A_40_chip", 1, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

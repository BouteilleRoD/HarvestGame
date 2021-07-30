using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] private SeedType seedType = SeedType.LettuceSeed;
    [SerializeField] GameObject growingPlant;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
enum SeedType
{
    LettuceSeed,
    CabbageSeed,
    RadishSeed
}

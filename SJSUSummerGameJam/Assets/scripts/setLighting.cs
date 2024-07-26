using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setLighting : MonoBehaviour
{
    //cant get it read correct value
    public int r = 0; // Red value (0 to 1)
    public int g = 10; // Green value (0 to 1)
    public int b = 20; // Blue value (0 to 1)

    // Start is called before the first frame update
    void Start()
    {
    RenderSettings.ambientLight = new Color(r, g, b);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class MagicLamp : Lamp
{
    // Start is called before the first frame update
    public float timer =0f;
    private Material myMat;
    private float intensity;
    private Color myColor;
    private Vector3 randomV3;
    

    void Start()
    {
        print("magic lamp added!");
        timer = Random.Range(3, 8);
        myMat = GetComponent<Renderer>().sharedMaterial;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        randomV3 = new Vector3(Random.Range(0.1f, 0.8f),Random.Range(0.1f, 0.8f),Random.Range(0.1f, 0.8f));
        myColor = new Color(Mathf.Sin(Mathf.PingPong(randomV3.x ,0.3f)),
            Mathf.Sin(Mathf.PingPong(randomV3.y ,0.8f)),
            Mathf.Sin(Mathf.PingPong(randomV3.z,0.6f)));
    }
    
    public override void Timer()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            intensity = timer;
            
            LightUp(myColor);
        }
        else
        {
            Destroy(this);
        }
      
    }

    public override void LightUp(Color color)
    {
        myMat.EnableKeyword("_EMISSION");
        myMat.SetColor("_EmissionColor", color * intensity);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer =0f;
    private Material myMat;
    private float intensity;
    public Color myColor;
    

    void Start()
    {
        print("shield added!");
        timer = Random.Range(3, 8);
        myMat = GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
    
    public virtual void Timer()
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

    public virtual void LightUp(Color color)
    {
        myMat.EnableKeyword("_EMISSION");
        myMat.SetColor("_EmissionColor", color * intensity);
        
    }
}

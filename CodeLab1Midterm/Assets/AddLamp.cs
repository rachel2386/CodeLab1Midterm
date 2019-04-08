using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLamp : MonoBehaviour
{
    // Start is called before the first frame update
    private Material myMat;
    public Color myColor;
    //public static List<Material> lampMat = new List<Material>();
    public static List<GameObject> lamps = new List<GameObject>();
    public static List<GameObject> magicLamps = new List<GameObject>();
    
    void Start()
    {
        myMat = GetComponent<Renderer>().material;
        myMat.SetColor("_EmissionColor", new Color(Random.Range(0.1f,1),Random.Range(0.1f,1),Random.Range(0.1f,1)));
        myColor = myMat.GetColor("_EmissionColor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!other.GetComponent<Lamp>())
            {
                other.gameObject.AddComponent<Lamp>();
                lamps.Add(gameObject);
            }
            else
            {
                other.gameObject.AddComponent<MagicLamp>();
                gameObject.tag = "MagicLamp";
                lamps.Add(gameObject);
            }

            if(!other.gameObject.GetComponent<MagicLamp>())
                other.GetComponent<Lamp>().myColor = myColor;
            else
                myMat.SetColor("_EmissionColor", other.gameObject.GetComponent<MagicLamp>().myColor); 
           //lampMat.Add(myMat);
           
           //rint("number of lampMat:" + lampMat.Count);
           gameObject.SetActive(false);
        }
    }
}

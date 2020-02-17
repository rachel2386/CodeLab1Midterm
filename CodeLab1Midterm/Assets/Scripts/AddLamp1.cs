using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AddLamp1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Material myMat;

    public Color myColor;

    //public static List<Material> lampMat = new List<Material>();
    public static List<GameObject> lamps = new List<GameObject>();
    public static List<GameObject> magicLamps = new List<GameObject>();

    void Start()
    {
        //myMat = GetComponent<Renderer>().material;
        // myMat.SetColor("_EmissionColor", new Color(Random.Range(0.1f,1),Random.Range(0.1f,1),Random.Range(0.1f,1)));
        //myColor = myMat.GetColor("_EmissionColor");
        myColor = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            if (!other.GetComponent<Lamp>())
            {
                other.gameObject.AddComponent<Lamp>();
                other.GetComponent<Lamp>().myColor = myColor;
            }
            else
            {
                other.gameObject.AddComponent<MagicLamp>();
                gameObject.tag = "MagicLamp";
            }

            lamps.Add(gameObject);
            GameManager.itemFound.Add(gameObject);

            //myMat.SetColor("_EmissionColor", other.gameObject.GetComponent<MagicLamp>().myColor); 
            //lampMat.Add(myMat);

            //rint("number of lampMat:" + lampMat.Count);
            Tween shrinkSize = transform.DOScale(Vector3.zero, 0.8f);
            shrinkSize.SetEase(Ease.InOutQuart);

            if (shrinkSize.IsComplete())
                gameObject.SetActive(false);
        }
    }
}
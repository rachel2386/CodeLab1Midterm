using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> itemFound = new List<GameObject>();
    private int totalItems;
    private AudioSource myAS;
    private float time;
    public int gameState = 0;

    public Text numberText;//text that shows final score. 
    public Image BackgroundImg;  //ui background
    
    // Start is called before the first frame update
    void Start()
    {
        myAS = GetComponent<AudioSource>();
        time = myAS.clip.length;
        totalItems = FindObjectsOfType<AddLamp1>().Length;
        numberText.gameObject.SetActive(false);
        
        Tween fade = BackgroundImg.DOFade(0, 1f);
        fade.SetEase(Ease.InOutSine);
        
           
            

    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == 0)
        {
            if(time < 0 || itemFound.Count >= totalItems || Input.GetKeyDown(KeyCode.Escape))
                gameState = 1;
            else
            time -= Time.deltaTime;
            
            
        }

        else
        {
            EndGame();
            
            
            if(Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        

    }

    void EndGame()
    {
        Tween fade = BackgroundImg.DOFade(1, 0.6f);
       fade.SetEase(Ease.InOutSine);

       if (BackgroundImg.color.a < 0.9f) return;
       numberText.gameObject.SetActive(true);
       numberText.text = "You've gathered " + itemFound.Count + " pieces of memories. ";


    }
}

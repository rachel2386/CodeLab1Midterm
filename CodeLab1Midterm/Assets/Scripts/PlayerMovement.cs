using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody myRB;
    private Camera myCam;
    public float playerSpeed = 2f;
    private Rigidbody BananaRB;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myRB = GetComponent<Rigidbody>();
        BananaRB = GetComponentInChildren<Rigidbody>();
        myCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        myRB.velocity = (myCam.transform.right * Input.GetAxis("Horizontal") 
                        + myCam.transform.forward * Input.GetAxis("Vertical"))*playerSpeed;
        
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
//            if (AddLamp.magicLamps.Count > 0)
//            {
//                GameObject newMagicLamp = Instantiate(AddLamp.magicLamps[AddLamp.magicLamps.Count-1], 
//                    transform.position + myCam.transform.forward * 3, 
//                    Quaternion.identity);
//                newMagicLamp.SetActive(true);
//                newMagicLamp.AddComponent<MagicLamp>();
//                newMagicLamp.GetComponent<MagicLamp>().timer = Mathf.Infinity;
//                newMagicLamp.GetComponent<Rigidbody>().AddForce(Vector3.up * 3 + Vector3.right * Random.Range(-1,1),ForceMode.Impulse); 
//                AddLamp.magicLamps.Remove(AddLamp.magicLamps[AddLamp.magicLamps.Count-1]);
//            }
            if (AddLamp.lamps.Count > 0)
            {
                GameObject newLamp = Instantiate(Resources.Load<GameObject>("Prefab/Lamp"),
                    transform.position + myCam.transform.forward * 3, 
                    Quaternion.identity);//AddLamp.lamps[AddLamp.lamps.Count-1], 
                newLamp.transform.localScale = Vector3.zero;
                newLamp.SetActive(true);
                
                
                
               if (newLamp.CompareTag("MagicLamp"))
                {
                    newLamp.AddComponent<MagicLamp>();
                    newLamp.GetComponent<MagicLamp>().timer = 1000f; 
                }

                newLamp.GetComponent<Rigidbody>().AddForce(Vector3.up * 3 + Vector3.right * Random.Range(-1,1),ForceMode.Impulse); 
                AddLamp.lamps.Remove(AddLamp.lamps[AddLamp.lamps.Count-1]);
                Tween expandSize = newLamp.transform.DOScale(Vector3.one, 1f);
                expandSize.SetEase(Ease.InOutCubic);
                
                
            }

            
            

        }

        }

    
   
}

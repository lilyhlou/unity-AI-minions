using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureHunter : MonoBehaviour
{
    // Start is called before the first frame update
    //public Collectible[] collectibles;
    public TreasureHunterInventory inventory;
    //public CollectibleTreasure[] collectiblesInScene;
    public List<CollectibleTreasure> collectiblesInScene;
    //public class CollectibleIntDictionary : SerializableDictionary<CollectibleTreasure, int>{} 
    public CollectibleIntDictionary inventoryDict;
    public StringIntDictionary strDict;
    public TextMesh textScore;
    public Text scoreText;
    int totalPoints = 0;
    int totalItems = 0;
    
    float d;
    Vector3 prevForwardVector;
    Vector3 prevLocation;
    float prevYawRelativeToCenter;
    public Camera player;
    public LayerMask collectiblesMask;
    public TextMesh userScore;

    private Vector3 target = new Vector3(0, 1, 0);



    //public GameObject collectible1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Transform cameraTransform = Camera.main.transform;
            RaycastHit HitInfo;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out HitInfo, 2.5f, 1 << 10))
            {
                //print(HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>().Value);
                totalPoints += HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>().Value;
                totalItems++;
                //Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.yellow);
                print(HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>().Name);
                if (!strDict.ContainsKey(HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>().Name))
                {
                    strDict.Add(HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>().Name, 1);
                }
                else
                {
                    strDict[HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>().Name] = strDict[HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>().Name] + 1;
                }
                Destroy(HitInfo.collider.gameObject);

            }
            print("Pressed 1");
        }
        /*if (Input.GetKeyDown("2"))
        {
            Transform cameraTransform = Camera.main.transform;
            RaycastHit HitInfo;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out HitInfo, 100.0f, 1 << 10))
            {
                print("Pressed 2 Did If");
                Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.yellow);
                //print(HitInfo.collider.name);
                print(HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>()); 
                //print(GetPrefabType(HitInfo.collider.gameObject)); 
                if (!inventoryDict.ContainsKey(HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>()))
                { 
                    inventoryDict.Add(HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>(), 1);
                }
                else
                {
                    inventoryDict[HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>()] = inventoryDict[HitInfo.collider.gameObject.GetComponent<CollectibleTreasure>()] + 1;
                }
                //Destroy(HitInfo.collider.gameObject);
            }   
            else
            {
                print("Pressed 2 No If");
            }
            textWin.text = "2 Pressed";
        }*/
        
        //textScore.font.material.color = Color.yellow;
        //textScore.fontSize = 20;
        string message = "You have " + totalItems + " worth " + totalPoints + " points! -Evan & Lily";
        scoreText.text = message;
        textScore.text = message;
        //print("4");


    }

}

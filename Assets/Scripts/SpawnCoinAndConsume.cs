using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinAndConsume : MonoBehaviour
{
    public GameObject consumable;
    public Material consumedMaterial;
    private bool consumed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the collision occurred on the bottom side of the block
            ContactPoint contact = collision.GetContact(0);
            if (contact.normal.y > 0 && consumed == false)
            {
                consumed = true;
                GameObject tempCoin = 
                Instantiate(consumable, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(90f, 90f, 90f));
                print("created coin");
                gameObject.GetComponent<Renderer>().material = consumedMaterial;
                StartCoroutine(Delay(tempCoin));

                
            }
        }
    }

    IEnumerator Delay(GameObject coin)
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        print(Time.time);
        Destroy(coin);
    }
}

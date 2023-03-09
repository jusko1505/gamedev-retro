using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConsumable : MonoBehaviour
{
    public GameObject consumable;
    public Material consumedMaterial;
    private bool consumed = false;
    //private Transform spawnPoint = transform;

    
    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint.position = transform.position+ new Vector3(0, 1.5f, 0);
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
                Instantiate(consumable, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
                gameObject.GetComponent<Renderer>().material = consumedMaterial;
            }
        }
    }
}

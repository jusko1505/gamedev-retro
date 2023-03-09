using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    private bool isAlive;
    private bool isGrounded;
    private int HP;
    private Rigidbody rb; 
    
    public Material tallMaterial;
    public Material smallMaterial;
    public float jumpForce = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        HP = 1;
        rb = GetComponent<Rigidbody>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -2){
            print("fell into the void");
            SceneManager.LoadScene ("SampleScene");
        }
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && HP == 1)
        { 
            if (transform.position.y > collision.transform.position.y+0.5){
                // Destroy enemy
                Destroy(collision.gameObject);
                Vector3 jumpVector = new Vector3(0f, jumpForce, 0f);
                // Make the player jump by adding velocity
                rb.velocity = rb.velocity + jumpVector;
            }
            else{
                print("dead");
                SceneManager.LoadScene("SampleScene");
            }  
        }
        if(collision.gameObject.CompareTag("Enemy") && HP == 2){
            if (transform.position.y > collision.transform.position.y+0.5){
                // Destroy enemyfasdf
                Destroy(collision.gameObject);
                Vector3 jumpVector = new Vector3(0f, jumpForce, 0f);
                // Make the player jump by adding velocity
                rb.velocity = rb.velocity + jumpVector;
            }
            else{
                HP -=1 ;
                gameObject.GetComponent<Renderer>().material = smallMaterial;
            } 
            
        }
        if(collision.gameObject.CompareTag("Mushroom")){
            HP = 2;
            gameObject.GetComponent<Renderer>().material = tallMaterial;
        }
        
    }

}



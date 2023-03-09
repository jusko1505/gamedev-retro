using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private GameObject player;

    public float xMin = -55;
    public float xMax = 200;
    public float yMin = 3.5f;
    public float yMax = 6;

    public float y = -20;
    public float z = -10;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, z);
        //transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
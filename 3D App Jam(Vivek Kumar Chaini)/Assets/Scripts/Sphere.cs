using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool followPLayer;
    public GameObject player;
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if(followPLayer) {
            if(Vector3.Distance(player.transform.position, transform.position) > 2) {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

                Vector3 lookVector = player.transform.position - transform.position;
                lookVector.y = transform.position.y;
                Quaternion rot = Quaternion.LookRotation(lookVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            }
           
        }
    }

	private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            followPLayer = true;
            player = collision.gameObject;
        }
        
	}
}

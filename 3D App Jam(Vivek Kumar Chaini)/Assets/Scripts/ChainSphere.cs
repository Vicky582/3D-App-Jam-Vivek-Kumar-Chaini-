using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSphere : MonoBehaviour
{
    //public Transform magnet;
    //public float speed;
    //public float magnetDistance;

    //void Update()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(magnet.position, magnetDistance);

    //    for (int i = 0; i < hitColliders.Length; i++)
    //    {
    //        // do whathever you need here to determine if an object is a coin
    //        // Here I assume that all the coins will be tagged as coin
    //        if (hitColliders[i].tag == "Chain")
    //        {
    //            Transform coin = hitColliders[i].transform;
    //            coin.position = Vector3.MoveTowards(coin.position, magnet.position, speed * Time.deltaTime);
    //        }
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{

    //}
    public float speed;
    public float stoppingDist = 15f;
    public bool followPlayer;
    private GameObject player;
    void Start()
    {
        player = Player.self.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            if (Vector3.Distance(player.transform.position, transform.position) > 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

                Vector3 lookVector = player.transform.position - transform.position;
                lookVector.y = transform.position.y;
                Quaternion rot = Quaternion.LookRotation(lookVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            }

            //else if(Vector3.Distance(player.transform.position, transform.position) > stoppingDist)
            //{
            //    this.transform.position = transform.position;
            //}

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            followPlayer = true;
        }

    }
}
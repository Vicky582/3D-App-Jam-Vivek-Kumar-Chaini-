using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSphere : MonoBehaviour
{
    
    public float speed;
    public bool followPlayer;
    public bool collided;
    private GameObject player;
    void Start()
    {
        player = Player.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            if (Vector3.Distance(player.transform.position, transform.position) > 2.9)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

                Vector3 lookVector = player.transform.position - transform.position;
                lookVector.y = transform.position.y;
                Quaternion rot = Quaternion.LookRotation(lookVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !collided)
        {
            followPlayer = true;
            GameManager.Instance.totalSphereNumbers--;
            collided = true;

            if(GameManager.Instance.totalSphereNumbers == 0)
            {
                GameManager.Instance.GameWin();
            }
        }

    }
}
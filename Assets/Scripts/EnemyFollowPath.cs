using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy enemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Enemy"))
        {
            enemy.GoRandomPostion();

            print("op");
        }


    }


}

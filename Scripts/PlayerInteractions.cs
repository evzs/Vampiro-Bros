using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Item")
        {
            ItemAbstract item = collision.gameObject.GetComponent<ItemAbstract>();
            item.Collect();
            item.StartCollectProcess();
        }
    }
}
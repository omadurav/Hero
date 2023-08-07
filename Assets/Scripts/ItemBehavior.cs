using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            gameManager.items++;
        }
    }
}

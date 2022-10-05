using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPickupManager : MonoBehaviour
{
    [SerializeField] GameObject _mapButtonGO;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _mapButtonGO.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

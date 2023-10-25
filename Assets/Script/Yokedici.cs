using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yokedici : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlatformWall"))
        {
            Vector3 SuankiPos=other.transform.position;
            _GameManager.YenidenYerles(SuankiPos,other.gameObject);
        }
        if (other.CompareTag("PlatformBlock"))
        {
            Vector3 SuankiPos = other.transform.position;
            GameObject Block = other.gameObject.GetComponentInParent<Transform>().gameObject;
            
            _GameManager.YenidenYerlesBlock(SuankiPos, Block);
        }
    }
}

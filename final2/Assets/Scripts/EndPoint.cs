using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private bool _IsCompleted;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _IsCompleted = true;
        }
    }

    // Update is called once per frame
    public bool IsCompleted()
    {
        return _IsCompleted;
    }
}

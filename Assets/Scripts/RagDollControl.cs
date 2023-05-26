using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollControl : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Activator")) animator.enabled = false; 
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}

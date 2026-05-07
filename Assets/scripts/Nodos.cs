using System.Collections.Generic;
using UnityEngine;

public class Nodos : MonoBehaviour
{
   Vector3 PositionNode;
   [SerializeField] List<GameObject> NodosLado;
    void Start()
    {
       PositionNode = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

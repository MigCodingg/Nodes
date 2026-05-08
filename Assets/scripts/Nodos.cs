using System.Collections.Generic;
using UnityEngine;

public class Nodos : MonoBehaviour
{
   Vector3 PositionNode;
   [SerializeField] List<GameObject> NodosLado;
   bool beenUsed = false;
    void Awake()
    {
       PositionNode = transform.position; 
       NodosLado = new List<GameObject>();
    }

   public List<GameObject> GiveNodos()
   {
      beenUsed = true;
      return NodosLado;
   }

   public void SetNode(GameObject node)
   {
      NodosLado.Add(node);
   }

   public bool HasBeenUsed()
   {
      return beenUsed;
   }

}

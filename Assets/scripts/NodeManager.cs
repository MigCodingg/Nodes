using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Nodes;
    [SerializeField] GameObject Objeto;
    [SerializeField] GameObject Objetivo;
    [SerializeField] Material normal;
    [SerializeField] Material closest;
    
    Vector3 ObjPosition;

    // Update is called once per frame
    void Start()
    {
        List<GameObject> path = FindPaths (Objeto);
        foreach (GameObject node in path)
        {
            Debug.Log(node);
        }
    }
    
    List<GameObject> FindPaths(GameObject objeto)
    {
        GameObject primerNodo = FindCloseNode(objeto);
        List<GameObject> path = new List<GameObject>();
        path.Add(primerNodo);

        List<GameObject> NodosLado = primerNodo.GetComponent<Nodos>().GiveNodos();
        path.Add(NodosLado[0]);

        GameObject nodoActual = path[path.Count-1];

        while (nodoActual != Objetivo)
        {
            List<GameObject> NodosCerca = nodoActual.GetComponent<Nodos>().GiveNodos();
            path.Add(NodosCerca[0]);

            nodoActual = path[path.Count-1];
        }

        return path;
    }

    GameObject FindCloseNode(GameObject objeto)
    {
        ObjPosition = objeto.transform.position;

        GameObject closestNode = new GameObject();

        foreach (GameObject node in Nodes)
        {
            
            if (closestNode == null)
            {
                closestNode = node;
                continue;                
            }

            float  Distance = (node.transform.position - ObjPosition).sqrMagnitude;
            float  CurrentDistance = (closestNode.transform.position - ObjPosition).sqrMagnitude;

            if (Distance < CurrentDistance)
            {
                    closestNode = node;
            }
                        
        }

        return closestNode;
    }
}

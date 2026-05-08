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
        
    }
    
    public List<GameObject> FindPaths(GameObject objeto)
    {
        GameObject primerNodo = FindCloseNode(objeto);
        GameObject cercaObjetivo = FindCloseNode(Objetivo);
        List<GameObject> path = new List<GameObject>();
        List<List<GameObject>> paths = new List<List<GameObject>>();
        path.Add(primerNodo);
        paths.Add(path);
        
        int saveCheck = 0;

        while (0 < 1000)
        {
            for (int y = 0; y <= paths.Count -1; y++)
            {
                List<GameObject> currentPath = paths[y];
                GameObject ultimoNodo = currentPath[currentPath.Count-1];
                List<GameObject> NodosCerca = ultimoNodo.GetComponent<Nodos>().GiveNodos();

                foreach (GameObject nodo in NodosCerca)
                {
                    if (nodo == cercaObjetivo)
                    {
                        currentPath.Add(nodo);
                        return currentPath;
                    }
                }    

                if (NodosCerca.Count > 1)
                {

                    for (int i = 0; i <= NodosCerca.Count -2; i++)
                    {
                        List<GameObject> newPath = new List<GameObject>(currentPath);
                        newPath.Add(NodosCerca[i]);

                        paths.Add(newPath);
                    }
                }

                currentPath.Add(NodosCerca[NodosCerca.Count -1]);

            }

            saveCheck ++;
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

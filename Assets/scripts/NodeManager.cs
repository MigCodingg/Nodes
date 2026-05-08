using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Nodes;
    [SerializeField] GameObject Objetivo;
    [SerializeField] GameObject nodePrefab;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] float nodeDistance = 1.0f;
    
    Vector3 ObjPosition;

    // Update is called once per frame
    void Start()
    {
        for (float i = mesh.bounds.min.x + 1; i < mesh.bounds.min.x + mesh.bounds.size.x -0.5; i += nodeDistance)
        {
            for (float y = mesh.bounds.min.z + 1; y < mesh.bounds.min.z + mesh.bounds.size.z -0.5; y += nodeDistance)
            {
                Nodes.Add(Instantiate(nodePrefab, new Vector3(i, mesh.bounds.min.y, y), Quaternion.identity));
            }
        }

        foreach (GameObject node in Nodes)
        {
            foreach (GameObject node2 in Nodes)
            {
                if((node.transform.position - node2.transform.position).sqrMagnitude < nodeDistance * nodeDistance +1 && node.transform.position != node2.transform.position)
                {
                    node.GetComponent<Nodos>().SetNode(node2);
                }

            }
        }

    }

    
    
    public List<GameObject> FindPaths(GameObject objeto)
    {
        GameObject primerNodo = FindCloseNode(objeto);
        GameObject cercaObjetivo = FindCloseNode(Objetivo);
        List<GameObject> path = new List<GameObject>();
        List<List<GameObject>> paths = new List<List<GameObject>>();
        path.Add(primerNodo);
        paths.Add(path);
        

        if (Nodes.Count > 0)
        {
            while (true)
            {                
                int maxSize = paths.Count;

                    for (int y = 0; y <= maxSize -1; y++)
                    {
                        List<GameObject> currentPath = paths[y];
                        GameObject ultimoNodo = currentPath[currentPath.Count-1];
                        List<GameObject> NodosCerca = ultimoNodo.GetComponent<Nodos>().GiveNodos();

                        Debug.Log(NodosCerca.Count);
                
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
                                if (!NodosCerca[i].GetComponent<Nodos>().HasBeenUsed())
                                {
                                    List<GameObject> newPath = new List<GameObject>(currentPath)
                                    {
                                        NodosCerca[i]
                                    };

                                    paths.Add(newPath);                                
                                }
                            }
                        }

                        if (!NodosCerca[NodosCerca.Count -1].GetComponent<Nodos>().HasBeenUsed())
                        currentPath.Add(NodosCerca[NodosCerca.Count -1]);

                        else
                        {
                            paths.Remove(currentPath);
                        }
                        

                    }
            }
            

        }

        else
        {
            Debug.Log("no hay nodos :(");
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

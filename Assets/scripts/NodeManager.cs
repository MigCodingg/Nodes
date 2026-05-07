using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Nodes;
    [SerializeField] GameObject Objetillo;
    [SerializeField] Material normal;
    [SerializeField] Material closest;
    
    Vector3 ObjPosition;

    // Update is called once per frame
    void Update()
    {
        ObjPosition = Objetillo.transform.position;

        MeshRenderer closestNode = new MeshRenderer();

        foreach (GameObject node in Nodes)
        {
            node.GetComponentInChildren<MeshRenderer>().material = normal;
            
            if (closestNode == null)
            {
                closestNode = node.GetComponentInChildren<MeshRenderer>();
                node.GetComponentInChildren<MeshRenderer>().material = closest;
                continue;                
            }

            float  Distance = (node.transform.position - ObjPosition).sqrMagnitude;
            float  CurrentDistance = (closestNode.transform.position - ObjPosition).sqrMagnitude;

            if (Distance < CurrentDistance)
            {

                    closestNode.material = normal;
                    closestNode = node.GetComponentInChildren<MeshRenderer>();
                    node.GetComponentInChildren<MeshRenderer>().material = closest;

            }
            

        }
    }
}

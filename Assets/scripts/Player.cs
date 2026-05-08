using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] NodeManager nodeManager;
    List<GameObject> path;

    [SerializeField] float velocidad = 0.1f;
    int index;
    void Start()
    {
        path = nodeManager.FindPaths(gameObject);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index <= path.Count -1)
        {
            Vector3 direccion = path[index].transform.position - gameObject.transform.position;

            if (direccion.sqrMagnitude > 2)
            {
                gameObject.transform.position += direccion.normalized * velocidad * Time.deltaTime;
            }
            else
            {
                index ++;
            }
        }

        
    }




}

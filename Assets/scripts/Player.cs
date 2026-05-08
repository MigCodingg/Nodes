using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] NodeManager nodeManager;
    List<GameObject> path;
    InputSystem_Actions inputSystem;
    [SerializeField] float velocidad = 0.1f;

    bool startMove = false;
    int index;
    void Start()
    {
        inputSystem = new InputSystem_Actions();
        inputSystem.Enable();
        inputSystem.Player.Jump.performed += ctx => OnClick();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            if (index <= path.Count -1 )
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



    void OnClick()
    {
        startMove = true;
        path = nodeManager.FindPaths(gameObject);
    }


}

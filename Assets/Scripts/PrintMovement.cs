using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//[ExecuteInEditMode]
public class PrintMovement : MonoBehaviour
{
    private float x;
    private float y;
    private float circle;
    private float square;
    private float triangle;
    private float movebutton;
   

    private void Update()
    {
        x = Input.GetAxisRaw("J1Horizontal");
        y = Input.GetAxisRaw("J1Vertical");
        circle = Input.GetAxisRaw("J1Circle");
        square = Input.GetAxisRaw("J1Square");
        triangle = Input.GetAxisRaw("J1Triangle");
        movebutton = Input.GetAxisRaw("J1Move");
    }

}

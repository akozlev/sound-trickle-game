using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSendToReceiver : MonoBehaviour
{
    public LibPdInstance pdPatch;
    public float num;

    public void Test() 
    {
        pdPatch.SendFloat("variable", num);
    }
}
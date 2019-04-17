using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TestSendToReceiver : MonoBehaviour
{
    public LibPdInstance pdPatch;
    public AudioClip sound;

    public void StartBang() 
    {
        pdPatch.SendBang("start");
    }
    public void LoopBang()
    {
        pdPatch.SendBang("loop");
    }
    public void StopBang()
    {
        pdPatch.SendBang("stop");
    }
    public void PauseBang()
    {
        pdPatch.SendBang("pause");
    }
    public void LoadBang()
    {
        Debug.Log(sound.name);
        string path = "../../Sounds/" + sound.name + ".wav";
        pdPatch.SendSymbol("path", path);
    }

}
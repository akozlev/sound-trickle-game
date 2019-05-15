using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureDataClip : MonoBehaviour

    
{
    public AudioClip clip;
    public LibPdInstance pd;
    private void Start()
    {
        float[] dataLeft = new float[clip.samples * clip.channels];
       // float[] dataRight;

        clip.GetData(dataLeft, 0);
       // pd.WriteArray("uaudioclipLeft" + clip.name, 0, dataLeft, clip.samples);
        pd.WriteArray("channel", 0, dataLeft, clip.samples);
                    //pd.SendMessage("play");
    }
   
}

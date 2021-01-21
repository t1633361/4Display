using UnityEngine;
using System.Collections;

public class MultiDisplays : MonoBehaviour
{
// Use this for initialization
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] 是主显示器, 默认显示并始终在主显示器上显示.        
        // 检查其他显示器是否可用并激活.        
        int length = Display.displays.Length;
        for (int i = 0; i < length; ++i)
        {
            Display.displays[i].Activate();
        }
    }
}
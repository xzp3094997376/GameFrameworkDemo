using System.Collections;
using System.Collections.Generic;
using StarForce;
using UnityEngine;

public class TestNet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameEntry.Network.CreateNetworkChannel()
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
          Debug.Log("服务器启动  ");
          Demo8_SocketServer.Start();
        }
    }
}
    
using System.Collections;
using System.Collections.Generic;
using GameFramework.Network;
using StarForce;
using UnityEngine;
using UnityGameFramework.Runtime;

public class HelloPacketHandler : PacketHandlerBase
{
    public override int Id
    {

        get
        {

            return 10;

        }

    }

    public override void Handle(object sender, Packet packet)
    {

        SCHello packetImpl = (SCHello)packet;

        Log.Info("Demo8_HelloPacketHandler 收到消息： '{0}'.", packetImpl.Name);

    }

}

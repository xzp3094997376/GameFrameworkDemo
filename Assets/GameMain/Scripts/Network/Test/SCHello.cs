﻿using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf;
using StarForce;
using UnityEngine;

[Serializable, ProtoContract(Name = @"SCHello")]

public class SCHello : SCPacketBase
{
    public override int Id
    {
        get
        {
            return 10;
        }
    }

    [ProtoMember(1)]

    public string Name { get; set; }

    public override void Clear()
    {

    }

}

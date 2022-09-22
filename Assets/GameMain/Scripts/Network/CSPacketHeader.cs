//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using ProtoBuf;

namespace StarForce
{
    [Serializable,ProtoContract(Name = @"CSPacketHeader")]
    public sealed class CSPacketHeader : PacketHeaderBase
    {
        [ProtoMember(1)]
        public new int Id
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public new int PacketLength
        {
            get;
            set;
        }

        public override PacketType PacketType
        {
            get
            {
                return PacketType.ClientToServer;
            }
        }
    }
}

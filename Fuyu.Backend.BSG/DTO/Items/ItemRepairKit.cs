﻿using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemRepairKit
    {
        [DataMember]
        public float Resource;
    }
}
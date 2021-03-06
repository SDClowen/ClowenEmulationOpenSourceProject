﻿namespace CLGameServer.Client
{
    public partial class Packet
    {
        public static byte[] AttackPetStats(WorldMgr.pet_obj c,byte slot)
        {
            CLFramework.PacketWriter writer = new CLFramework.PacketWriter();
            writer.Create(OperationCode.SERVER_PET_INFORMATION);
            writer.DWord(c.UniqueID);
            writer.DWord(c.Model);
            writer.DWord(0x00000168);//stats
            writer.DWord(0x00000168);//stats
            writer.LWord(c.exp);//Experience
            writer.Byte(c.Level);//Level
            writer.Word(0);//Angle
            writer.DWord(0x00000001);//1 = Attack icon enabled, 2 = disabled
            if (c.Petname != "No name") writer.Text(c.Petname);//Petname
            else 
                writer.Word(0);//No name

            writer.Byte(0);//Static perhaps
            writer.DWord(c.OwnerID);//Owner
            writer.Byte(slot);
            return writer.GetBytes();
        }
        public static byte[] AttackPetHGP(WorldMgr.pet_obj c)
        {
            CLFramework.PacketWriter writer = new CLFramework.PacketWriter();
            writer.Create(OperationCode.SERVER_PET_HGP);
            writer.DWord(c.UniqueID);
            writer.Byte(3);
            writer.Byte(0);
            writer.Byte(0);
            return writer.GetBytes();
        }
    }
}

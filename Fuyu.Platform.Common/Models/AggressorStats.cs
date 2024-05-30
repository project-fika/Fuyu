using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct AggressorStats
    {
        [DataMember] public string AccountId;

        [DataMember] public string ProfileId;

        [DataMember] public string MainProfileNickname;

        [DataMember] public string Name;

        [DataMember] public EPlayerSide Side;

        [DataMember] public EBodyPart ColliderType;

        [DataMember] public string WeaponName;

        [DataMember] public EMemberCategory Category;
    }
}
// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace stellar_dotnetcore_sdk.xdr
{
// === xdr source ============================================================

//  enum ManageOfferEffect
//  {
//      MANAGE_OFFER_CREATED = 0,
//      MANAGE_OFFER_UPDATED = 1,
//      MANAGE_OFFER_DELETED = 2
//  };

//  ===========================================================================
    public class ManageOfferEffect
    {
        public enum ManageOfferEffectEnum
        {
            MANAGE_OFFER_CREATED = 0,
            MANAGE_OFFER_UPDATED = 1,
            MANAGE_OFFER_DELETED = 2
        }

        public ManageOfferEffectEnum InnerValue { get; set; } = default(ManageOfferEffectEnum);

        public static ManageOfferEffect Create(ManageOfferEffectEnum v)
        {
            return new ManageOfferEffect
            {
                InnerValue = v
            };
        }

        public static ManageOfferEffect Decode(XdrDataInputStream stream)
        {
            var value = stream.ReadInt();
            switch (value)
            {
                case 0: return Create(ManageOfferEffectEnum.MANAGE_OFFER_CREATED);
                case 1: return Create(ManageOfferEffectEnum.MANAGE_OFFER_UPDATED);
                case 2: return Create(ManageOfferEffectEnum.MANAGE_OFFER_DELETED);
                default:
                    throw new Exception("Unknown enum value: " + value);
            }
        }

        public static void Encode(XdrDataOutputStream stream, ManageOfferEffect value)
        {
            stream.WriteInt((int) value.InnerValue);
        }
    }
}
// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace stellar_dotnetcore_sdk.xdr
{
// === xdr source ============================================================

//  enum BucketEntryType
//  {
//      LIVEENTRY = 0,
//      DEADENTRY = 1
//  };

//  ===========================================================================
    public class BucketEntryType
    {
        public enum BucketEntryTypeEnum
        {
            LIVEENTRY = 0,
            DEADENTRY = 1
        }

        public BucketEntryTypeEnum InnerValue { get; set; } = default(BucketEntryTypeEnum);

        public static BucketEntryType Create(BucketEntryTypeEnum v)
        {
            return new BucketEntryType
            {
                InnerValue = v
            };
        }

        public static BucketEntryType Decode(XdrDataInputStream stream)
        {
            var value = stream.ReadInt();
            switch (value)
            {
                case 0: return Create(BucketEntryTypeEnum.LIVEENTRY);
                case 1: return Create(BucketEntryTypeEnum.DEADENTRY);
                default:
                    throw new Exception("Unknown enum value: " + value);
            }
        }

        public static void Encode(XdrDataOutputStream stream, BucketEntryType value)
        {
            stream.WriteInt((int) value.InnerValue);
        }
    }
}
// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace stellar_dotnet_sdk.xdr
{
// === xdr source ============================================================
//  struct PaymentOp
//  {
//      AccountID destination; // recipient of the payment
//      Asset asset;           // what they end up with
//      int64 amount;          // amount they end up with
//  };
//  ===========================================================================
    public class PaymentOp
    {
        public PaymentOp()
        {
        }

        public AccountID Destination { get; set; }
        public Asset Asset { get; set; }
        public Int64 Amount { get; set; }

        public static void Encode(XdrDataOutputStream stream, PaymentOp encodedPaymentOp)
        {
            AccountID.Encode(stream, encodedPaymentOp.Destination);
            Asset.Encode(stream, encodedPaymentOp.Asset);
            Int64.Encode(stream, encodedPaymentOp.Amount);
        }

        public static PaymentOp Decode(XdrDataInputStream stream)
        {
            PaymentOp decodedPaymentOp = new PaymentOp();
            decodedPaymentOp.Destination = AccountID.Decode(stream);
            decodedPaymentOp.Asset = Asset.Decode(stream);
            decodedPaymentOp.Amount = Int64.Decode(stream);
            return decodedPaymentOp;
        }
    }
}
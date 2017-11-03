// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

namespace stellar_dotnetcore_sdk.xdr
{
// === xdr source ============================================================

//  struct Error
//  {
//      ErrorCode code;
//      string msg<100>;
//  };

//  ===========================================================================
    public class Error
    {
        public ErrorCode Code { get; set; }
        public string Msg { get; set; }

        public static void Encode(XdrDataOutputStream stream, Error encodedError)
        {
            ErrorCode.Encode(stream, encodedError.Code);
            stream.WriteString(encodedError.Msg);
        }

        public static Error Decode(XdrDataInputStream stream)
        {
            var decodedError = new Error();
            decodedError.Code = ErrorCode.Decode(stream);
            decodedError.Msg = stream.ReadString();
            return decodedError;
        }
    }
}
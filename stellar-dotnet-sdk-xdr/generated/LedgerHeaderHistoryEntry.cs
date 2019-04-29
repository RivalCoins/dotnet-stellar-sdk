// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace stellar_dotnet_sdk.xdr
{
// === xdr source ============================================================
//  struct LedgerHeaderHistoryEntry
//  {
//      Hash hash;
//      LedgerHeader header;
//  
//      // reserved for future use
//      union switch (int v)
//      {
//      case 0:
//          void;
//      }
//      ext;
//  };
//  ===========================================================================
    public class LedgerHeaderHistoryEntry
    {
        public LedgerHeaderHistoryEntry()
        {
        }

        public Hash Hash { get; set; }
        public LedgerHeader Header { get; set; }
        public LedgerHeaderHistoryEntryExt Ext { get; set; }

        public static void Encode(XdrDataOutputStream stream, LedgerHeaderHistoryEntry encodedLedgerHeaderHistoryEntry)
        {
            Hash.Encode(stream, encodedLedgerHeaderHistoryEntry.Hash);
            LedgerHeader.Encode(stream, encodedLedgerHeaderHistoryEntry.Header);
            LedgerHeaderHistoryEntryExt.Encode(stream, encodedLedgerHeaderHistoryEntry.Ext);
        }

        public static LedgerHeaderHistoryEntry Decode(XdrDataInputStream stream)
        {
            LedgerHeaderHistoryEntry decodedLedgerHeaderHistoryEntry = new LedgerHeaderHistoryEntry();
            decodedLedgerHeaderHistoryEntry.Hash = Hash.Decode(stream);
            decodedLedgerHeaderHistoryEntry.Header = LedgerHeader.Decode(stream);
            decodedLedgerHeaderHistoryEntry.Ext = LedgerHeaderHistoryEntryExt.Decode(stream);
            return decodedLedgerHeaderHistoryEntry;
        }

        public class LedgerHeaderHistoryEntryExt
        {
            public LedgerHeaderHistoryEntryExt()
            {
            }

            public int Discriminant { get; set; } = new int();

            public static void Encode(XdrDataOutputStream stream,
                LedgerHeaderHistoryEntryExt encodedLedgerHeaderHistoryEntryExt)
            {
                stream.WriteInt((int) encodedLedgerHeaderHistoryEntryExt.Discriminant);
                switch (encodedLedgerHeaderHistoryEntryExt.Discriminant)
                {
                    case 0:
                        break;
                }
            }

            public static LedgerHeaderHistoryEntryExt Decode(XdrDataInputStream stream)
            {
                LedgerHeaderHistoryEntryExt decodedLedgerHeaderHistoryEntryExt = new LedgerHeaderHistoryEntryExt();
                int discriminant = stream.ReadInt();
                decodedLedgerHeaderHistoryEntryExt.Discriminant = discriminant;
                switch (decodedLedgerHeaderHistoryEntryExt.Discriminant)
                {
                    case 0:
                        break;
                }

                return decodedLedgerHeaderHistoryEntryExt;
            }
        }
    }
}
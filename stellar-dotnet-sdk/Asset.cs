﻿using System;
using stellar_dotnet_sdk.xdr;

namespace stellar_dotnet_sdk
{
    /// <summary>
    /// Asset class represents an asset, either the native asset (XLM) or a asset code / issuer account ID pair.
    /// An asset code describes an asset code and issuer pair. In the case of the native asset XLM, the issuer will be null.
    /// </summary>
    public abstract class Asset
    {
        /// <summary>
        /// Create an asset base on the parameters.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="code"></param>
        /// <param name="issuer"></param>
        /// <returns>Asset</returns>
        public static Asset Create(String type, String code, String issuer)
        {
            if (type == "native")
            {
                return new AssetTypeNative();
            }
            else
            {
                return Asset.CreateNonNativeAsset(code, issuer);
            }
        }

        ///<summary>
        /// Creates one of <seealso cref="AssetTypeCreditAlphaNum4"/> or <seealso cref="AssetTypeCreditAlphaNum12"/> object based on a code length
        /// </summary>
        /// <param name="code">Asset code</param>
        /// <param name="issuer">Asset issuer</param>
        public static Asset CreateNonNativeAsset(string code, string issuer)
        {
            if (code.Length >= 1 && code.Length <= 4)
                return new AssetTypeCreditAlphaNum4(code, issuer);
            if (code.Length >= 5 && code.Length <= 12)
                return new AssetTypeCreditAlphaNum12(code, issuer);
            throw new AssetCodeLengthInvalidException();
        }

        /// <summary>
        ///  Generates Asset object from a given XDR object
        ///  </summary>
        /// <param name="thisXdr"></param>
        public static Asset FromXdr(xdr.Asset thisXdr)
        {
            switch (thisXdr.Discriminant.InnerValue)
            {
                case AssetType.AssetTypeEnum.ASSET_TYPE_NATIVE:
                    return new AssetTypeNative();
                case AssetType.AssetTypeEnum.ASSET_TYPE_CREDIT_ALPHANUM4:
                    var assetCode4 = Util.PaddedByteArrayToString(thisXdr.AlphaNum4.AssetCode.InnerValue);
                    var issuer4 = KeyPair.FromXdrPublicKey(thisXdr.AlphaNum4.Issuer.InnerValue);
                    return new AssetTypeCreditAlphaNum4(assetCode4, issuer4.AccountId);
                case AssetType.AssetTypeEnum.ASSET_TYPE_CREDIT_ALPHANUM12:
                    var assetCode12 = Util.PaddedByteArrayToString(thisXdr.AlphaNum12.AssetCode.InnerValue);
                    var issuer12 = KeyPair.FromXdrPublicKey(thisXdr.AlphaNum12.Issuer.InnerValue);
                    return new AssetTypeCreditAlphaNum12(assetCode12, issuer12.AccountId);
                default:
                    throw new ArgumentException("Unknown asset type " + thisXdr.Discriminant.InnerValue);
            }
        }

        ///<summary>
        /// Returns asset type. Possible types:
        /// <ul>
        ///   <li>native See <see cref="AssetTypeNative"/> for more information.</li>
        ///   <li>credit_alphanum4 See <see cref="AssetTypeCreditAlphaNum4"/> for more information.</li>
        ///   <li>credit_alphanum12 See <see cref="AssetTypeCreditAlphaNum12"/> for more information.</li>
        /// </ul>
        ///</summary>
        public new abstract string GetType();

        ///<summary>
        /// Generates XDR object from a given Asset object
        ///</summary>
        public abstract xdr.Asset ToXdr();

        ///<summary>
        /// Creates one of AssetTypeCreditAlphaNum4 or AssetTypeCreditAlphaNum12 object based on a code length
        /// </summary>
        public static Asset CreateNonNativeAsset(string assetType, string accountId, string code)
        {
            if (assetType == "native")
                return new AssetTypeNative();

            return CreateNonNativeAsset(code, accountId);
        }

        /// <summary>
        /// Returns the asset canonical name.
        /// </summary>
        public abstract string CanonicalName();

        public static int Compare(Asset assetA, Asset assetB)
        {
            if (assetA == null) 
            {
                throw new ArgumentNullException(nameof(assetA), "assetA is invalid");
            }

            if (assetB == null)
            {
                throw new ArgumentNullException(nameof(assetB), "assetB is invalid");
            }

            if (assetA.Equals(assetB))
            {
                return 0;
            }

            // Compare asset types.
            switch (assetA.GetType())
            {
                case "native":
                    return -1;

                case "credit_alphanum4":
                    if (assetB.GetType() == "native")
                    {
                        return 1;
                    }
                    if (assetB.GetType() == "credit_alphanum12")
                    {
                        return -1;
                    }
                    break;

                case "credit_alphanum12":
                    if (assetB.GetType() != "credit_alphanum12")
                    {
                        return 1;
                    }
                    break;

                default:
                    throw new ArgumentNullException("Unexpected asset type");
            }

            AssetTypeCreditAlphaNum assetAlphaA = (AssetTypeCreditAlphaNum)assetA;
            AssetTypeCreditAlphaNum assetAlphaB = (AssetTypeCreditAlphaNum)assetB;

            // Compare asset codes.
            int result = string.Compare(assetAlphaA.Code, assetAlphaB.Code);
            if (result != 0)
            {
                return result;
            }

            // Compare asset issuers.
            return string.Compare(assetAlphaA.Issuer, assetAlphaB.Issuer);
        }
    }
}
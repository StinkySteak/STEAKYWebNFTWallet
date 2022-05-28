using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Util;
using System;

public static class EthereumRules
{
    public static bool IsEthereumAddress(string address)
    {
        if (!address.IsValidEthereumAddressHexFormat())
            return false;
        else
            return true;
    }
}

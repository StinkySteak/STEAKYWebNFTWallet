using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

[Function("balanceOf", "uint256")]
public class BalanceOfFunction_ERC1155 : FunctionMessage
{
    [Parameter("address", "account", 1)] public string? Account { get; set; }
    [Parameter("uint256", "id", 2)] public BigInteger TokenId { get; set; }
}

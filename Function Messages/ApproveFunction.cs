using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

[Function("approve", "bool")]
public class ApproveFunctionMessage : FunctionMessage
{
    [Parameter("address", "spender", 1)] public string? SpenderAddress { get; set; }
    [Parameter("uint256", "amount", 2)] public BigInteger TokenAmount { get; set; }
}

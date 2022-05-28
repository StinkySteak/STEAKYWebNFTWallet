using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

[Function("allowance", "uint256")]
public class AllowanceFunctionMessage : FunctionMessage
{
    [Parameter("address", "owner", 1)] public string? Owner { get; set; }
    [Parameter("address", "spender", 2)] public string? Spender { get; set; }
}

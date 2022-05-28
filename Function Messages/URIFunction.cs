using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

[Function("uri", "string")]
public class URIFunction : FunctionMessage
{
    [Parameter("uint256", "id", 1)] public BigInteger TokenId { get; set; }
}

using System.Security.Cryptography;

namespace Sha256;

public static class Functions
{
    public static UInt32 RotateRight(UInt32 bits, int n)
    {
        return (bits >> n) | (bits << (32 - n));
    }

    public static UInt32 Rotr7Rotr18Shr3(UInt32 x)
    {
        return RotateRight(x, 7) ^ RotateRight(x, 18) ^ (x >> 3);
    }

    public static UInt32 Rotr17Rotr19Shr10(UInt32 x)
    {
        return RotateRight(x, 17) ^ RotateRight(x, 19) ^ (x >> 10);
    }

    public static UInt32 Rotr2Rotr13Rotr22(UInt32 x)
    {
        return RotateRight(x, 2) ^ RotateRight(x, 13) ^ RotateRight(x, 22);
    }

    public static UInt32 Rotr6Rotr11Rotr25(UInt32 x)
    {
        return RotateRight(x, 6) ^ RotateRight(x, 11) ^ RotateRight(x, 25);
    }

    public static UInt32 Choice(UInt32 x, UInt32 y, UInt32 z)
    {
        return (x & y) ^ ((x ^ 0xffffffff) & z);
    }

    public static UInt32 Majority(UInt32 x, UInt32 y, UInt32 z)
    {
        return (x & y) ^ (x & z) ^ (y & z);
    }

    public static string ToBits(this string input)
    {
        var output = "";
        foreach (char c in input)
        {
            int unicode = c;
            output += Convert.ToString(unicode, 2).PadLeft(8, '0');
        }

        return output;
    }

    public static string PaddingTo512Bits(this string input)
    {
        var length = (UInt64)input.Length;
        var lengthAsBits = Convert.ToString((long)length, 2).PadLeft(64, '0');
        var output = input;

        if (output.Length < 512)
        {
            output += "1";
        }

        if (output.Length < 512)
        {
            while (output.Length < 448)
            {
                output += "0";
            }

            output += lengthAsBits;
        }

        return output;
    }
}

using FluentAssertions;
using NUnit.Framework;
using Sha256;

namespace Tests;

public class FunctionsTests
{
    [Test]
    [Description("Deve rotacionar os bits 3 casas à direita.")]
    public void Test_00()
    {
        // Arrange
        const UInt32 bits = 0b_00000000_00000000_00000000_00000111;

        // Act
        var rotatedBits = Functions.RotateRight(bits, 3);

        // Assert
        rotatedBits.Should().Be(0b_11100000_00000000_00000000_00000000);
    }

    [Test]
    public void Test_01()
    {
        // Arrange
        const UInt32 bits = 0b_00000000_00000000_00111111_11111111;

        // Act
        var rotatedBits = Functions.Rotr7Rotr18Shr3(bits);

        // Assert
        rotatedBits.Should().Be(0b_11110001_11111111_11000111_10000000);
    }

    [Test]
    public void Test_02()
    {
        // Arrange
        const UInt32 bits = 0b_00000000_00000000_00111111_11111111;

        // Act
        var rotatedBits = Functions.Rotr17Rotr19Shr10(bits);

        // Assert
        rotatedBits.Should().Be(0b_00011000_00000000_01100000_00001111);
    }

    [Test]
    public void Test_03()
    {
        // Arrange
        const UInt32 bits = 0b_00000000_00000000_00111111_11111111;

        // Act
        var rotatedBits = Functions.Rotr2Rotr13Rotr22(bits);

        // Assert
        rotatedBits.Should().Be(0b_00111111_00000111_11110011_11111110);
    }

    [Test]
    public void Test_04()
    {
        // Arrange
        const UInt32 bits = 0b_00000000_00000000_00111111_11111111;

        // Act
        var rotatedBits = Functions.Rotr6Rotr11Rotr25(bits);

        // Assert
        rotatedBits.Should().Be(0b_00000011_11111111_11111111_01111000);
    }

    [Test]
    public void Test_05()
    {
        // Arrange
        const UInt32 x = 0b_00000000_11111111_00000000_11111111;
        const UInt32 y = 0b_00000000_00000000_11111111_11111111;
        const UInt32 z = 0b_11111111_11111111_00000000_00000000;

        // Act
        var chosenBits = Functions.Choice(x, y, z);

        // Assert
        chosenBits.Should().Be(0b_11111111_00000000_00000000_11111111);
    }

    [Test]
    public void Test_06()
    {
        // Arrange
        const UInt32 x = 0b_00000000_11111111_00000000_11111111;
        const UInt32 y = 0b_00000000_00000000_11111111_11111111;
        const UInt32 z = 0b_11111111_11111111_00000000_00000000;

        // Act
        var chosenBits = Functions.Majority(x, y, z);

        // Assert
        chosenBits.Should().Be(0b_00000000_11111111_00000000_11111111);
    }

    [Test]
    [Description("Deve converter a string para sua representação binária, segundo a tabela ASCII.")]
    [TestCase("abc", "011000010110001001100011")]
    [TestCase("123", "001100010011001000110011")]
    [TestCase("SHA256", "010100110100100001000001001100100011010100110110")]
    public void Test_07(string input, string output)
    {
        // Arrange / Act
        var inputAsBits = input.ToBits();

        // Assert
        inputAsBits.Should().Be(output);
    }

    [Test]
    [Description("Deve realizar o padding da mensagem para o tamanho final de 512 bits.")]
    public void Test_08()
    {
        // Arrange
        var input = "abc".ToBits();

        // Act
        var inputAsBits = input.PaddingTo512Bits();

        // Assert
        inputAsBits.Length.Should().Be(512);
        inputAsBits.Should().Be("01100001011000100110001110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011000");
    }
}

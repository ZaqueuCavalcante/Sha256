using FluentAssertions;
using NUnit.Framework;
using Sha256;

namespace Tests;

public class FunctionsTests
{
    [Test]
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
        var rotatedBits = Functions.Rtr7Rtr18Shr3(bits);

        // Assert
        rotatedBits.Should().Be(0b_11110001_11111111_11000111_10000000);
    }

    [Test]
    public void Test_02()
    {
        // Arrange
        const UInt32 bits = 0b_00000000_00000000_00111111_11111111;

        // Act
        var rotatedBits = Functions.Rtr17Rtr19Shr10(bits);

        // Assert
        rotatedBits.Should().Be(0b_00011000_00000000_01100000_00001111);
    }

    [Test]
    public void Test_03()
    {
        // Arrange
        const UInt32 bits = 0b_00000000_00000000_00111111_11111111;

        // Act
        var rotatedBits = Functions.Rtr2Rtr13Rtr22(bits);

        // Assert
        rotatedBits.Should().Be(0b_00111111_00000111_11110011_11111110);
    }

    [Test]
    public void Test_04()
    {
        // Arrange
        const UInt32 bits = 0b_00000000_00000000_00111111_11111111;

        // Act
        var rotatedBits = Functions.Rtr6Rtr11Rtr25(bits);

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
    public void Test_07()
    {
        // Arrange
        const string input = "abc";

        // Act
        var inputAsBits = Functions.PaddingTo512Bits(input);

        // Assert
        inputAsBits.Should().Be("011000010110001001100011");
    }

    [Test]
    public void Test_08()
    {
        // Arrange
        const string input = "abc";

        // Act
        var inputAsBits = Functions.PaddingTo512Bits(input);

        // Assert
        inputAsBits.Should().Be("011000010110001001100011");
    }
}

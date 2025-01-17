namespace UnitTesting;
using KeypadChallenge;

public class TestOldPhoneKeypad
{
    [Fact] 
    public void Test_GetAlphabet()
    {
        var result = OldPhoneKeypad.GetAlphabet('2', 3);
        Assert.Equal("C", result);
    }

    [Fact]
    public void Test_KeypadOutput1()
    {
        var result = OldPhoneKeypad.KeypadOutput("33#");
        Assert.Equal("E", result);
    }
    
    [Fact]
    public void Test_KeypadOutput2()
    {
        var result = OldPhoneKeypad.KeypadOutput("227*#");
        Assert.Equal("B", result);
    }
    
    [Fact]
    public void Test_KeypadOutput3()
    {
        var result = OldPhoneKeypad.KeypadOutput("4433555 555666#");
        Assert.Equal("HELLO", result);
    }
    
    [Fact]
    public void Test_KeypadOutput4()
    {
        var result = OldPhoneKeypad.KeypadOutput("8 88777444666*664#");
        Assert.Equal("TURING", result);
    }
}
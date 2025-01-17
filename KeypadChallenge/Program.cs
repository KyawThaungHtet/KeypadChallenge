namespace KeypadChallenge;

// Represent a mapping between key and it's letters
public class KeyMapping
{
    public string Key { get; set; }
    public string Letters { get; set; }
}

public class OldPhoneKeyPad
{
    static List<KeyMapping> _keyInputs = new List<KeyMapping>
    {
        new KeyMapping { Key = "1", Letters = "&'(" },
        new KeyMapping { Key = "2", Letters = "ABC", },
        new KeyMapping { Key = "3", Letters = "DEF", },
        new KeyMapping { Key = "4", Letters = "GHI", },
        new KeyMapping { Key = "5", Letters = "JKL", },
        new KeyMapping { Key = "6", Letters = "MNO", },
        new KeyMapping { Key = "7", Letters = "PQRS", },
        new KeyMapping { Key = "8", Letters = "TUV", },
        new KeyMapping { Key = "9", Letters = "WXYZ", }
    };
    
    public static string GetAlphabet(char inputKey, int pressCount)
    {
        var keypadValue = _keyInputs.FirstOrDefault(key => key.Key == inputKey.ToString());
        if (keypadValue != null)
        {
            int index = (pressCount - 1) % keypadValue.Letters.Length;
            var letter = keypadValue.Letters[index];
            return letter.ToString();
        }

        return "";
    }

    public static string KeyPadOutput(string input)
    {
        if (String.IsNullOrEmpty(input))
        {
            return "";
        }
        
        var result = "";
        var temp = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '#') 
            {
                return result;
            }
            
            if (input[i] == ' ')
            {
                continue;
            }

            if (input[i] == '0')
            {
                result += " ";
            }

            if (input[i] == '*') 
            {
                result = result.Remove(result.Length - 1);
            }
            else
            {
                temp += input[i];
            }
            
            if (input[i] != input[i + 1])
            {
                if (temp.Length > 0)
                {
                    result += GetAlphabet(input[i], temp.Length);
                    temp = "";
                }
            }
        }
        
        return result;
    }
}


class Program
{
    static void Main(string[] args)
    {
        var test1 = OldPhoneKeyPad.KeyPadOutput("33#");
        Console.WriteLine(test1 == "E" ? $"Output: {test1} (Passed)" : $"Output: {test1} (Failed)");
        
        var test2 = OldPhoneKeyPad.KeyPadOutput("227*#");
        Console.WriteLine(test2 == "B" ? $"Output: {test2} (Passed)" : $"Output: {test2} (Failed)");
        
        var test3 = OldPhoneKeyPad.KeyPadOutput("4433555 555666#");
        Console.WriteLine(test3 == "HELLO" ? $"Output: {test3} (Passed)" : $"Output: {test3} (Failed)");
        
        var test4 = OldPhoneKeyPad.KeyPadOutput("8 88777444666*664#");
        Console.WriteLine(test4 == "TURING" ? $"Output: {test4} (Passed)" : $"Output: {test4} (Failed)");
    }
}
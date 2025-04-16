using System;
using System.Text;

/**
 * Generates a custom GUID-like string using a specific set of printable characters.
 */
public class GuidGenerator
{
    // The set of all printable characters to use for encoding
    //private const string AllPrintableChars = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
    // The custom set of printable characters to use for encoding
    private const string GuidPrintableChars = "-0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz";
    
    // Generates random GUID and encodes it using BASE64
    public static string GenerateCustomGuid()
    {
        // Generate a new GUID
        Guid guid = Guid.NewGuid();

        // Convert the GUID to a Base64 string
        string base64Guid = Convert.ToBase64String(guid.ToByteArray());

        // Remove padding characters ('=') and replace URL-unsafe characters
        string formattedGuid = base64Guid
            .Replace("+", string.Empty)
            .Replace("/", string.Empty)
            .TrimEnd('=');

        // Truncate to 12 characters
        return formattedGuid.Substring(0, 12);
    }
    // Encodes bytes by using custom printable characters
    public static string Encode(byte[] data)
    {
        StringBuilder encoded = new StringBuilder();

        foreach (byte b in data)
        {
            // Map each byte to a character in the printable range
            encoded.Append(GuidPrintableChars[b % GuidPrintableChars.Length]);
        }

        return encoded.ToString();
    }

    // Decodes a string back to bytes using the custom printable characters
    public static byte[] Decode(string encoded)
    {
        byte[] decoded = new byte[encoded.Length];

        for (int i = 0; i < encoded.Length; i++)
        {
            // Map each character back to a byte
            decoded[i] = (byte)GuidPrintableChars.IndexOf(encoded[i]);
        }

        return decoded;
    }

    // Generates random GUID and encodes it using custom printable characters
    public static string GenerateCustomGuid2()
    {
        // Generate a new GUID
        Guid guid = Guid.NewGuid();

        // Convert the GUID to a Base64 string
        string base64Guid = Encode(guid.ToByteArray());

        // Truncate to 12 characters
        return base64Guid.Substring(0, 12);
    }
}
public static class StreamReaderExtensions
{
    public static string? ReadNextNonEmptyLine(this StreamReader reader)
    {
        string? line;
        do
        {
            line = reader.ReadLine();
        } while (line != null && line == string.Empty);

        return line;
    }
}

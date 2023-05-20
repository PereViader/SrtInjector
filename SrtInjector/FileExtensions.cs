public class FileExtensions
{
    public static IEnumerable<FilePair> FindFilePairs(string directoryPath)
    {
        IEnumerable<string> srtFiles = Directory.EnumerateFiles(directoryPath, "*.srt");
        IEnumerable<string> txtFiles = Directory.EnumerateFiles(directoryPath, "*.txt");

        var groupedFiles = srtFiles.Concat(txtFiles)
            .GroupBy(file => Path.GetFileNameWithoutExtension(file))
            .Where(group => group.Count() > 1);

        foreach (var group in groupedFiles)
        {
            string srtFilePath = group.FirstOrDefault(file => file.EndsWith(".srt"))!;
            string txtFilePath = group.FirstOrDefault(file => file.EndsWith(".txt"))!;

            yield return new FilePair
            {
                SrtFilePath = srtFilePath,
                TxtFilePath = txtFilePath
            };
        }
    }
}

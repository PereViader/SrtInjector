string currentDirectory = Environment.CurrentDirectory;
var filePairs = FileExtensions.FindFilePairs(currentDirectory).ToArray();

if(filePairs.Length == 0)
{
    Console.WriteLine("There are no srt and txt file pairs with the same name");
    return;
}

foreach (var pair in filePairs)
{
    Console.WriteLine("SRT File: " + pair.SrtFilePath);
    Console.WriteLine("TXT File: " + pair.TxtFilePath);
    Console.WriteLine();

    CreateNewSrtFile(pair);
}

void CreateNewSrtFile(FilePair filePair)
{
    string srtFilePath = filePair.SrtFilePath;
    string txtFilePath = filePair.TxtFilePath;

    string srtFileName = Path.GetFileNameWithoutExtension(srtFilePath);
    string newSrtFileName = srtFileName + ".new.srt";

    string newSrtFilePath = Path.Combine(Path.GetDirectoryName(srtFilePath), newSrtFileName);

    try
    {
        using StreamReader srtReader = new StreamReader(srtFilePath);
        using StreamReader txtReader = new StreamReader(txtFilePath);
        using StreamWriter newSrtWriter = new StreamWriter(newSrtFilePath);
        
        int lineNumber = 1;

        while (true)
        {
            string line = srtReader.ReadLine();

            if (lineNumber % 4 == 3)
            {
                string? txtContent = txtReader.ReadNextNonEmptyLine();

                if (txtContent is null)
                {
                    newSrtWriter.Close();
                    if (File.Exists(newSrtFilePath))
                    {
                        File.Delete(newSrtFilePath);
                        Console.WriteLine("New SRT file removed: " + newSrtFilePath);
                    }
                    File.WriteAllText("SrtInjector.log", "Warning: Reached end of TXT file before finishing the SRT file.");
                    Console.WriteLine("Warning: Reached end of TXT file before finishing the SRT file.");
                    break;
                }

                
                newSrtWriter.WriteLine(txtContent);
            }
            else
            {
                newSrtWriter.WriteLine(line);

                if (srtReader.EndOfStream)
                {
                    string? txtContent = txtReader.ReadNextNonEmptyLine();

                    if (txtContent is not null)
                    {
                        newSrtWriter.Close();
                        if (File.Exists(newSrtFilePath))
                        {
                            File.Delete(newSrtFilePath);
                            Console.WriteLine("New SRT file removed: " + newSrtFilePath);
                        }
                        File.WriteAllText("SrtInjector.log", "Warning: Reached end of SRT file before finishing the TXT file.");
                        Console.WriteLine("Warning: Reached end of SRT file before finishing the TXT file.");
                    }

                    break;
                }
            }

            lineNumber++;
        }
        

        Console.WriteLine("New SRT file created successfully: " + newSrtFilePath);
    }
    catch (Exception ex)
    {
        if (File.Exists(newSrtFilePath))
        {
            File.Delete(newSrtFilePath);
            Console.WriteLine("New SRT file removed: " + newSrtFilePath);
        }
        Console.WriteLine("An error occurred while creating the new SRT file: " + ex.Message);
    }
}

//void CreateNewSrtFile(FilePair filePair)
//{
//    string srtFilePath = filePair.SrtFilePath;
//    string txtFilePath = filePair.TxtFilePath;

//    string srtFileName = Path.GetFileNameWithoutExtension(srtFilePath);
//    string newSrtFileName = srtFileName + ".new.srt";

//    string newSrtFilePath = Path.Combine(Path.GetDirectoryName(srtFilePath), newSrtFileName);

//    try
//    {
//        using (StreamReader srtReader = new StreamReader(srtFilePath))
//        using (StreamReader txtReader = new StreamReader(txtFilePath))
//        using (StreamWriter newSrtWriter = new StreamWriter(newSrtFilePath))
//        {
//            int lineNumber = 1;

//            while (!srtReader.EndOfStream)
//            {
//                string line = srtReader.ReadLine();

//                if (lineNumber % 4 == 3)
//                {
//                    string txtContent = txtReader.ReadLine();
//                    newSrtWriter.WriteLine(txtContent);
//                }
//                else
//                {
//                    newSrtWriter.WriteLine(line);
//                }

//                lineNumber++;
//            }
//        }

//        Console.WriteLine("New SRT file created successfully: " + newSrtFilePath);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("An error occurred while creating the new SRT file: " + ex.Message);
//    }
//}

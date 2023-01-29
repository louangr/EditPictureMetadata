using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        ProcessDirectory("./Data");
    }
    
    public static void ProcessDirectory(string targetDirectory)
    {
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
            ProcessFile(fileName);

    }

    public static void ProcessFile(string path)
    {
        var filename = path.Split("\\")[1];
        var splitedFilename = filename.Split("_");

        try
        {
            var creationYear = Int32.Parse(splitedFilename[splitedFilename.Length - 2].Substring(0, 4));
            var creationMonth = Int32.Parse(splitedFilename[splitedFilename.Length - 2].Substring(4, 2));
            var creationDay = Int32.Parse(splitedFilename[splitedFilename.Length - 2].Substring(6, 2));

            var creationHour = Int32.Parse(splitedFilename[splitedFilename.Length - 1].Substring(0, 2));
            var creationMinute = Int32.Parse(splitedFilename[splitedFilename.Length - 1].Substring(2, 2));
            var creationSecond = Int32.Parse(splitedFilename[splitedFilename.Length - 1].Substring(4, 2));

            File.SetLastWriteTime(path, new DateTime(creationYear, creationMonth, creationDay, creationHour, creationMinute, creationSecond));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
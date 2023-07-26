namespace task;

public class ExportToWord : IExport
{
    public void Export(string path)
    {
        Console.WriteLine($"Export to word successfully to '{path}'");
    }
}

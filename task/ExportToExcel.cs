namespace task;

public class ExportToExcel : IExport
{
    public void Export(string path)
    {
        Console.WriteLine($"Export to Excell successfully to '{path}'");
    }
}

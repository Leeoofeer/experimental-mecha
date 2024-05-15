public class SelectableOption
{
    public string[] Data { get; set; } 
    public int Karma { get; set; } 

    public SelectableOption(string[] data, int karma)
    {
        Data = data;
        Karma = karma;
    }
}

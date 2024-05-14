public class SelectableOption
{
    public string[] Data { get; set; } // Datos asociados a la opci�n
    public int Karma { get; set; } // Puntuaci�n de karma asociada a la opci�n

    // Constructor para inicializar la instancia
    public SelectableOption(string[] data, int karma)
    {
        Data = data;
        Karma = karma;
    }
}

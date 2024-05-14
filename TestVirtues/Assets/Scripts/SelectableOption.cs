public class SelectableOption
{
    public string[] Data { get; set; } // Datos asociados a la opción
    public int Karma { get; set; } // Puntuación de karma asociada a la opción

    // Constructor para inicializar la instancia
    public SelectableOption(string[] data, int karma)
    {
        Data = data;
        Karma = karma;
    }
}

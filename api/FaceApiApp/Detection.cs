namespace FaceApiApp;

public class Detection
{
    public int Id { get; set; }
    public string ImageBase64 { get; set; }  // Imagem em base64
    public string Gender { get; set; }       // Gênero
    public int Age { get; set; }             // Idade estimada
}

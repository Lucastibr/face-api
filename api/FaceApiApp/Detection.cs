using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FaceApiApp;
public class Detection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]  // Isso transforma o ObjectId em uma string quando serializado/deserializado
    public string? Id { get; set; }  // Altere para string para suportar a serialização JSON

    public string ImageBase64 { get; set; }  // Imagem capturada em base64
    public string Gender { get; set; }       // Gênero detectado
    public int Age { get; set; }             // Idade estimada
    public DateTime DetectionTime { get; set; }

    // Nova propriedade para armazenar a expressão principal
    public string MainExpression { get; set; }

    // Propriedade para armazenar todas as probabilidades das expressões
    public Dictionary<string, double> Expressions { get; set; } = new Dictionary<string, double>();   // Data da detecção
}

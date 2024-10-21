using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace FaceApiApp;
public class DetectionService
{
    private readonly IMongoCollection<Detection> _detections;

    public DetectionService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _detections = database.GetCollection<Detection>(config["MongoDB:DetectionsCollectionName"]);
    }

    public async Task<List<Detection>> GetDetectionsAsync()
    {
        return await _detections
            .Find(detection => true)
            .SortByDescending(d => d.DetectionTime) 
            .Limit(5)   
            .ToListAsync();
    }

    public async Task<List<Detection>> GetDetectionsChart()
    {
        return await _detections
            .Find(detection => true)
            .ToListAsync();
    }


    public async Task CreateDetectionAsync(Detection detection)
    {
        await _detections.InsertOneAsync(detection);
    }
}

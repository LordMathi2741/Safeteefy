using BasePlatform.API.Operation.Domain.Model.Aggregates;

namespace BasePlatform.API.Operation.Domain.Model.Entities;

public partial class Urgency
{
    public int Id { get; }
    
    public int GuardianId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime ReportedAt { get; set; }
    
    public Guardian Guardian { get; set; }
}

public partial class Urgency
{
    public Urgency()
    {
        Title = string.Empty;
        Summary = string.Empty;
        Latitude = 0;
        Longitude = 0;
    }
    
    public Urgency(string title, string summary, double latitude, double longitude)
    {
        Title = title;
        Summary = summary;
        Latitude =latitude;
        Longitude = longitude;
        ReportedAt = DateTime.Now;
    }
    
   
}
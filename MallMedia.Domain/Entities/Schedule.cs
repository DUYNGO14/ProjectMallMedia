namespace MallMedia.Domain.Entities;

public class Schedule
{
    public int Id { get; set; }
    public int ContentId { get; set; }
    public Content Content { get; set; } 
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool Status { get; set; } 
    public ICollection<Device_Schedule>? DeviceSchedule { get; set; }
}

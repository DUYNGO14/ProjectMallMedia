using MallMedia.Domain.Constants;

namespace MallMedia.Domain.Entities;

public class Device
{
    public int Id { get; set; }
    public string DeviceName { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public int DeviceTypeId { get; set; }
    public DeviceType DeviceType { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public ICollection<Device_Schedule>? DeviceSchedule { get; set; }
}

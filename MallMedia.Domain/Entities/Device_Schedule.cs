namespace MallMedia.Domain.Entities;

public class Device_Schedule
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public Device Device { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    public  ICollection<Calender_Detail>? Calender_Device_Schedule { get; set; }
}

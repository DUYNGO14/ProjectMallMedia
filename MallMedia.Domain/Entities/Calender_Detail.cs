namespace MallMedia.Domain.Entities;

public class Calender_Detail
{
    public int Id { get; set; }
    public int DeviceScheduleId  { get; set; }
    public Device_Schedule Device_Schedule { get; set; }
    public DateTime Date { get; set; }
    public int Slot { get; set; }
    public bool Status { get; set; }
}

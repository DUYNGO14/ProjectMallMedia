namespace MallMedia.Domain.Constants;

public class DeviceConfiguration
{
    public string DeviceType { get; set; }
    public string Size { get; set; }
    public string Resolution { get; set; }
}


public class DeviceType
{
    public static string LCD = "Vertical LCD";
    public static string DP = "Digital Poster";
    public static string LED = "LED";
}
public class DeviceSize
{
    public static string LCD = "21 inches";
    public static string DP = "32 inches";
    public static string LED = "300 inches";
}
public class DeviceResolution
{
    public static string LCD = "1080x1920";
    public static string DP = "1920x1080";
    public static string LED = "1920x1080";
}

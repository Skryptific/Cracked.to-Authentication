using System.Management;

namespace Cracked.to_Authentication.Utils
{
    public class HardwareId
    {
        public string getHardwareId()
        {
            using (var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor"))
            {
                var hardwareId = string.Empty;
                foreach (var mo in mbs.Get())
                {
                    hardwareId = mo["ProcessorId"].ToString();
                    break;
                }

                return hardwareId;
            }
        }
    }
}
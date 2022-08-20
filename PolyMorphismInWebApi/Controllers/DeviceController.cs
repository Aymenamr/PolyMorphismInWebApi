using PolymorphismInWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using PolymorphismInWebApi.Models.Abstract;

namespace PolymorphismInWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class DeviceController : ControllerBase
    {       

        private readonly ILogger<DeviceController> _logger;
      
        public DeviceController(ILogger<DeviceController> logger)
        {
            _logger = logger;
           
        }

        private static List<Device> _devices = new List<Device>();

        [HttpGet()]
        public List<Device> GetDevices()
        {            
            return _devices; 
        }

        [HttpPost]
        public void Post(Device device)
        {

            if (device is Phone)
            {
              _devices.Add((Phone)device);
            }

            if (device is Laptop)
            {
               _devices.Add((Laptop)device);
            }          
        }
    }
}
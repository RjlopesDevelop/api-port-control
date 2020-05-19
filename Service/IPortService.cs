
using System.Collections.Generic;
using ArduinoControl.Models;

namespace ArduinoControl.Services
{
    public interface IPortService
    {
        IEnumerable<Port> GetAll(); 
        string SendPort(string portName);
       
       
    }
}
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using ArduinoControl.Models;

namespace ArduinoControl.Services
{
    public class PortService : IPortService
    {
        private List<Port> modelPorts;
        private SerialPort serialPort;
     


        public IEnumerable<Port> GetAll()
        {
            modelPorts = new List<Port>();

            foreach (string namePort in SerialPort.GetPortNames())
            {
                modelPorts.Add(new Port { Name = namePort });
            }
            return modelPorts.ToList();

        }
        public string SendPort(string portName)
        {
            try
            {
                serialPort = new SerialPort();

                serialPort.PortName = portName;

                serialPort.Open();

                serialPort.Write("A");

                serialPort.Close();

                return "SUCESSO!";
            }
            catch (System.Exception e)
            {
                return e.Message.ToString();

            }
        }
        // public IEnumerable<WeatherForecast> GetForecast()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

    }

}
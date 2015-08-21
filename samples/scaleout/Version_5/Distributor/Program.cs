﻿using System;
using NServiceBus;

class Program
{

    static void Main()
    {
        #region server
        BusConfiguration busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Sample.Scaleout.Server");
        busConfiguration.RunMSMQDistributor(false);
        #endregion
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.UsePersistence<InMemoryPersistence>();
        busConfiguration.EnableInstallers();
        using (IBus bus = Bus.Create(busConfiguration).Start())
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
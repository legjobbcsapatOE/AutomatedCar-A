namespace AutomatedCar.SystemComponents
{
    using System.Collections.Generic;
    using System.Windows.Threading;
    using System;
    using AutomatedCar.SystemComponents.Packets;

    public class VirtualFunctionBus : IVirtualFunctionBus
    {
        private List<SystemComponent> components = new List<SystemComponent>();

        public IReadOnlyDummyPacket DummyPacket { get; set; }
        public IReadOnlyPowertrainComponentPacket PowertrainPacket { get; set; }

        private DispatcherTimer timer = new DispatcherTimer();

        public VirtualFunctionBus()
        {
            timer.Tick += Tick;
        }

        public void RegisterComponent(SystemComponent component)
        {
            this.components.Add(component);
        }

        private void Tick(object sender, EventArgs e)
        {
            foreach (SystemComponent component in this.components)
            {
                component.Process();
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

    }
}
using AutomatedCar.Models;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace AutomatedCar.Visualization
{
    public class WorldRenderer : FrameworkElement
    {
        public readonly double tickRate = 20;
        private readonly DispatcherTimer renderTimer = new DispatcherTimer();
        private readonly RenderCamera renderCamera = new RenderCamera();

        public World World => World.Instance;

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (World == null)
                return;

            foreach (var worldObject in World.WorldObjects)
            {
                // worldObject.Render(drawingContext);
            }

            var car = World.ControlledCar;
            var carImage = WorldObjectTransformer.GetCachedImage(car.Filename);
            drawingContext.DrawImage(carImage, new Rect(car.X, car.Y, car.Width, car.Height));
        }

        public WorldRenderer()
        {
            Loaded += WorldRenderer_Loaded;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            InvalidateVisual();
        }

        private void WorldRenderer_Loaded(object sender, RoutedEventArgs e)
        {
            renderTimer.Interval = TimeSpan.FromMilliseconds(tickRate);
            renderTimer.Tick += Timer_Tick;
            renderTimer.Start();

            renderCamera.Width = ActualWidth;
            renderCamera.Height = ActualHeight;
        }
    }
}
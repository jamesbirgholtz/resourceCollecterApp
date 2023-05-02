using resourceCollectorApp.GameResources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace resourceCollectorApp
{
    public partial class MainPage : ContentPage
    {
        public static MainPage Instance { get; private set; }

        public static event EventHandler ResourcesUpdated;
        public static Resource1 resource1;
        public static Resource2 resource2;
        public static Resource3 resource3;
        public static Resource4 resource4;

        public static Dictionary<string, string[]> worldResourceNames = new Dictionary<string, string[]>
        {
            { "World1", new string[] { "Water", "Coal", "Iron", "Gold" } },
            { "World2", new string[] { "ResourceA", "ResourceB", "ResourceC", "ResourceD" } },
            { "World3", new string[] { "ResourceX", "ResourceY", "ResourceZ", "ResourceW" } }
        };

        public static Dictionary<string, string[]> worldResourceImages = new Dictionary<string, string[]>
        {
            { "World1", new string[] { "R1_W1.png", "R2_W1.png", "R3_W1.png", "R4_W1.png" } },
            { "World2", new string[] { "R1_W2.png", "R2_W2.png", "R3_W2.png", "R4_W2.png" } },
            { "World3", new string[] { "R1_W3.png", "R2_W3.png", "R3_W3.png", "R4_W3.png" } }
        };

        public static string currentWorld = "World1";

        public MainPage()
        {
            InitializeComponent();
            resource1 = new Resource1(100000000, 0, 0, 100, 150, 300, 600);
            resource2 = new Resource2(100000000, 0, 0, 200, 300, 600, 900);
            resource3 = new Resource3(100000000, 0, 0, 400, 600, 1200, 1800);
            resource4 = new Resource4(100000000, 0, 0, 800, 1200, 2400, 3600);
            UpdateResourceLabels();
            // Update the resource labels every second
            Device.StartTimer(TimeSpan.FromSeconds(.1), () =>
            {
                UpdateResourceLabels();
                return true; // return true to repeat the action
            });

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                resource1.Count += resource1.PerSecond;
                resource2.Count += resource2.PerSecond;
                resource3.Count += resource3.PerSecond;
                resource4.Count += resource4.PerSecond;
                return true; // return true to repeat the action
            });

        }
        public void UpdateResourceLabels()
        {
            string[] currentWorldResourceNames = worldResourceNames[currentWorld];
            string[] currentWorldResourceImages = worldResourceImages[currentWorld];

            Resource1Image.Source = currentWorldResourceImages[0];
            Resource2Image.Source = currentWorldResourceImages[1];
            Resource3Image.Source = currentWorldResourceImages[2];
            Resource4Image.Source = currentWorldResourceImages[3];
            Resource1CountLabel.Text = currentWorldResourceNames[0] + ":\n" + resource1.PerSecond.ToString("F0") + "/s\n" + resource1.Count.ToString("F0");
            Resource2CountLabel.Text = currentWorldResourceNames[1] + ":\n" + resource2.PerSecond.ToString("F0") + "/s\n" + resource2.Count.ToString("F0");
            Resource3CountLabel.Text = currentWorldResourceNames[2] + ":\n" + resource3.PerSecond.ToString("F0") + "/s\n" + resource3.Count.ToString("F0");
            Resource4CountLabel.Text = currentWorldResourceNames[3] + ":\n" + resource4.PerSecond.ToString("F0") + "/s\n" + resource4.Count.ToString("F0");


        }
        public static void OnResourcesUpdated()
        {
            ResourcesUpdated?.Invoke(null, EventArgs.Empty);

        }

        public static void NewWorld()
        {
            resource1 = new Resource1(100000000, 0, 0, 100, 150, 300, 600);
            resource2 = new Resource2(100000000, 0, 0, 200, 300, 600, 900);
            resource3 = new Resource3(100000000, 0, 0, 400, 600, 1200, 1800);
            resource4 = new Resource4(100000000, 0, 0, 800, 1200, 2400, 3600);
        }
        public async Task ImageBounce(Image image)
        {
            _ = await image.ScaleTo(1.25, 50);
            _ = await image.ScaleTo(1, 50);
        }
        private async Task AnimateFallingImage(Image originalImage, uint duration = 2500)
        {
            // Create a new instance of the Image
            Image image = new Image
            {
                Source = originalImage.Source,
                WidthRequest = originalImage.WidthRequest,
                HeightRequest = originalImage.HeightRequest
            };

            // Add the new image to the AbsoluteLayout
            FallingImagesLayout.Children.Add(image);

            // Generate a random starting X position
            Random random = new Random();
            double randomX = random.NextDouble() * (Width - image.WidthRequest);

            // Set the image's initial position and size within the AbsoluteLayout
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(randomX, -image.HeightRequest, image.WidthRequest, image.HeightRequest));

            // Animate the image to fall to the bottom of the screen
            _ = await image.TranslateTo(image.TranslationX, Height, duration);

            // Remove the image from the AbsoluteLayout
            _ = FallingImagesLayout.Children.Remove(image);
        }

        public void MainButton(object sender, EventArgs e)
        {
            resource1.Count += resource1.PerClick;
            resource2.Count += resource2.PerClick;
            resource3.Count += resource3.PerClick;
            resource4.Count += resource4.PerClick;
            UpdateResourceLabels();

            Task.WhenAll(
            AnimateFallingImage(Resource1Image),
            AnimateFallingImage(Resource2Image),
            AnimateFallingImage(Resource3Image),
            AnimateFallingImage(Resource4Image),
            ImageBounce(Resource1Image),
            ImageBounce(Resource2Image),
            ImageBounce(Resource3Image),
            ImageBounce(Resource4Image),
            ImageBounce(MainButtonImage)
            );

        }
    }
}

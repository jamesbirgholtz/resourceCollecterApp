using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace resourceCollectorApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuildRocketPage : ContentPage
    {
        public BuildRocketPage()
        {
            InitializeComponent();
            MainPage.ResourcesUpdated += MainPage_ResourcesUpdated;

            Device.StartTimer(TimeSpan.FromSeconds(.5), () =>
            {
                UpdateResourceLabels();
                RocketProgressTracker();
                return true; // return true to repeat the action
            });
        }

        private void UpdateResourceLabels()
        {
            string currentWorld = MainPage.currentWorld; // Replace this with the actual current world name
            string[] currentWorldResourceNames = MainPage.worldResourceNames[currentWorld];
            string[] currentWorldResourceImages = MainPage.worldResourceImages[currentWorld];

            Resource1Image.Source = currentWorldResourceImages[0];
            Resource2Image.Source = currentWorldResourceImages[1];
            Resource3Image.Source = currentWorldResourceImages[2];
            Resource4Image.Source = currentWorldResourceImages[3];

            Resource1CountLabel.Text = currentWorldResourceNames[0] + ":\n" + MainPage.resource1.PerSecond.ToString("F0") + "/s\n" + MainPage.resource1.Count.ToString("F0");
            Resource2CountLabel.Text = currentWorldResourceNames[1] + ":\n" + MainPage.resource2.PerSecond.ToString("F0") + "/s\n" + MainPage.resource2.Count.ToString("F0");
            Resource3CountLabel.Text = currentWorldResourceNames[2] + ":\n" + MainPage.resource3.PerSecond.ToString("F0") + "/s\n" + MainPage.resource3.Count.ToString("F0");
            Resource4CountLabel.Text = currentWorldResourceNames[3] + ":\n" + MainPage.resource4.PerSecond.ToString("F0") + "/s\n" + MainPage.resource4.Count.ToString("F0");

            R1ToRocketLabel.Text = MainPage.resource1.resource1ToRocket.ToString("F0") + " " + currentWorldResourceNames[0] + " sent \n" + (MainPage.resource1.resource1Needed - MainPage.resource1.resource1ToRocket).ToString("F0") + " to go";
            R2ToRocketLabel.Text = MainPage.resource2.resource2ToRocket.ToString("F0") + " " + currentWorldResourceNames[1] + " sent \n" + (MainPage.resource2.resource2Needed - MainPage.resource2.resource2ToRocket).ToString("F0") + " to go";
            R3ToRocketLabel.Text = MainPage.resource3.resource3ToRocket.ToString("F0") + " " + currentWorldResourceNames[2] + " sent \n" + (MainPage.resource3.resource3Needed - MainPage.resource3.resource3ToRocket).ToString("F0") + " to go";
            R4ToRocketLabel.Text = MainPage.resource4.resource4ToRocket.ToString("F0") + " " + currentWorldResourceNames[3] + " sent \n" + (MainPage.resource4.resource4Needed - MainPage.resource4.resource4ToRocket).ToString("F0") + " to go";

            R1ToRocketButton.Text = "send all " + currentWorldResourceNames[0] + " to rocket ";
            R2ToRocketButton.Text = "send all " + currentWorldResourceNames[1] + " to rocket ";
            R3ToRocketButton.Text = "send all " + currentWorldResourceNames[2] + " to rocket ";
            R4ToRocketButton.Text = "send all " + currentWorldResourceNames[3] + " to rocket ";
        }

        private void MainPage_ResourcesUpdated(object sender, EventArgs e)
        {
            UpdateResourceLabels();
        }
        public async Task ImageBounce(Image image)
        {
            _ = await image.ScaleTo(1.25, 50);
            _ = await image.ScaleTo(1, 50);
        }
        public void R1ToRocket(object sender, EventArgs e)
        {
            MainPage.resource1.ContributeToRocket();
            UpdateResourceLabels();
            RocketProgressTracker();
            Task.WhenAll(ImageBounce(Resource1Image));
        }
        public void R2ToRocket(object sender, EventArgs e)
        {
            MainPage.resource2.ContributeToRocket();
            UpdateResourceLabels();
            RocketProgressTracker();
            Task.WhenAll(ImageBounce(Resource2Image));
        }
        public void R3ToRocket(object sender, EventArgs e)
        {
            MainPage.resource3.ContributeToRocket();
            UpdateResourceLabels();
            RocketProgressTracker();
            Task.WhenAll(ImageBounce(Resource3Image));
        }
        public void R4ToRocket(object sender, EventArgs e)
        {
            MainPage.resource4.ContributeToRocket();
            UpdateResourceLabels();
            RocketProgressTracker();
            Task.WhenAll(ImageBounce(Resource4Image));
        }
        public void LaunchButtonClicked(object sender, EventArgs e)
        {
            ChangeWorld();
            MainPage.NewWorld();
            UpdateResourceLabels();

            R1ToRocketButton.IsEnabled = true;
            R2ToRocketButton.IsEnabled = true;
            R3ToRocketButton.IsEnabled = true;
            R4ToRocketButton.IsEnabled = true;
            R1ToRocketButton.IsVisible = true;
            R2ToRocketButton.IsVisible = true;
            R3ToRocketButton.IsVisible = true;
            R4ToRocketButton.IsVisible = true;

            R1ToRocketLabel.IsVisible = true;
            R2ToRocketLabel.IsVisible = true;
            R3ToRocketLabel.IsVisible = true;
            R4ToRocketLabel.IsVisible = true;


            LaunchButton.IsVisible = false;
            LaunchButton.IsEnabled = false;

        }

        private void RocketProgressTracker()
        {
            //total to the resources needed
            double rocketResourcesNeeded = MainPage.resource1.resource1Needed + MainPage.resource2.resource2Needed + MainPage.resource3.resource3Needed + MainPage.resource4.resource4Needed;
            //total of the resources collected
            double rocketResourcesCollected = MainPage.resource1.resource1ToRocket + MainPage.resource2.resource2ToRocket + MainPage.resource3.resource3ToRocket + MainPage.resource4.resource4ToRocket;
            //creates a percentage of the resources needed so the progress bar van take the value
            rocketProgressBar.Progress = rocketResourcesCollected / rocketResourcesNeeded;

            if (MainPage.resource1.resource1Needed == MainPage.resource1.resource1ToRocket)
            {
                R1ToRocketButton.IsEnabled = false;
            }
            if (MainPage.resource2.resource2Needed == MainPage.resource2.resource2ToRocket)
            {
                R2ToRocketButton.IsEnabled = false;
            }
            if (MainPage.resource3.resource3Needed == MainPage.resource3.resource3ToRocket)
            {
                R3ToRocketButton.IsEnabled = false;
            }
            if (MainPage.resource4.resource4Needed == MainPage.resource4.resource4ToRocket)
            {
                R4ToRocketButton.IsEnabled = false;
            }
            //once the progress bar is 100 turn off the buttons and show the launch button
            if (rocketProgressBar.Progress >= 1)
            {
                R1ToRocketButton.IsEnabled = false;
                R2ToRocketButton.IsEnabled = false;
                R3ToRocketButton.IsEnabled = false;
                R4ToRocketButton.IsEnabled = false;
                R1ToRocketButton.IsVisible = false;
                R2ToRocketButton.IsVisible = false;
                R3ToRocketButton.IsVisible = false;
                R4ToRocketButton.IsVisible = false;
                R1ToRocketLabel.IsVisible = false;
                R2ToRocketLabel.IsVisible = false;
                R3ToRocketLabel.IsVisible = false;
                R4ToRocketLabel.IsVisible = false;
                LaunchButton.IsEnabled = true;
                LaunchButton.IsVisible = true;
            }
        }
        private void ChangeWorld()
        {
            // Change the current world to the next world in the sequence
            if (MainPage.currentWorld == "World1")
            {
                MainPage.currentWorld = "World2";
                MainPage.NewWorld();
            }
            else if (MainPage.currentWorld == "World2")
            {
                MainPage.currentWorld = "World3";
                MainPage.NewWorld();
            }
            // Add additional world changes here if needed
        }
    }
}
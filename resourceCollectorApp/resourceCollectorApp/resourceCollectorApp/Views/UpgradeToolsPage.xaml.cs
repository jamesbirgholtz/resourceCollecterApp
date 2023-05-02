using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace resourceCollectorApp
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpgradeToolsPage : ContentPage
    {
        public UpgradeToolsPage()
        {
            InitializeComponent();
            MainPage.ResourcesUpdated += MainPage_ResourcesUpdated;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                UpdateResourceLabels();
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

            R1PerSecondTool1UpgradeLabelText.Text = "Tool1 upgrade\n" + currentWorldResourceNames[0] + " per second x2\n" + "Cost: " + MainPage.resource1.perSecond1UpgradeCost.ToString("F0");
            R2PerSecondTool1UpgradeLabelText.Text = "Tool1 upgrade\n" + currentWorldResourceNames[1] + " per second x2\n" + "Cost: " + MainPage.resource2.perSecond1UpgradeCost.ToString("F0");
            R3PerSecondTool1UpgradeLabelText.Text = "Tool1 upgrade\n" + currentWorldResourceNames[2] + " per second x2\n" + "Cost: " + MainPage.resource3.perSecond1UpgradeCost.ToString("F0");
            R4PerSecondTool1UpgradeLabelText.Text = "Tool1 upgrade\n" + currentWorldResourceNames[3] + " per second x2\n" + "Cost: " + MainPage.resource4.perSecond1UpgradeCost.ToString("F0");

            R1PerSecondTool2UpgradeLabelText.Text = "Tool2 upgrade\n" + currentWorldResourceNames[0] + " per second x2\n" + "Cost: " + MainPage.resource1.perSecond2UpgradeCost.ToString("F0");
            R2PerSecondTool2UpgradeLabelText.Text = "Tool2 upgrade\n" + currentWorldResourceNames[1] + " per second x2\n" + "Cost: " + MainPage.resource2.perSecond2UpgradeCost.ToString("F0");
            R3PerSecondTool2UpgradeLabelText.Text = "Tool2 upgrade\n" + currentWorldResourceNames[2] + " per second x2\n" + "Cost: " + MainPage.resource3.perSecond2UpgradeCost.ToString("F0");
            R4PerSecondTool2UpgradeLabelText.Text = "Tool2 upgrade\n" + currentWorldResourceNames[3] + " per second x2\n" + "Cost: " + MainPage.resource4.perSecond2UpgradeCost.ToString("F0");

            R1PerSecondTool3UpgradeLabelText.Text = "Tool3 upgrade\n" + currentWorldResourceNames[0] + " per second x2\n" + "Cost: " + MainPage.resource1.perSecond3UpgradeCost.ToString("F0");
            R2PerSecondTool3UpgradeLabelText.Text = "Tool3 upgrade\n" + currentWorldResourceNames[1] + " per second x2\n" + "Cost: " + MainPage.resource2.perSecond3UpgradeCost.ToString("F0");
            R3PerSecondTool3UpgradeLabelText.Text = "Tool3 upgrade\n" + currentWorldResourceNames[2] + " per second x2\n" + "Cost: " + MainPage.resource3.perSecond3UpgradeCost.ToString("F0");
            R4PerSecondTool3UpgradeLabelText.Text = "Tool3 upgrade\n" + currentWorldResourceNames[3] + " per second x2\n" + "Cost: " + MainPage.resource4.perSecond3UpgradeCost.ToString("F0");
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
        public async Task ImageShake(Image image) {
            uint duration = 25;
            int offsetX = 5; 
            await image.TranslateTo(offsetX, 0, duration, Easing.Linear);
            await image.TranslateTo(-offsetX, 0, duration * 2, Easing.Linear);
            await image.TranslateTo(0, 0, duration, Easing.Linear);
        }

        // miner upgrade tree buttons
        private void R1PerSecondTool1Upgrade(object sender, EventArgs e)
        {
            MainPage.resource1.IncreasePerSecond1Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource1.Count < MainPage.resource1.perSecond1UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource1Image));
            }
            else {
                Task.WhenAll(ImageBounce(Resource1Image));
            }
        }
        private void R2PerSecondTool1Upgrade(object sender, EventArgs e)
        {
            MainPage.resource2.IncreasePerSecond1Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource2.Count < MainPage.resource2.perSecond1UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource2Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource2Image));
            }
        }
        private void R3PerSecondTool1Upgrade(object sender, EventArgs e)
        {
            MainPage.resource3.IncreasePerSecond1Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource3.Count < MainPage.resource3.perSecond1UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource3Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource3Image));
            }
        }
        private void R4PerSecondTool1Upgrade(object sender, EventArgs e)
        {
            MainPage.resource4.IncreasePerSecond1Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource4.Count < MainPage.resource4.perSecond1UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource4Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource4Image));
            }
        }
        // drill upgrade tree buttons
        private void R1PerSecondTool2Upgrade(object sender, EventArgs e)
        {
            MainPage.resource1.IncreasePerSecond2Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource1.Count < MainPage.resource1.perSecond2UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource1Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource1Image));
            }
        }
        private void R2PerSecondTool2Upgrade(object sender, EventArgs e)
        {
            MainPage.resource2.IncreasePerSecond2Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource2.Count < MainPage.resource2.perSecond2UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource2Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource2Image));
            }
        }
        private void R3PerSecondTool2Upgrade(object sender, EventArgs e)
        {
            MainPage.resource3.IncreasePerSecond2Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource3.Count < MainPage.resource3.perSecond2UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource3Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource3Image));
            }
        }
        private void R4PerSecondTool2Upgrade(object sender, EventArgs e)
        {
            MainPage.resource4.IncreasePerSecond2Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource4.Count < MainPage.resource4.perSecond2UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource4Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource4Image));
            }
        }
        //escavator upgrade tree buttons
        private void R1PerSecondTool3Upgrade(object sender, EventArgs e)
        {
            MainPage.resource1.IncreasePerSecond3Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource1.Count < MainPage.resource1.perSecond3UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource1Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource1Image));
            }
        }
        private void R2PerSecondTool3Upgrade(object sender, EventArgs e)
        {
            MainPage.resource2.IncreasePerSecond3Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource2.Count < MainPage.resource2.perSecond3UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource2Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource2Image));
            }
        }
        private void R3PerSecondTool3Upgrade(object sender, EventArgs e)
        {
            MainPage.resource3.IncreasePerSecond3Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource3.Count < MainPage.resource3.perSecond3UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource3Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource3Image));
            }
        }
        private void R4PerSecondTool3Upgrade(object sender, EventArgs e)
        {
            MainPage.resource4.IncreasePerSecond3Upgrade();
            UpdateResourceLabels();
            if (MainPage.resource4.Count < MainPage.resource4.perSecond3UpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource4Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource4Image));
            }
        }

    }
}
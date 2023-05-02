using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace resourceCollectorApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolPage : ContentPage
    {
        public ToolPage()
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

            R1PerClickUpgradeLabelText.Text = currentWorldResourceNames[0] + " Per click upgrade x2\n" + MainPage.resource1.PerClick + "\nCost: " + MainPage.resource1.PerClickUpgradeCost.ToString("F0");
            R2PerClickUpgradeLabelText.Text = currentWorldResourceNames[1] + " Per click upgrade x2\n" + MainPage.resource2.PerClick + "\nCost: " + MainPage.resource2.PerClickUpgradeCost.ToString("F0");
            R3PerClickUpgradeLabelText.Text = currentWorldResourceNames[2] + " Per click upgrade x2\n" + MainPage.resource3.PerClick + "\nCost: " + MainPage.resource3.PerClickUpgradeCost.ToString("F0");
            R4PerClickUpgradeLabelText.Text = currentWorldResourceNames[3] + " Per click upgrade x2\n" + MainPage.resource4.PerClick + "\nCost: " + MainPage.resource4.PerClickUpgradeCost.ToString("F0");

            R1PerSecondTool1LabelText.Text = "Tool1\n" + currentWorldResourceNames[0] + "\n" + MainPage.resource1.perSecond1 + "/s\nCost: " + MainPage.resource1.PerSecondUpgrade1Cost.ToString("F0");
            R2PerSecondTool1LabelText.Text = "Tool1\n" + currentWorldResourceNames[1] + "\n" + MainPage.resource2.perSecond1 + "/s\nCost: " + MainPage.resource2.PerSecondUpgrade1Cost.ToString("F0");
            R3PerSecondTool1LabelText.Text = "Tool1\n" + currentWorldResourceNames[2] + "\n" + MainPage.resource3.perSecond1 + "/s\nCost: " + MainPage.resource3.PerSecondUpgrade1Cost.ToString("F0");
            R4PerSecondTool1LabelText.Text = "Tool1\n" + currentWorldResourceNames[3] + "\n" + MainPage.resource4.perSecond1 + "/s\nCost: " + MainPage.resource4.PerSecondUpgrade1Cost.ToString("F0");

            R1PerSecondTool2LabelText.Text = "Tool2\n" + currentWorldResourceNames[0] + "\n" + MainPage.resource1.perSecond2 + "/s\nCost: " + MainPage.resource1.PerSecondUpgrade2Cost.ToString("F0");
            R2PerSecondTool2LabelText.Text = "Tool2\n" + currentWorldResourceNames[1] + "\n" + MainPage.resource2.perSecond2 + "/s\nCost: " + MainPage.resource2.PerSecondUpgrade2Cost.ToString("F0");
            R3PerSecondTool2LabelText.Text = "Tool2\n" + currentWorldResourceNames[2] + "\n" + MainPage.resource3.perSecond2 + "/s\nCost: " + MainPage.resource3.PerSecondUpgrade2Cost.ToString("F0");
            R4PerSecondTool2LabelText.Text = "Tool2\n" + currentWorldResourceNames[3] + "\n" + MainPage.resource4.perSecond2 + "/s\nCost: " + MainPage.resource4.PerSecondUpgrade2Cost.ToString("F0");

            R1PerSecondTool3LabelText.Text = "Tool3\n" + currentWorldResourceNames[0] + "\n" + MainPage.resource1.perSecond3 + "/s\nCost: " + MainPage.resource1.PerSecondUpgrade3Cost.ToString("F0");
            R2PerSecondTool3LabelText.Text = "Tool3\n" + currentWorldResourceNames[1] + "\n" + MainPage.resource2.perSecond3 + "/s\nCost: " + MainPage.resource2.PerSecondUpgrade3Cost.ToString("F0");
            R3PerSecondTool3LabelText.Text = "Tool3\n" + currentWorldResourceNames[2] + "\n" + MainPage.resource3.perSecond3 + "/s\nCost: " + MainPage.resource3.PerSecondUpgrade3Cost.ToString("F0");
            R4PerSecondTool3LabelText.Text = "Tool3\n" + currentWorldResourceNames[3] + "\n" + MainPage.resource4.perSecond3 + "/s\nCost: " + MainPage.resource4.PerSecondUpgrade3Cost.ToString("F0");

        }
        public async Task ImageBounce(Image image)
        {
            _ = await image.ScaleTo(1.25, 50);
            _ = await image.ScaleTo(1, 50);
        }
        public async Task ImageShake(Image image)
        {
            uint duration = 25;
            int offsetX = 5;
            await image.TranslateTo(offsetX, 0, duration, Easing.Linear);
            await image.TranslateTo(-offsetX, 0, duration * 2, Easing.Linear);
            await image.TranslateTo(0, 0, duration, Easing.Linear);
        }

        private void MainPage_ResourcesUpdated(object sender, EventArgs e)
        {
            UpdateResourceLabels();
        }

        private void R1PerClickUpgrade(object sender, EventArgs e)
        {
            MainPage.resource1.IncreasePerClick();
            UpdateResourceLabels();
            if (MainPage.resource1.Count < MainPage.resource1.PerClickUpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource1Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource1Image));
            }
        }
        private void R2PerClickUpgrade(object sender, EventArgs e)
        {
            MainPage.resource2.IncreasePerClick();
            UpdateResourceLabels();
            if (MainPage.resource2.Count < MainPage.resource2.PerClickUpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource2Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource2Image));
            }
        }
        private void R3PerClickUpgrade(object sender, EventArgs e)
        {
            MainPage.resource3.IncreasePerClick();
            UpdateResourceLabels();
            if (MainPage.resource3.Count < MainPage.resource3.PerClickUpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource3Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource3Image));
            }
        }
        private void R4PerClickUpgrade(object sender, EventArgs e)
        {
            MainPage.resource4.IncreasePerClick();
            UpdateResourceLabels();
            if (MainPage.resource4.Count < MainPage.resource4.PerClickUpgradeCost)
            {
                Task.WhenAll(ImageShake(Resource4Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource4Image));
            }
        }

        private void R1PerSecondTool1(object sender, EventArgs e)
        {
            MainPage.resource1.IncreasePerSecond1();
            UpdateResourceLabels();
            if (MainPage.resource1.Count < MainPage.resource1.PerSecondUpgrade1Cost)
            {
                Task.WhenAll(ImageShake(Resource1Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource1Image));
            }
        }
        private void R2PerSecondTool1(object sender, EventArgs e)
        {
            MainPage.resource2.IncreasePerSecond1();
            UpdateResourceLabels();
            if (MainPage.resource2.Count < MainPage.resource2.PerSecondUpgrade1Cost)
            {
                Task.WhenAll(ImageShake(Resource2Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource2Image));
            }
        }
        private void R3PerSecondTool1(object sender, EventArgs e)
        {
            MainPage.resource3.IncreasePerSecond1();
            UpdateResourceLabels();
            if (MainPage.resource3.Count < MainPage.resource3.PerSecondUpgrade1Cost)
            {
                Task.WhenAll(ImageShake(Resource3Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource3Image));
            }
        }
        private void R4PerSecondTool1(object sender, EventArgs e)
        {
            MainPage.resource4.IncreasePerSecond1();
            UpdateResourceLabels();
            if (MainPage.resource4.Count < MainPage.resource4.PerSecondUpgrade1Cost)
            {
                Task.WhenAll(ImageShake(Resource4Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource4Image));
            }
        }

        private void R1PerSecondTool2(object sender, EventArgs e)
        {
            MainPage.resource1.IncreasePerSecond2();
            UpdateResourceLabels();
            if (MainPage.resource1.Count < MainPage.resource1.PerSecondUpgrade2Cost)
            {
                Task.WhenAll(ImageShake(Resource1Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource1Image));
            }
        }
        private void R2PerSecondTool2(object sender, EventArgs e)
        {
            MainPage.resource2.IncreasePerSecond2();
            UpdateResourceLabels();
            if (MainPage.resource2.Count < MainPage.resource2.PerSecondUpgrade2Cost)
            {
                Task.WhenAll(ImageShake(Resource2Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource2Image));
            }
        }
        private void R3PerSecondTool2(object sender, EventArgs e)
        {
            MainPage.resource3.IncreasePerSecond2();
            UpdateResourceLabels();
            if (MainPage.resource3.Count < MainPage.resource3.PerSecondUpgrade2Cost)
            {
                Task.WhenAll(ImageShake(Resource3Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource3Image));
            }
        }
        private void R4PerSecondTool2(object sender, EventArgs e)
        {
            MainPage.resource4.IncreasePerSecond2();
            UpdateResourceLabels();
            if (MainPage.resource4.Count < MainPage.resource4.PerSecondUpgrade2Cost)
            {
                Task.WhenAll(ImageShake(Resource4Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource4Image));
            }
        }
        private void R1PerSecondTool3(object sender, EventArgs e)
        {
            MainPage.resource1.IncreasePerSecond3();
            UpdateResourceLabels();
            if (MainPage.resource1.Count < MainPage.resource1.PerSecondUpgrade3Cost)
            {
                Task.WhenAll(ImageShake(Resource1Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource1Image));
            }
        }
        private void R2PerSecondTool3(object sender, EventArgs e)
        {
            MainPage.resource2.IncreasePerSecond3();
            UpdateResourceLabels();
            if (MainPage.resource2.Count < MainPage.resource2.PerSecondUpgrade3Cost)
            {
                Task.WhenAll(ImageShake(Resource2Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource2Image));
            }
        }
        private void R3PerSecondTool3(object sender, EventArgs e)
        {
            MainPage.resource3.IncreasePerSecond3();
            UpdateResourceLabels();
            if (MainPage.resource3.Count < MainPage.resource3.PerSecondUpgrade3Cost)
            {
                Task.WhenAll(ImageShake(Resource3Image));
            }
            else
            {
                Task.WhenAll(ImageBounce(Resource3Image));
            }
        }
        private void R4PerSecondTool3(object sender, EventArgs e)
        {
            MainPage.resource4.IncreasePerSecond3();
            UpdateResourceLabels();
            if (MainPage.resource4.Count < MainPage.resource4.PerSecondUpgrade3Cost)
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
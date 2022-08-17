using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ColorPicker;

public partial class MainPage : ContentPage
{
    bool isRandom;
    string hexValue;

    public MainPage()
    {
        InitializeComponent();
    }


    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = redSlider.Value;
            var green = greenSlider.Value;
            var blue = blueSlider.Value;

            var color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
        RandomBbn.BackgroundColor = color;
        MyGrid.BackgroundColor = color;
        hexValue = color.ToHex();
        lblHex.Text = hexValue;
    }

    private void RandomBbn_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        var rand = new Random();

        var color = Color.FromRgb(rand.Next(0, 256),
                                      rand.Next(0, 256),
                                      rand.Next(0, 256));
        SetColor(color);

        redSlider.Value = color.Red;
        greenSlider.Value = color.Green;
        blueSlider.Value = color.Blue;
        isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        var toast = Toast.Make("Color copied", ToastDuration.Long, 14);
        await toast.Show();
    }
}


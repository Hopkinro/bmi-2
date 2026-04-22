using BMICalculatorNavigationApp.Models;

namespace BMICalculatorNavigationApp.Pages;

public partial class MainPage : ContentPage
{
    private string selectedGender = "Male";

    public MainPage()
    {
        InitializeComponent();
        UpdateGenderSelection();
    }

    private void OnWeightSliderChanged(object sender, ValueChangedEventArgs e)
    {
        WeightValueLabel.Text = $"{Math.Round(e.NewValue)} lbs";
    }

    private void OnHeightSliderChanged(object sender, ValueChangedEventArgs e)
    {
        HeightValueLabel.Text = $"{Math.Round(e.NewValue)} in";
    }

    private void OnMaleTapped(object sender, TappedEventArgs e)
    {
        selectedGender = "Male";
        UpdateGenderSelection();
    }

    private void OnFemaleTapped(object sender, TappedEventArgs e)
    {
        selectedGender = "Female";
        UpdateGenderSelection();
    }

    private void UpdateGenderSelection()
    {
        MaleFrame.BorderColor = selectedGender == "Male" ? Colors.Blue : Colors.Gray;
        FemaleFrame.BorderColor = selectedGender == "Female" ? Colors.HotPink : Colors.Gray;
    }

    private async void OnCalculateBmiClicked(object sender, EventArgs e)
    {
        double weight = Math.Round(WeightSlider.Value);
        double height = Math.Round(HeightSlider.Value);

        if (height <= 0)
        {
            await DisplayAlert("Invalid Input", "Height must be greater than 0.", "OK");
            return;
        }

        double bmi = (weight * 703) / (height * height);
        string category = GetBmiCategory(bmi, selectedGender);

        var userData = new BmiUserData
        {
            Weight = weight,
            Height = height,
            Gender = selectedGender,
            BMI = bmi,
            Category = category
        };

        await Navigation.PushAsync(new BmiResultPage(userData));
    }

    private string GetBmiCategory(double bmi, string gender)
    {
        if (gender == "Male")
        {
            if (bmi < 20) return "Underweight";
            if (bmi < 25) return "Normal weight";
            if (bmi < 30) return "Overweight";
            return "Obese";
        }
        else
        {
            if (bmi < 19) return "Underweight";
            if (bmi < 24) return "Normal weight";
            if (bmi < 29) return "Overweight";
            return "Obese";
        }
    }
}
using System.Text;

namespace personal_finance_maui.Views;

public partial class TransactionAdd : ContentPage
{
	public TransactionAdd()
	{
		InitializeComponent();

		
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void OnButton_Clicked_Save(object sender, EventArgs e)
    {

    }

    private bool IsValidData()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();

        if(string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.AppendLine("O campo 'Nome' deve ser preenchido!");
            valid = false;
        }

        double result;

        if(string.IsNullOrEmpty(EntryName.Text) && !double.TryParse(EntryName.Text, out result))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido!");
            valid = false;
        }

        if(valid == false)
        {
            LabelError.Text = sb.ToString();
        }

        return valid;
    }
}
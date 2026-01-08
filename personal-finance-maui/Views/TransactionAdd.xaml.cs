using CommunityToolkit.Mvvm.Messaging;
using personal_finance_maui.Libraries.Utils;
using personal_finance_maui.Models;
using personal_finance_maui.Repositories;
using System.Text;

namespace personal_finance_maui.Views;

public partial class TransactionAdd : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;
	public TransactionAdd(ITransactionRepository transactionRepository)
	{
        InitializeComponent();

        _transactionRepository = transactionRepository;
	}

    private void TapGestureRecognizerTappedToClose(object sender, TappedEventArgs e)
    {
        KeyboardFixBugs.HideKeyboard();
        Navigation.PopModalAsync();
    }

    private void OnButton_Clicked_Save(object sender, EventArgs e)
    {
        if(IsValidData() == false)
        {
            return;
        }

        SaveTransactionInDatabase();

        KeyboardFixBugs.HideKeyboard();
        Navigation.PopModalAsync();

        WeakReferenceMessenger.Default.Send<string>(string.Empty);
    }

    private void SaveTransactionInDatabase()
    {
        Transaction transaction = new Transaction
        {
            Name = EntryName.Text,
            Type = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expanse,
            Date = (DateTimeOffset)DatePickerDate.Date,
            Value = double.Parse(EntryValue.Text),
        };

        _transactionRepository.Add(transaction);
    }

    private bool IsValidData()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.AppendLine("O campo 'Nome' deve ser preenchido!");
            valid = false;
        }

        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido!");
            valid = false;
        }

        double result;
        if (!string.IsNullOrEmpty(EntryValue.Text) && !double.TryParse(EntryValue.Text, out result))
        {
            sb.AppendLine("O campo 'Valor' inválido!");
            valid = false;
        }


        if (valid == false)
        {
            LabelError.IsVisible = true;
            LabelError.Text = sb.ToString();
        }
        return valid;
    }
}
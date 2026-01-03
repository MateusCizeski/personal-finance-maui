using CommunityToolkit.Mvvm.Messaging;
using personal_finance_maui.Models;
using personal_finance_maui.Repositories;
using System.Text;

namespace personal_finance_maui.Views;

public partial class TransactionEdit : ContentPage
{
    private Transaction _transaction;
    private readonly ITransactionRepository _transactionRepository;
    public TransactionEdit(ITransactionRepository transactionRepository)
	{
        _transactionRepository = transactionRepository;

        InitializeComponent();
	}
    
    public void SetTransactionToEdit(Transaction transaction)
    {
        _transaction = transaction;

        if(transaction.Type == TransactionType.Income)
        {
            RadioIncome.IsChecked = true;
        }else
        {
            RadioExpanse.IsChecked = true;
        }

        EntryName.Text = transaction.Name;
        DatePickerDate.Date = transaction.Date.Date;
        EntryValue.Text = transaction.Value.ToString();
    }

    private void TapGestureRecognizerTappedToClose(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void OnButton_Clicked_Save(object sender, EventArgs e)
    {
        if (IsValidData() == false)
        {
            return;
        }

        SaveTransactionInDatabase();
        Navigation.PopModalAsync();

        WeakReferenceMessenger.Default.Send<string>(string.Empty);
    }

    private void SaveTransactionInDatabase()
    {
        Transaction transaction = new Transaction
        {
            Id = _transaction.Id,
            Name = EntryName.Text,
            Type = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expanse,
            Date = (DateTimeOffset)DatePickerDate.Date,
            Value = double.Parse(EntryValue.Text),
        };

        _transactionRepository.Update(transaction);
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
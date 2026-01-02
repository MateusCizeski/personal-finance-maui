using CommunityToolkit.Mvvm.Messaging;
using personal_finance_maui.Models;
using personal_finance_maui.Repositories;

namespace personal_finance_maui.Views;

public partial class TransactionList : ContentPage
{
	private readonly ITransactionRepository _transactionRepository;
    public TransactionList(ITransactionRepository transactionRepository)
	{
		_transactionRepository = transactionRepository;

        InitializeComponent();

        Reload();

		WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
		{
            Reload();
        });
	}

	private void Reload()
	{
		var items = _transactionRepository.GetAll();
        CollectionViewTransactions.ItemsSource = items;

		double income = items.Where(a => a.Type == Models.TransactionType.Income).Sum(a => a.Value);
		double expanse = items.Where(a => a.Type == Models.TransactionType.Expanse).Sum(a => a.Value);
		double balance = income - expanse;

		LabelIncome.Text = income.ToString("C");
		LabelExpanse.Text = expanse.ToString("C");
		LabelBalance.Text = balance.ToString("C");
    }

	private void OnClickToTransactionAdd(Object sender, EventArgs eventArgs)
	{
		
		var transactionAdd = Handler.MauiContext.Services.GetService<TransactionAdd>();

		Navigation.PushModalAsync(transactionAdd);
	}

    private void TapGestureRecognizerTappedToTransactionEdit(object sender, TappedEventArgs e)
    {
		var grid = (Grid)sender;
		var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];
		Transaction transaction = (Transaction)gesture.CommandParameter;

        var transactionEdit = Handler.MauiContext.Services.GetService<TransactionEdit>();
		transactionEdit.SetTransactionToEdit(transaction);
        Navigation.PushModalAsync(transactionEdit);
    }
}
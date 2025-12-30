using CommunityToolkit.Mvvm.Messaging;
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
        CollectionViewTransactions.ItemsSource = _transactionRepository.GetAll();
    }

	private void OnClickToTransactionAdd(Object sender, EventArgs eventArgs)
	{
		
		var transactionAdd = Handler.MauiContext.Services.GetService<TransactionAdd>();

		Navigation.PushModalAsync(transactionAdd);
	}
	private void OnClickToTransactionEdit(Object sender, EventArgs eventArgs)
	{
        var transactionEdit = Handler.MauiContext.Services.GetService<TransactionEdit>();

        Navigation.PushModalAsync(transactionEdit);
	}
}
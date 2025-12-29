using personal_finance_maui.Repositories;

namespace personal_finance_maui.Views;

public partial class TransactionList : ContentPage
{
	private readonly TransactionAdd _transactionAdd;
	private readonly TransactionEdit _transactionEdit;
	private readonly ITransactionRepository _transactionRepository;
    public TransactionList(TransactionAdd transactionAdd, TransactionEdit transactionEdit, ITransactionRepository transactionRepository)
	{
		_transactionAdd = transactionAdd;
		_transactionEdit = transactionEdit;
		_transactionRepository = transactionRepository;


        InitializeComponent();

		CollectionViewTransactions.ItemsSource = _transactionRepository.GetAll();
	}

	private void OnClickToTransactionAdd(Object sender, EventArgs eventArgs)
	{
		Navigation.PushModalAsync(_transactionAdd);
	}
	private void OnClickToTransactionEdit(Object sender, EventArgs eventArgs)
	{
        Navigation.PushModalAsync(_transactionEdit);
	}
}
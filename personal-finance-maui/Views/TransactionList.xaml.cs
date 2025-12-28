namespace personal_finance_maui.Views;

public partial class TransactionList : ContentPage
{
	private readonly TransactionAdd _transactionAdd;
	private readonly TransactionEdit _transactionEdit;
	public TransactionList(TransactionAdd transactionAdd, TransactionEdit transactionEdit)
	{
		_transactionAdd = transactionAdd;
		_transactionEdit = transactionEdit;

		InitializeComponent();
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
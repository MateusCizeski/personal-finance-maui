namespace personal_finance_maui.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
		InitializeComponent();
	}

	private void OnClickToTransactionAdd(Object sender, EventArgs eventArgs)
	{
		Navigation.PushModalAsync(new TransactionAdd());
	}
	private void OnClickToTransactionEdit(Object sender, EventArgs eventArgs)
	{
        Navigation.PushModalAsync(new TransactionEdit());
	}
}
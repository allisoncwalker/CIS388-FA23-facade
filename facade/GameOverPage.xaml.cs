namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage
{
	private bool didWin;
	public bool DidWin
	{
		get => didWin;
		set
		{
			didWin = value;
			if(didWin)
			{
				ResultLabel.Text = "You Knew a Hex Code. You Win, But Did You Really?";
			}
			else
			{
				ResultLabel.Text = "I guess this means you're a loser!";
			}
		}
	}

	//private string result;
	//public string Result {
	//	get => result;
	//	set
	//	{
	//		result = value;
	//           ResultLabel.Text = "You " + result;
	//       }
	//}

	public GameOverPage()
	{
		InitializeComponent();
	}
}

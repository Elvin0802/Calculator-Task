using System.Data;
using System.Windows;

namespace WindowsCalculator.Views;

public partial class CalculatorMain : Window
{
	public CalculatorMain()
	{
		InitializeComponent();
	}

	private bool CheckNumbersEnd()
		=> new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' }.Any(c => c == Numbers.Text.Last());
	private bool CheckZero()
		=> Numbers.Text.All(c => c == '0');
	private bool CheckEndOperator()
	{
		var c = Numbers.Text.Last();

		if (c == '-' || c == '*' || c == '/' || c == '+') return true;
		else return false;
	}

	private void AddDot_Click(object sender, RoutedEventArgs e)
	{
		if (string.IsNullOrEmpty(Numbers.Text)) return;

		if ((Numbers.Text.Count(c => c == '.') < 1) ||
			(Numbers.Text.Count(c => c == '.') <= Numbers.Text.Count(c => c=='+' || c=='-'||c=='*' || c=='/')))
			Numbers.Text += ".";
	}

	private void DeleteEnd_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			Numbers.Text = Numbers.Text.Remove(Numbers.Text.Length - 1);
		}
		catch { return; }
	}

	private void PlusButton_Click(object sender, RoutedEventArgs e)
	{
		if (string.IsNullOrEmpty(Numbers.Text)) return;

		if (CheckNumbersEnd())
		{
			if (CheckEndOperator())
				Numbers.Text = Numbers.Text.Remove(Numbers.Text.Length-1);

			Numbers.Text+= "+";
		}
	}
	private void MinusButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (CheckNumbersEnd())
			{
				if (CheckEndOperator())
					Numbers.Text = Numbers.Text.Remove(Numbers.Text.Length-1);

				Numbers.Text+= "-";
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
	private void DivideButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (CheckNumbersEnd())
			{
				if (CheckEndOperator())
					Numbers.Text = Numbers.Text.Remove(Numbers.Text.Length-1);

				Numbers.Text+= "/";
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
	private void MultiplyButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (CheckNumbersEnd())
			{
				if (CheckEndOperator())
					Numbers.Text = Numbers.Text.Remove(Numbers.Text.Length-1);

				Numbers.Text+= "*";
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

	private void CButton_Click(object sender, RoutedEventArgs e)
	{
		Numbers.Text = "0";
	}
	private void CEButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			for (int c = Numbers.Text.Length-1; c >= 0; c--)
			{
				if (Numbers.Text[c] == '+' || Numbers.Text[c] == '-' ||
						Numbers.Text[c] == '*' || Numbers.Text[c] == '/')
					break;

				Numbers.Text = Numbers.Text.Remove(c);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

	private void ChangeMinusPlusButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (Numbers.Text.First() == '-')
			{
				Numbers.Text = Numbers.Text.Remove(0, 1);
				return;
			}

			string result = "-";
			result += Numbers.Text;
			Numbers.Text =  result;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

	private void Num1_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "1";
	}
	private void Num2_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "2";
	}
	private void Num3_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "3";
	}
	private void Num4_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "4";
	}
	private void Num5_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "5";
	}
	private void Num6_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "6";
	}
	private void Num7_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "7";
	}
	private void Num8_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "8";
	}
	private void Num9_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "9";
	}
	private void Num0_Click(object sender, RoutedEventArgs e)
	{
		if (CheckZero())
			Numbers.Text="";

		Numbers.Text+= "0";
	}

	private void Equal_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (!CheckNumbersEnd())
				return;

			double result = Convert.ToDouble(new DataTable().Compute(Numbers.Text, null));

			Numbers.Text = result.ToString
				("0.########################", System.Globalization.CultureInfo.InvariantCulture);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

	private void SqrtNumX_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (!CheckNumbersEnd())
				return;

			Numbers.Text =
				Math.Sqrt(Convert.ToDouble(new DataTable().Compute(Numbers.Text, null))).ToString();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
	private void To2PowX_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (!CheckNumbersEnd())
				return;

			Numbers.Text = Math.Pow
			(Convert.ToDouble(new DataTable().Compute(Numbers.Text, null)), 2.0).ToString();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
	private void PercentX_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (!CheckNumbersEnd())
				return;

			Numbers.Text = (Convert.ToDouble(Numbers.Text) / 100.0).ToString();

			string ns = "";

			foreach (char c in Numbers.Text)
			{
				if (c == ',') { ns += '.'; continue; }

				ns += c;
			}
			Numbers.Text = ns;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
	private void OneDivideX_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Numbers.Text)) return;

			if (!CheckNumbersEnd())
				return;

			Numbers.Text = (1.0 / Convert.ToDouble(Numbers.Text)).ToString();

			string ns = "";

			foreach (char c in Numbers.Text)
			{
				if (c == ',') { ns += '.'; continue; }

				ns += c;
			}
			Numbers.Text = ns;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error", $"{ex.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}


}

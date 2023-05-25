using System.Data;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            ResultLabel.Text = string.Empty;
        }

        private void Calculate()
        {
            string expression = ResultLabel.Text.Replace("%", "/100")
                                                .Replace('\u00d7', '*')
                                                .Replace('\u00f7', '/');
            DataTable dt = new DataTable();
            decimal expr = Convert.ToDecimal(dt.Compute(expression, ""));
            ExpressionLabel.Text = ResultLabel.Text;
            if ((expr % 1) == 0) ResultLabel.Text = expr.ToString("G29").Replace(',', '.');
            else ResultLabel.Text = expr.ToString().Replace(',', '.');
        }

        private void Backspace()
        {
            if (ResultLabel.Text == string.Empty
             || ResultLabel.Text == "0")
                ResultLabel.Text = "0";
            else
            {
                ResultLabel.Text = ResultLabel.Text.Substring(0, ResultLabel.Text.Length - 1);
                if (ResultLabel.Text.Length == 0)
                    ResultLabel.Text = "0";
            }
        }

        private void CalculatorBtn_OnPressed(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (ResultLabel.Text == "0") Clear();

            if (btn.Text == "=") Calculate();
            else if (btn.Text == "\u232b") Backspace();
            else if (btn.Text == "()")
            {
                if (ResultLabel.Text == string.Empty)
                    ResultLabel.Text = "(";

                else
                {
                    if (char.IsDigit(ResultLabel.Text.Last())
                     || ResultLabel.Text.Last() == ')') ResultLabel.Text += ")";
                    else ResultLabel.Text += "(";
                }
            }
            else if (btn.Text == "C")
            {
                ExpressionLabel.Text = string.Empty;
                ResultLabel.Text = "0";
            }
            else
            {
                if (!string.IsNullOrEmpty(ExpressionLabel.Text)) ExpressionLabel.Text = string.Empty;
                ResultLabel.Text += btn.Text;
            }
        }
    }
}
using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Globalization;


namespace calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (calce_text.Text == "0")
            {
                calce_text.Text = button.Content.ToString();
            }else if (calce_text.Text == "∞"){
                calce_text.Text = button.Content.ToString();
            }else{
                calce_text.Text += button.Content.ToString();
            }

        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ReplaceLastCharIfNotNumeric(button.Content.ToString().Last());
        }


        // Обработчик события для кнопки "С"
        private void ClearButton_Click(object sender, EventArgs e)
        {
            calce_text.Text = "0";
        }


        private void EqualsButton_Click(object sender, EventArgs e)
        {
            try
            {
                char lastChar = calce_text.Text.LastOrDefault();
                if(Char.IsDigit(lastChar)){
                    string expression = calce_text.Text.Replace(',', '.');

                    // Вычисляем значение
                    double result = Convert.ToDouble(new DataTable().Compute(expression, null), CultureInfo.InvariantCulture);

                    // Выводим результат
                    calce_text.Text = result.ToString(CultureInfo.InvariantCulture);
                }
            }
            catch{

            }
        }

        private void ReplaceLastCharIfNotNumeric(char newChar)
        {
            if (!string.IsNullOrEmpty(calce_text.Text))
            {
                int lastIndex = calce_text.Text.Length - 1;
                char lastChar = calce_text.Text[lastIndex];

                if (!Char.IsDigit(lastChar))
                {
                    // Заменяем последний символ, если он не является числом
                    calce_text.Text = calce_text.Text.Substring(0, lastIndex) + newChar;
                }else{
                    calce_text.Text += newChar;
                }
            }
        }


    }
}

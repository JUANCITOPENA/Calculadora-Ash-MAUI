namespace MauiApp110
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnOperacionClicked(object sender, EventArgs e)
        {
            if (sender is not Button btn) return;

            string operacion = btn.CommandParameter?.ToString() ?? string.Empty;

            // Validación de entradas numéricas
            if (!double.TryParse(TxtNum1.Text, out double n1) || !double.TryParse(TxtNum2.Text, out double n2))
            {
                LblResultado.Text = "Ingrese valores válidos";
                return;
            }

            double resultado = 0;

            switch (operacion)
            {
                case "+":
                    resultado = n1 + n2;
                    break;
                case "-":
                    resultado = n1 - n2;
                    break;
                case "*":
                    resultado = n1 * n2;
                    break;
                case "/":
                    if (n2 == 0)
                    {
                        LblResultado.Text = "Error: División por 0";
                        return;
                    }
                    resultado = n1 / n2;
                    break;
            }

            LblResultado.Text = $"Resultado: {resultado}";
        }
    }
}

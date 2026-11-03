using System.Globalization;

namespace MauiApp110;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnOperacionClicked(object? sender, EventArgs e)
    {
        if (sender is not Button btn) return;

        string operacion = btn.CommandParameter?.ToString() ?? string.Empty;

        // 1. Obtención y validación defensiva de texto
        string raw1 = TxtNum1.Text ?? string.Empty;
        string raw2 = TxtNum2.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(raw1))
        {
            LblResultado.Text = "⚠️ Ingrese el primer número";
            TxtNum1.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(raw2))
        {
            LblResultado.Text = "⚠️ Ingrese el segundo número";
            TxtNum2.Focus();
            return;
        }

        if (!TryParseFlexibleNumber(raw1, out double n1))
        {
            LblResultado.Text = "⚠️ Primer valor no válido";
            TxtNum1.Focus();
            return;
        }

        if (!TryParseFlexibleNumber(raw2, out double n2))
        {
            LblResultado.Text = "⚠️ Segundo valor no válido";
            TxtNum2.Focus();
            return;
        }

        // 2. Ejecución de la operación seleccionada
        double resultado;

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
                if (Math.Abs(n2) < double.Epsilon)
                {
                    LblResultado.Text = "❌ Error: División por 0";
                    return;
                }
                resultado = n1 / n2;
                break;

            default:
                LblResultado.Text = "⚠️ Seleccione una operación (+, -, *, /)";
                return;
        }

        // 3. Formateo estético del resultado
        string textoFormateado = (resultado % 1 == 0)
            ? resultado.ToString("N0", CultureInfo.InvariantCulture).Replace(",", "")
            : resultado.ToString("G10", CultureInfo.InvariantCulture);

        LblResultado.Text = $"Resultado: {textoFormateado}";
    }

    /// <summary>
    /// Parser robusto compatible con InvariantCulture, culturas hispanas, espacios accidentales,
    /// y separación decimal mediante punto (.) o coma (,).
    /// </summary>
    public static bool TryParseFlexibleNumber(string? input, out double value)
    {
        value = 0;
        if (string.IsNullOrWhiteSpace(input)) return false;

        // Limpiar espacios comunes, tabulaciones y caracteres invisibles Unicode (\u00A0, \u200B)
        string clean = input.Trim()
            .Replace("\u00A0", "")
            .Replace("\u200B", "")
            .Replace(" ", "");

        // Caso con ambos separadores (ej. 1,500.50 o 1.500,50)
        if (clean.Contains(',') && clean.Contains('.'))
        {
            int lastComma = clean.LastIndexOf(',');
            int lastDot = clean.LastIndexOf('.');
            if (lastDot > lastComma)
            {
                // Formato inglés: coma = miles, punto = decimal
                clean = clean.Replace(",", "");
                return double.TryParse(clean, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
            }
            else
            {
                // Formato europeo/hispano: punto = miles, coma = decimal
                clean = clean.Replace(".", "").Replace(',', '.');
                return double.TryParse(clean, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
            }
        }

        // Caso con solo coma (ej. 500,5 o 450,0) -> se interpreta como decimal
        if (clean.Contains(','))
        {
            string withDot = clean.Replace(',', '.');
            if (double.TryParse(withDot, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return true;
        }

        // Caso con punto decimal o entero estándar
        if (double.TryParse(clean, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            return true;

        if (double.TryParse(clean, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
            return true;

        return false;
    }
}

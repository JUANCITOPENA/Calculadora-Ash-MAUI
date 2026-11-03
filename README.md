# 📱 Calculadora Ash MAUI ✨

> **Proyecto:** Ejercicio 6 - Programación de Dispositivos Móviles  
> **Framework:** .NET MAUI (`C#` + `XAML`)  
> **Tema visual:** Formas onduladas orgánicas / asimétricas & paleta pastel 🎨

---

## 📌 Tabla de Contenidos
1. [🌟 Resumen del Proyecto](#-resumen-del-proyecto)
2. [🎨 Especificaciones Visuales y Paleta](#-especificaciones-visuales-y-paleta)
3. [📁 Código de la Interfaz: `MainPage.xaml`](#-código-de-la-interfaz-mainpagexaml)
4. [⚙️ Lógica de Operaciones: `MainPage.xaml.cs`](#-lógica-de-operaciones-mainpagexamlcs)
5. [💡 ¿Cómo funcionan los bordes ondulados?](#-cómo-funcionan-los-bordes-ondulados)
6. [🚀 Pasos para Ejecutar](#-pasos-para-ejecutar)
7. [👨‍💻 Autor & Créditos](#-autor--créditos)

---

## 🌟 Resumen del Proyecto

Esta aplicación reproduce fielmente el diseño de cuaderno de la **Calculadora Ash MAUI**, implementando:
* **Títulos y subtítulos** centrados y jerarquizados.
* **Campos de texto (`Entry`)** enmarcados en siluetas vectoriales onduladas/asimétricas tipo festoneado.
* **4 Botones de operación circulares** con la paleta de colores especificada (+, -, *, /).
* **Área de resultado** separada por una línea divisoria minimalista.

---

## 🎨 Especificaciones Visuales y Paleta

| Elemento | Control / Propiedad | Color HEX | Detalle Visual |
| :--- | :--- | :--- | :--- |
| **Fondo General** | `BackgroundColor` | `#F4F5F7` | Gris claro neutro |
| **Borde Entrada 1** | `Path` (Bézier) | `#E65100` | Naranja terracota ondulado |
| **Borde Entrada 2** | `Path` (Bézier) | `#1E3A8A` | Azul marino ondulado |
| **Botón Suma (`+`)** | `Button` circular | `#D1C4E9` | Morado pastel claro |
| **Botón Resta (`-`)** | `Button` circular | `#BBDEFB` | Azul pastel claro |
| **Botón Mult (`*`)** | `Button` circular | `#FFE082` | Mamey / amarillo pastel |
| **Botón Div (`/`)** | `Button` circular | `#F8BBD0` | Rosado pastel claro |

---

## 📁 Código de la Interfaz: `MainPage.xaml`

Copia y pega este código dentro de tu archivo `MainPage.xaml`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="CalculadoraAsh.MainPage"
             BackgroundColor="#F4F5F7">

    <ScrollView>
        <VerticalStackLayout Padding="30,40"
                             Spacing="22"
                             VerticalOptions="Center">

            <!-- 🏷️ ENCABEZADOS DE LA APP -->
            <Label Text="Calculadora Ash MAUI"
                   FontSize="26"
                   FontAttributes="Bold"
                   TextColor="#1E293B"
                   HorizontalTextAlignment="Center" />

            <Label Text="Ingrese los números aquí"
                   FontSize="16"
                   TextColor="#64748B"
                   HorizontalTextAlignment="Center" />

            <!-- 〰️ PRIMER NÚMERO: Marco con ondas estilo terracota -->
            <Grid HeightRequest="56" 
                  HorizontalOptions="Fill">
                
                <!-- Trazado vectorial SVG de ondas Bézier -->
                <Path Aspect="Fill"
                      Stroke="#E65100"
                      StrokeThickness="2.5"
                      Fill="White"
                      StrokeLineCap="Round"
                      StrokeLineJoin="Round"
                      Data="M 15,3 
                            C 35,-1 50,7 70,3 
                            C 90,-1 110,7 130,3 
                            C 150,-1 170,7 190,3 
                            C 210,-1 230,7 250,3 
                            C 270,-1 285,3 295,12 
                            C 301,22 292,34 297,44 
                            C 292,52 275,53 250,51 
                            C 230,55 210,47 190,51 
                            C 170,55 150,47 130,51 
                            C 110,55 90,47 70,51 
                            C 50,55 35,47 15,51 
                            C 5,51 -1,44 3,34 
                            C -1,24 5,14 15,3 Z" />

                <!-- Entrada numérica montada sobre la forma -->
                <Entry x:Name="TxtNum1"
                       Placeholder="Primer número"
                       PlaceholderColor="#94A3B8"
                       TextColor="#0F172A"
                       Keyboard="Numeric"
                       Margin="24,0"
                       VerticalOptions="Center" />
            </Grid>

            <!-- 〰️ SEGUNDO NÚMERO: Marco con ondas estilo azul alternado -->
            <Grid HeightRequest="56" 
                  HorizontalOptions="Fill">
                
                <!-- Segundo patrón de ondas -->
                <Path Aspect="Fill"
                      Stroke="#1E3A8A"
                      StrokeThickness="2.5"
                      Fill="White"
                      StrokeLineCap="Round"
                      StrokeLineJoin="Round"
                      Data="M 18,5 
                            C 32,8 48,1 65,6 
                            C 85,1 105,8 125,4 
                            C 145,8 165,1 185,6 
                            C 205,1 225,8 245,4 
                            C 265,8 280,2 292,10 
                            C 300,18 294,28 300,38 
                            C 294,48 282,53 265,50 
                            C 245,54 225,48 205,53 
                            C 185,48 165,54 145,50 
                            C 125,54 105,48 85,53 
                            C 65,48 45,54 28,49 
                            C 12,54 2,46 4,36 
                            C -1,26 6,16 18,5 Z" />

                <!-- Entrada numérica montada sobre la forma -->
                <Entry x:Name="TxtNum2"
                       Placeholder="Segundo número"
                       PlaceholderColor="#94A3B8"
                       TextColor="#0F172A"
                       Keyboard="Numeric"
                       Margin="24,0"
                       VerticalOptions="Center" />
            </Grid>

            <!-- 🎯 SELECCIÓN DE OPERACIÓN -->
            <Label Text="Seleccione operación:"
                   FontSize="16"
                   FontAttributes="Bold"
                   TextColor="#1E293B"
                   Margin="0,8,0,0" />

            <!-- 🔘 BOTONES CIRCULARES EN PALETA PASTEL -->
            <HorizontalStackLayout Spacing="16"
                                   HorizontalOptions="Center">

                <!-- ➕ SUMA: Morado claro -->
                <Button Text="+"
                        Clicked="OnOperacionClicked"
                        CommandParameter="+"
                        WidthRequest="56"
                        HeightRequest="56"
                        CornerRadius="28"
                        BackgroundColor="#D1C4E9"
                        TextColor="#311B92"
                        FontSize="24"
                        FontAttributes="Bold" />

                <!-- ➖ RESTA: Azul claro -->
                <Button Text="-"
                        Clicked="OnOperacionClicked"
                        CommandParameter="-"
                        WidthRequest="56"
                        HeightRequest="56"
                        CornerRadius="28"
                        BackgroundColor="#BBDEFB"
                        TextColor="#0D47A1"
                        FontSize="24"
                        FontAttributes="Bold" />

                <!-- ✖️ MULTIPLICACIÓN: Mamey / amarillo claro -->
                <Button Text="*"
                        Clicked="OnOperacionClicked"
                        CommandParameter="*"
                        WidthRequest="56"
                        HeightRequest="56"
                        CornerRadius="28"
                        BackgroundColor="#FFE082"
                        TextColor="#E65100"
                        FontSize="24"
                        FontAttributes="Bold" />

                <!-- ➗ DIVISIÓN: Rosado claro -->
                <Button Text="/"
                        Clicked="OnOperacionClicked"
                        CommandParameter="/"
                        WidthRequest="56"
                        HeightRequest="56"
                        CornerRadius="28"
                        BackgroundColor="#F8BBD0"
                        TextColor="#880E4F"
                        FontSize="22"
                        FontAttributes="Bold" />
            </HorizontalStackLayout>

            <!-- 📏 LÍNEA DIVISORIA VISUAL -->
            <BoxView HeightRequest="2"
                     Color="#CBD5E1"
                     Margin="10,12"
                     HorizontalOptions="Fill" />

            <!-- 📊 TEXTO DEL RESULTADO -->
            <Label x:Name="LblResultado"
                   Text="Resultado: 0"
                   FontSize="22"
                   FontAttributes="Bold"
                   TextColor="#0F172A"
                   HorizontalTextAlignment="Center" />

        </VerticalStackLayout>
    </ScrollView>
</ContentPage>
```

---

## ⚙️ Lógica de Operaciones: `MainPage.xaml.cs`

Copia y pega este código dentro de tu archivo de backend `MainPage.xaml.cs`:

```csharp
namespace CalculadoraAsh;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Manejador de evento centralizado para todos los botones de operaciones.
    /// Lee el signo desde CommandParameter y ejecuta el cálculo correspondiente.
    /// </summary>
    private void OnOperacionClicked(object sender, EventArgs e)
    {
        // 1. Identificar el botón presionado
        if (sender is not Button btn) return;
        string operacion = btn.CommandParameter?.ToString() ?? string.Empty;

        // 2. Validar que los campos de texto no estén vacíos y contengan números válidos
        if (!double.TryParse(TxtNum1.Text, out double n1) || 
            !double.TryParse(TxtNum2.Text, out double n2))
        {
            LblResultado.Text = "⚠️ Ingrese números válidos";
            return;
        }

        double resultado = 0;

        // 3. Ejecutar la operación aritmética seleccionada
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
                // Prevención de división por cero
                if (n2 == 0)
                {
                    LblResultado.Text = "❌ Error: División por 0";
                    return;
                }
                resultado = n1 / n2;
                break;
        }

        // 4. Mostrar el resultado formateado
        LblResultado.Text = $"Resultado: {resultado}";
    }
}
```

---

## 💡 ¿Cómo funcionan los bordes ondulados?

1. **Uso de `Grid` como contenedor**: Al colocar un `Path` y un `Entry` dentro de la misma celda de una `Grid`, el `Path` actúa como el fondo visual decorativo mientras que el `Entry` retiene su interacción nativa de teclado y foco.
2. **Propiedad `Aspect="Fill"`**: Permite que las coordenadas vectoriales de las curvas Bézier (`C`) se ajusten dinámicamente a lo ancho de cualquier dispositivo (Android, iOS o Windows) sin deformar el grosor del contorno.
3. **Márgenes de seguridad (`Margin="24,0"`)**: El texto introducido dentro del `Entry` no choca con las ondulaciones de los extremos izquierdo y derecho.

---

## 🚀 Pasos para Ejecutar

1. Crea o abre tu proyecto .NET MAUI:
   ```bash
   dotnet new maui -n CalculadoraAsh
   ```
2. Reemplaza el contenido de `MainPage.xaml` y `MainPage.xaml.cs` con los bloques mostrados arriba.
3. Asegúrate de que el `namespace` coincida con el nombre de tu proyecto (`CalculadoraAsh` o `MauiApp110`).
4. Selecciona tu emulador o dispositivo físico y presiona **F5** o **Run**.

---

## 👨‍💻 Autor & Créditos

* **Desarrollador / Arquitecto:** [Ing. Juancito Peña Vizcaíno](https://github.com/JUANCITOPENA)
* **Canal Educativo:** [@JuancitoDevV en YouTube](https://www.youtube.com/@JuancitoDevV)
* **LinkedIn:** [Juancito Peña](https://www.linkedin.com/in/juancitope%C3%B1a/)
* **Especialidad:** Arquitectura de Software, Cloud, Datos, Inteligencia Artificial & .NET MAUI

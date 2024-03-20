using System;
using System.Globalization;
using ToDoList.Models;

namespace ToDoList.Converters
{
    class TareaCompletada : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (bool)value ? TextDecorations.Strikethrough : TextDecorations.None;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return TextDecorations.Strikethrough == (TextDecorations)value ? eEstado.Completado : eEstado.Activo;
        }
    }

    class IsTareaCompletada : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return eEstado.Completado == (eEstado)value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (bool)value ? eEstado.Completado : eEstado.Activo;
        }
    }
}

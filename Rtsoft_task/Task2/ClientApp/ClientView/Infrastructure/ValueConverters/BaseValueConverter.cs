﻿using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Globalization;


namespace ClientView.Infrastructure.ValueConverters
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
       where T : class, new()
    {

        #region Private Members

        /// <summary>
        /// A single static instance of this value converter
        /// </summary>
        private static T? mConverter = null;

        #endregion

        #region Markup Extention Methods

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //if (mConverter == null)
            //    mConverter = new T(); // ниже записано тоже самое
            return mConverter ?? (mConverter = new T());
        }
        #endregion

        #region Value converter Methods

        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public abstract object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture);


        /// <summary>
        /// The method to convert a value back to it's source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture);



        #endregion
    }
}

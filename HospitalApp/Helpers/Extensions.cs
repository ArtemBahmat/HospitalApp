using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel;
using System.Linq.Expressions;

namespace HospitalApp.Helpers
{
    public static class Extensions
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression)
                where TModel : class
        {
            TProperty value = htmlHelper.ViewData.Model == null
                ? default(TProperty)
                : expression.Compile()(htmlHelper.ViewData.Model);
            string selected = value == null ? String.Empty : value.ToString();
            return htmlHelper.DropDownListFor(expression, CreateSelectList(expression.ReturnType, selected));
        }

        private static IEnumerable<SelectListItem> CreateSelectList(Type enumType, string selectedItem)
        {
            return (from object item in Enum.GetValues(enumType)
                    let fi = enumType.GetField(item.ToString())
                    let attribute = fi.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault()
                    let title = attribute == null ? item.ToString() : ((DescriptionAttribute)attribute).Description
                    select new SelectListItem
                    {
                        Value = item.ToString(),
                        Text = title,
                        Selected = selectedItem == item.ToString()
                    }).ToList();
        }
    }
}
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.HtmlHelpers
{
    public static class ProgressBarHelper
    {
        //Генерация прогресс бара в зависимости от занятости мест на мероприятии
        public static MvcHtmlString ProgressBar(this HtmlHelper html,
                                              int ReservedPeople, int CountPeople)
        {
            StringBuilder result = new StringBuilder();

            double procentage = Math.Ceiling((100 * (double)ReservedPeople) / (double)CountPeople);

            if (procentage < 20) {
                procentage = 20;
            }

            string labelProgressBar = ReservedPeople.ToString() + " из " + CountPeople.ToString();

            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass("progress-bar");
            tag.MergeAttribute("role", "progressbar");
            tag.MergeAttribute("aria-valuenow", procentage.ToString());
            tag.MergeAttribute("aria-valuemin", "0");
            tag.MergeAttribute("style", "width:" + procentage.ToString() + "%");
            tag.InnerHtml = labelProgressBar;
            if (procentage >= 30 && procentage <= 50)
            {
                tag.AddCssClass("progress-bar-success");
            }
            else if (procentage > 50 && procentage <= 60)
            {
                tag.AddCssClass("progress-bar-info");
            }
            else if (procentage > 60 && procentage <= 70)
            {
                tag.AddCssClass("progress - bar - warning");
            }
            else if (procentage > 70){
                tag.AddCssClass("progress-bar-danger");
            }

            
            result.Append(tag.ToString());

            return MvcHtmlString.Create(result.ToString());
        }
    }
}
using DocumentFormat.OpenXml.Presentation;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Project_Implements.Enum
{
    public enum MediaTypeEnum
    {
        [Display(Name = "Text")]
        Text = 0,
        [Display(Name = "Video")]
        Video= 1,
        [Display(Name = "Audio")]
        Audio = 3,
        [Display(Name = "Image")]
        Image= 4
    }
}
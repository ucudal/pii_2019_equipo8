using System;

namespace Ignis.Models
{
    public interface IBaseFeedback
    {
        string Comment { get; set; }
        int Rating { get; set; }
    }
}
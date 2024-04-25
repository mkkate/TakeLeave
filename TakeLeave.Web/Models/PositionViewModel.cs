﻿using System.ComponentModel;
using TakeLeave.Business.Constants;

namespace TakeLeave.Web.Models
{
    public class PositionViewModel
    {
        public string Title { get; set; }
        [DisplayName(DisplayNameConstants.SeniorityLevel)]
        public string SeniorityLevel { get; set; }
    }
}

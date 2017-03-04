
using System;
using IssueTakerApp.Models;
using IssueTakerApp.Models.Enums;

namespace IssueTakerApp.BindingModels
{
    public class EditIssueBM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
       
    }
}




using System.IO;
using System.Text;
using IssueTakerApp.Utilities.Constants;
using IssueTakerApp.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace IssueTakerApp.Views.User
{
    public class Register : IRenderable<ErrorVM>
    {
        public string Render()
        {
            var sb = new StringBuilder();

            var registerTemplete = File.ReadAllText(Paths.Register);

            sb.Append(File.ReadAllText(Paths.Menu));
            if (Model != null)
            {
                var errorTemplate = File.ReadAllText(Paths.Error);
                var errorCode = string.Format(errorTemplate, Model.ErrorMessage);
                sb.Append(string.Format(registerTemplete, errorCode));
            }
            else
            {
                sb.Append(File.ReadAllText(Paths.Register));
            }

            sb.Append(File.ReadAllText(Paths.Footer));


            return sb.ToString();
        }

        public ErrorVM Model { get; set; }
    }
}

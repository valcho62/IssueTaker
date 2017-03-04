

using System.IO;
using System.Text;
using IssueTakerApp.Utilities.Constants;
using SimpleMVC.Interfaces;

namespace IssueTakerApp.Views.User
{
    public class Login :IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();

            sb.Append(File.ReadAllText(Paths.Menu));
            sb.Append(File.ReadAllText(Paths.Login));
            sb.Append(File.ReadAllText(Paths.Footer));


            return sb.ToString();
        }
    }
}



using System.IO;
using System.Text;
using IssueTakerApp.Utilities.Constants;
using SimpleMVC.Interfaces;

namespace IssueTakerApp.Views.Home
{
    public class Indexlogged : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();

            sb.Append(File.ReadAllText(Paths.Menulogged));
            sb.Append(File.ReadAllText(Paths.Home));
            sb.Append(File.ReadAllText(Paths.Footer));


            return sb.ToString();
        }
    }
}

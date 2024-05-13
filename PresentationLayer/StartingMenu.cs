using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class StartingMenu
    {
        private string prompt = @"
██╗   ██╗██╗   ██╗       ██████╗ ██╗       ██████╗ ██╗  ██╗██╗                           
╚██╗ ██╔╝██║   ██║      ██╔════╝ ██║      ██╔═══██╗██║  ██║██║                           
 ╚████╔╝ ██║   ██║█████╗██║  ███╗██║█████╗██║   ██║███████║██║                           
  ╚██╔╝  ██║   ██║╚════╝██║   ██║██║╚════╝██║   ██║██╔══██║╚═╝                           
   ██║   ╚██████╔╝      ╚██████╔╝██║      ╚██████╔╝██║  ██║██╗                           
   ╚═╝    ╚═════╝        ╚═════╝ ╚═╝       ╚═════╝ ╚═╝  ╚═╝╚═╝                           
                                                                                         
███╗   ███╗ █████╗ ███████╗████████╗███████╗██████╗     ██████╗ ██╗   ██╗███████╗██╗     
████╗ ████║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗    ██╔══██╗██║   ██║██╔════╝██║     
██╔████╔██║███████║███████╗   ██║   █████╗  ██████╔╝    ██║  ██║██║   ██║█████╗  ██║     
██║╚██╔╝██║██╔══██║╚════██║   ██║   ██╔══╝  ██╔══██╗    ██║  ██║██║   ██║██╔══╝  ██║     
██║ ╚═╝ ██║██║  ██║███████║   ██║   ███████╗██║  ██║    ██████╔╝╚██████╔╝███████╗███████╗
╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝ ╚══════╝╚══════╝
            
";
        private string[] options = {
            "Cards Collection",
            "Deck Editor",
            "Info",
            "Exit"
        };

        public Menu StartMenu { get; set; }
        public int SelectedIndex { get; set; }
        public StartingMenu()
        {
            StartMenu = new Menu(prompt, options);
            SelectedIndex = StartMenu.Run();
        }
    }
}

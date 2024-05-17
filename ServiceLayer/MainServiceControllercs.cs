using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using BusinessLayer;

namespace ServiceLayer
{
    public class MainServiceControllercs
    {
        private string driverPath = @"E:\Projects\Project_Kurtev\chromedriver-win64\chromedriver.exe";
        private IWebDriver driver;
        public MainServiceControllercs()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Card card = new Card("Blue-Eyes White Dragon", "Powerfull dragon", "Monster");
            DisplayCardMenu cardMenu = new DisplayCardMenu(card);
            IWebDriver driver = new ChromeDriver(driverPath, options);
            DisplayCardOptionsController c = new DisplayCardOptionsController(cardMenu, driver);
            c.CardOptions();
            cardMenu.cardMenu.Run();
        }
        
    }
}

using PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ServiceLayer
{
    public class DisplayCardOptionsController
    {
        private DisplayCardMenu cardMenu;
        private IWebDriver driver;
        public DisplayCardOptionsController(DisplayCardMenu cardMenu, IWebDriver driver)
        {
            this.cardMenu = cardMenu;
            this.driver = driver;
        }
        public void CardOptions()
        {
            int selectedIndex = cardMenu.SelectedIndex;
            if(selectedIndex == cardMenu.Options.Length - 2)
            {
                driver.Navigate().GoToUrl("https://db.ygorganization.com/");
                driver.FindElement(By.Id("index-search")).SendKeys(cardMenu.Card.Name);
                driver.FindElement(By.Id("index-search")).SendKeys(Keys.Enter);
                Thread.Sleep(10000);
                driver.FindElement(By.ClassName("card-name")).Click();
                Thread.Sleep(10000);
                driver.Close();
            }
            else if(selectedIndex == cardMenu.Options.Length -1)
            {
                //Go to previous menu
            }
        }
    }
}

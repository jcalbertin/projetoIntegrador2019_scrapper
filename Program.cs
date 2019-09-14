using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace exemplo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //o servidor do site vai pensar que eu sou o chrome
            //é importante para pensar que nao é um robo, aconselhavel mudar sempre essa informacao
            var user_agent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.50 Safari/537.36";
            ChromeOptions options = new ChromeOptions();
            
            //descomentar para nao ver mais o que o browser esta fazendo
            //options.AddArgument("--headless");

            //options.AddArgument("--disable-gpu"); //se o computador tiver placa grafica, melhor
            options.AddArgument($"user_agent={user_agent}"); //passa o browser que esta acessando o site
            options.AddArgument("--ignore-certificate-errors"); //ignora erros
            //configura o driver e pega a partir do diretorio do projeto
            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(240); //define timeout de execucao

            //maximiza a janela do browser
            driver.Manage().Window.Maximize();

            //abre o site a ser scrapeado
            driver.Navigate().GoToUrl("http://books.toscrape.com/");


            //varre o site a procura das categorias
            var links = driver.FindElements(By.XPath("//*[@id='default']/div/div/div/aside/div[2]/ul/li/ul/li/a"));
            foreach (var item in links)
            {
                if (item.Text.Length > 0)
                {
                    var url = item.GetAttribute("href");
                    //exemplo: http://books.toscrape.com/catalogue/category/books/romance_8/index.html
                    var inicio = url.LastIndexOf('_') + 1; //pega a posicao de _ + 1 posicao
                    var fim = url.LastIndexOf('/') - inicio; //pega a posicao da ultima barra
                    var idCategoria = Convert.ToInt32(url.Substring(inicio, fim)); //pega o 8 a partir do inicio e fim
                    var nomeCategoria = item.Text; //pega o texto do elemento html: nome da categoria no site (Romance)
                    Console.WriteLine("{0} - {1} - {2}",
                      url, idCategoria, nomeCategoria
                    );
                }
            }

            //a partir da pagina de uma categorias pega informaçoes de livros
            driver.Navigate().GoToUrl("http://books.toscrape.com/catalogue/category/books/romance_8/index.html");
            //varre o site e pega as informacoes dos livros a partir da url acima
            var livros = driver.FindElements(By.XPath("//*[@id='default']/div/div/div/div/section/div[2]/ol/li/article"));
            int i = 1;
            foreach (var item in livros)
            {   
                Console.WriteLine("=======");
                var linkLivro = item.FindElement( By.XPath("//*[@id='default']/div/div/div/div/section/div[2]/ol/li["+i+"]/article/div[1]/a"));
                Console.WriteLine("Link livro: {0}", linkLivro.GetAttribute("href"));
                var estrelas = item.FindElement(By.XPath("//*[@id='default']/div/div/div/div/section/div[2]/ol/li["+i+"]/article/p"));
                var qtdeEstrelas = estrelas.GetAttribute("class");
                //Console.WriteLine(qtdeEstrelas);
                Console.Write("Classificacao: ");
                if (qtdeEstrelas.Contains("One"))
                    Console.Write("1 estrela");
                else if (qtdeEstrelas.Contains("Two"))
                    Console.Write("2 estrela");
                else if (qtdeEstrelas.Contains("Three"))
                    Console.Write("3 estrela");
                else if (qtdeEstrelas.Contains("Four"))
                    Console.Write("4 estrela");
                else if (qtdeEstrelas.Contains("Five"))
                    Console.Write("5 estrela");
                
                var preco = item.FindElement(By.XPath("//*[@id='default']/div/div/div/div/section/div[2]/ol/li["+i+"]/article/div[2]/p[1]"));
                var estoque = item.FindElement(By.XPath("//*[@id='default']/div/div/div/div/section/div[2]/ol/li["+i+"]/article/div[2]/p[2]"));
                Console.WriteLine("\nPreço: {0}", preco.Text);
                Console.WriteLine("Estoque: {0}", estoque.Text);
                var elemTitulo = item.FindElement(By.XPath("//*[@id='default']/div/div/div/div/section/div[2]/ol/li["+i+"]/article/h3/a"));
                var titulo = elemTitulo.GetAttribute("title");
                Console.WriteLine("Titulo: {0}", titulo);
                i++;

                //poderia ser adicionado a pagina do livro e fazer escrape de paginaçao também
            }
        }
    }
}

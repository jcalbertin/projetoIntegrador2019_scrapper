# Scrappr em C# baseado em selenium

Projeto de auxílio ao projeto Integrador, scrapper baseado em Selenium.
Arquivo de projeto.

Scrapper do site:
> http://books.toscrape.com/index.html

Esse site não necessita ser feito via Selenium, por quê?

## Pontos a considerar quando fizer um scrapper (Pesquisa suscinta sobre o tema):
> - Estudo inicial do site ao qual deseja obter os dados
> - Tecnologia a ser adotada
> - Selenium!? quando usar? 
> - Leis 
> - Como não ser bloquado
> - Como passar de captchas e re-capthas

## Sofwares necessários:
- Google Chrome
- Drive do Google Chrome para o Selenium (para Windows/Linux...)
- Packages do Selenium para o C#
- Visual Studio / Code
- .Net Core 2.2

## Instalações especificas:
- Driver do Chrome:
    - a. Fazer download em http://chromedriver.chromium.org/downloads (Versão 77.x)
    -    (Atente-se de ter a partir dessa essa versao do browser em sua máquina)
    - b. Descompactar no diretorio do projeto

## Executando a partir desse repositório:
> - dotnet restore
> - dotnet run

## Fazer do ZERO:

1. No diretorio do projeto digitar:
> - dotnet new console
> - dotnet add package Selenium.WebDriver 
> - dotnet add package Selenium.Support 
> - dotnet restore
> - dotnet build
> - dotnet run

2. Seguir o que está no arquivo Program.cs, incluso nesse repositório
> a. Que tal passar para OO?

3. Como pegar o XPATH através do Chrome (Acompanhar aula EAD para isso)
> 3.1 - Habilitar Ferramentas do Desenvolvedor ( Ctrl+Shift+I )
> 3.2 - Habilitar Inspecionar Elemento (Ctrl+Shift+C)
> 3.3 - Clicar no elemento a ser inspecionado e no código HTML, com o bot±ao direito do mouse selecionar:
>   3.3.1 - Copy e Copy XPATH ou Copy Full XPATH 

4. Possíveis integras de projeto:
> 4.1 - Passar para OO
> 4.2 - Fazer scrapper do site: https://www.fgp.edu.br/graduacao
> 4.3 - Fazer scrapper do site: http://quotes.toscrape.com/ (Dá para logar no site)




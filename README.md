# HtmlToPdf.Core

Biblioteca para geração de PDF a partir de HTML utilizando o **wkhtmltopdf**.

---

## 🔧 Dependência

* **wkhtmltopdf (wkhtmltox)**

  * Site oficial: [https://wkhtmltopdf.org/downloads.html](https://wkhtmltopdf.org/downloads.html)
  * Versão recomendada (Windows):

    * `0.12.6-1` (x64 ou x86)

* **Windows: Serviços**
  * Spooler de impressão do Windows deve estar ativo para o funcionamento correto do wkhtmltopdf.
  * RPC (Chamada de Procedimento Remoto) do Windows deve estar ativo para o funcionamento correto do wkhtmltopdf.

---

## 🚀 Exemplo de uso simples

```csharp
        public IActionResult PageToPdf()
        {
            var separator = System.IO.Path.DirectorySeparatorChar;
            var platform = GetPlatform();
            var customPath = "";
            #if DEBUG
            customPath = $"debug{separator}net9.0{separator}";
            #endif

            var path = $"{_webHostEnvironment.ContentRootPath}{separator}bin{separator}{customPath}" +
                $"runtimes{separator}{platform}{separator}native{separator}wkhtmltopdf.exe";
            var outputPath = $"{_webHostEnvironment.ContentRootPath}{separator}wwwroot{separator}files{separator}page.pdf";
            var outputPathDir = System.IO.Path.GetDirectoryName(outputPath)!;
            if (!System.IO.Directory.Exists(outputPathDir))
            {
                System.IO.Directory.CreateDirectory(outputPathDir);
            }

            using var pdf = new HtmlToPdfParser(path);
            pdf.Convert("https://www.google.com.br", outputPath, new ConvertOptions
            {
                PageSize = PageSize.A4,
                Orientation = PageOrientation.Portrait,
                Margins = new PageMargins()
            });
            return Redirect("/wwwroot/files/page.pdf");
        }
```
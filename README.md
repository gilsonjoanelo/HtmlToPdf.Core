# HtmlToPdf.Core

wkhtmltox: https://wkhtmltopdf.org/downloads.html
 Windows (x64|x86): 0.12.6-1

Exemplo de uso simples

class Program
{
    static void Main()
    {
        var parser = new WkHtmlToPdfParser(@"C:\caminho\wkhtmltopdf.exe");

        var options = new WkHtmlToPdfOptions
        {
            PageSize = "A4",
            Orientation = "Landscape",
            MarginTop = "20mm",
            HeaderCenter = "Relatório - Página [page]",
            FooterRight = "Data: [date]",
            PrintMediaType = true,
            DisableSmartShrinking = true
        };

        parser.Convert("https://www.exemplo.com", @"C:\saida\relatorio.pdf", options);
    }
}

Exemplo de uso com TOC e SSL

class Program
{
    static void Main()
    {
        var parser = new WkHtmlToPdfParser(@"C:\caminho\wkhtmltopdf.exe");

        var options = new WkHtmlToPdfOptions
        {
            PageSize = "A4",
            Orientation = "Portrait",
            IncludeToc = true,
            TocHeaderText = "Sumário",
            TocLevelIndentation = "2em",
            TocTextSizeShrink = "0.8",
            IgnoreLoadErrors = true,
            DisableSslChecks = true,
            EnableLocalFileAccess = true,
            HeaderCenter = "Relatório - Página [page]",
            FooterRight = "Data: [date]",
            JavascriptDelay = 2000
        };

        parser.Convert("https://www.exemplo.com", @"C:\saida\relatorio_com_toc.pdf", options);
    }
}

Exemplos práticos

- Gerar PDF simples com margens e cabeçalho:
wkhtmltopdf --page-size A4 --margin-top 20mm --header-center "Relatório" input.html output.pdf

Gerar PDF com TOC e SSL ignorado:
wkhtmltopdf toc --toc-header-text "Sumário" --disable-ssl-checks https://www.exemplo.com output.pdf

- Gerar PDF com delay para JavaScript:
wkhtmltopdf --javascript-delay 3000 https://www.exemplo.com output.pdf


# 📑 Parâmetros do wkhtmltopdf

| Categoria              | Parâmetro                  | Descrição                                | Exemplo                                      |
|------------------------|----------------------------|------------------------------------------|----------------------------------------------|
| **Básicos**            | `--page-size`              | Define o tamanho da página (A4, Letter)  | `--page-size A4`                             |
|                        | `--orientation`            | Orientação da página                     | `--orientation Landscape`                    |
|                        | `--dpi`                    | Define a resolução em DPI                | `--dpi 300`                                  |
|                        | `--zoom`                   | Ajusta o zoom da renderização            | `--zoom 1.5`                                 |
|                        | `--grayscale`              | Converte para escala de cinza            | `--grayscale`                                |
|                        | `--lowquality`             | Usa compressão baixa                     | `--lowquality`                               |
| **Margens**            | `--margin-top`             | Margem superior                          | `--margin-top 20mm`                          |
|                        | `--margin-bottom`          | Margem inferior                          | `--margin-bottom 15mm`                       |
|                        | `--margin-left`            | Margem esquerda                          | `--margin-left 10mm`                         |
|                        | `--margin-right`           | Margem direita                           | `--margin-right 10mm`                        |
| **Cabeçalho/Rodapé**   | `--header-html`            | HTML para cabeçalho                      | `--header-html header.html`                  |
|                        | `--footer-html`            | HTML para rodapé                         | `--footer-html footer.html`                  |
|                        | `--header-left`            | Texto à esquerda no cabeçalho            | `--header-left "Relatório"`                  |
|                        | `--header-center`          | Texto central no cabeçalho               | `--header-center "Página [page]"`            |
|                        | `--header-right`           | Texto à direita no cabeçalho             | `--header-right "[date]"`                    |
|                        | `--footer-left`            | Texto à esquerda no rodapé               | `--footer-left "Confidencial"`               |
|                        | `--footer-center`          | Texto central no rodapé                  | `--footer-center "Relatório"`                |
|                        | `--footer-right`           | Texto à direita no rodapé                | `--footer-right "Página [page]"`             |
| **TOC (Sumário)**      | `toc`                      | Gera sumário automático                  | `toc`                                        |
|                        | `--toc-header-text`        | Texto do cabeçalho do sumário            | `--toc-header-text "Sumário"`                |
|                        | `--toc-level-indentation`  | Indentação dos níveis                    | `--toc-level-indentation 2em`                |
|                        | `--toc-text-size-shrink`   | Reduz tamanho da fonte                   | `--toc-text-size-shrink 0.8`                 |
| **SSL / Segurança**    | `--ignore-load-errors`     | Ignora erros de carregamento             | `--ignore-load-errors`                       |
|                        | `--enable-local-file-access` | Permite acesso a arquivos locais        | `--enable-local-file-access`                 |
|                        | `--disable-ssl-checks`     | Ignora verificação SSL                   | `--disable-ssl-checks`                       |
|                        | `--custom-header`          | Define cabeçalho HTTP                    | `--custom-header "Auth" "Token123"`          |
|                        | `--custom-header-propagation` | Propaga cabeçalhos                     | `--custom-header-propagation`                |
| **JavaScript**         | `--disable-javascript`     | Desativa JS                              | `--disable-javascript`                       |
|                        | `--javascript-delay`       | Tempo de espera para JS (ms)             | `--javascript-delay 2000`                    |
|                        | `--window-status`          | Espera até status da janela              | `--window-status ready`                      |
|                        | `--print-media-type`       | Usa estilos de impressão                 | `--print-media-type`                         |
|                        | `--disable-smart-shrinking`| Desativa ajuste automático               | `--disable-smart-shrinking`                  |
| **Imagens**            | `--image-quality`          | Qualidade das imagens (0–100)            | `--image-quality 90`                         |
| **Outros**             | `--no-stop-slow-scripts`   | Não interrompe scripts lentos            | `--no-stop-slow-scripts`                     |
|                        | `--enable-forms`           | Renderiza formulários                    | `--enable-forms`                             |

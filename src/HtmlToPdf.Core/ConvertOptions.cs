using System.Text;

using HtmlToPdf.Core.Enums;

namespace HtmlToPdf.Core
{
    public sealed class ConvertOptions
    {
        // Configurações básicas
        /// <summary>
        /// Define o tamanho da página (A4, Letter)
        /// </summary>
        public PageSize PageSize { get; set; } = PageSize.A4;

        /// <summary>
        /// Orientação da página
        /// </summary>
        public PageOrientation Orientation { get; set; } = PageOrientation.Portrait;

        /// <summary>
        /// Define a resolução em DPI
        /// </summary>
        public int? Dpi { get; set; }

        /// <summary>
        /// Ajusta o zoom da renderização
        /// </summary>
        public int? Zoom { get; set; }

        /// <summary>
        /// Converte para escala de cinza
        /// </summary>
        public bool Grayscale { get; set; }

        /// <summary>
        /// Usa compressão baixa
        /// </summary>
        public bool LowQuality { get; set; }

        // Margens
        /// <summary>
        /// Margens da página em milímetros.
        /// </summary>
        public PageMargins Margins { get; set; } = new PageMargins();

        /// <summary>
        /// Cabeçalho do PDF
        /// </summary>
        public PdfHeader PdfHeader { get; set; } = new PdfHeader();

        public PdfFooter PdfFooter { get; set; } = new PdfFooter();

        /// <summary>
        /// Sumário automático
        /// </summary>
        public PdfToc PdfToc { get; set; } = new PdfToc();

        // SSL / HTTPS

        /// <summary>
        /// Ignora erros de carregamento
        /// </summary>
        public bool IgnoreLoadErrors { get; set; }

        /// <summary>
        /// Permite acesso a arquivos locais
        /// </summary>
        public bool EnableLocalFileAccess { get; set; }

        /// <summary>
        /// Ignora verificação SSL
        /// </summary>
        public bool DisableSslChecks { get; set; }

        /// <summary>
        /// Define cabeçalho HTTP
        /// </summary>
        public string? CustomHeader { get; set; }

        /// <summary>
        /// Propaga cabeçalhos
        /// </summary>
        public string? CustomHeaderPropagation { get; set; }

        // Outras opções

        /// <summary>
        /// Usa estilos de impressão
        /// </summary>
        public bool PrintMediaType { get; set; }

        /// <summary>
        /// Ativa JS: Default: true
        /// </summary>
        public bool EnableJavascript { get; set; } = true;

        /// <summary>
        /// Desativa ajuste automático
        /// </summary>
        public bool DisableSmartShrinking { get; set; }

        /// <summary>
        /// Qualidade das imagens (0–100)
        /// </summary>
        public int? ImageQuality { get; set; }

        /// <summary>
        /// Tempo de espera para JS (ms)
        /// </summary>
        public int? JavascriptDelay { get; set; }

        /// <summary>
        /// Interrompe scripts lentos. Default: false
        /// </summary>
        public bool StopSlowScripts { get; set; } = true;

        /// <summary>
        /// Renderiza formulários. Default: true
        /// </summary>
        public bool EnableForms { get; set; } = true;

        /// <summary>
        /// Espera até status da janela
        /// </summary>
        public string? WindowStatus { get; set; }

        /// <summary>
        /// Parâmetro personalizados adicionais
        /// </summary>
        public string? CustomArgs { get; set; }

        internal string BuildArguments(string input, string output)
        {
            var args = new StringBuilder()
                .Append($" --page-size {PageSize.ToString()}")
                .Append($" --orientation {Orientation.ToString()}");

            // Configurações básicas
            if (Dpi.HasValue) args.Append($" --dpi {Dpi.Value}");
            if (Zoom.HasValue) args.Append($" --zoom {Zoom.Value}");
            if (Grayscale) args.Append(" --grayscale");
            if (LowQuality) args.Append(" --lowquality");

            // Margens
            args.Append($" --margin-top {Margins.Top}");
            args.Append($" --margin-bottom {Margins.Bottom}");
            args.Append($" --margin-left {Margins.Left}");
            args.Append($" --margin-right {Margins.Right}");

            // Cabeçalho e rodapé
            if (!string.IsNullOrEmpty(PdfHeader.HeaderHtml)) args.Append($" --header-html \"{PdfHeader.HeaderHtml}\"");
            if (!string.IsNullOrEmpty(PdfFooter.FooterHtml)) args.Append($" --footer-html \"{PdfFooter.FooterHtml}\"");
            if (!string.IsNullOrEmpty(PdfHeader.HeaderCenter)) args.Append($" --header-center \"{PdfHeader.HeaderCenter}\"");
            if (!string.IsNullOrEmpty(PdfFooter.FooterCenter)) args.Append($" --footer-center \"{PdfFooter.FooterCenter}\"");
            if (!string.IsNullOrEmpty(PdfHeader.HeaderLeft)) args.Append($" --header-left \"{PdfHeader.HeaderLeft}\"");
            if (!string.IsNullOrEmpty(PdfFooter.FooterLeft)) args.Append($" --footer-left \"{PdfFooter.FooterLeft}\"");
            if (!string.IsNullOrEmpty(PdfHeader.HeaderRight)) args.Append($" --header-right \"{PdfHeader.HeaderRight}\"");
            if (!string.IsNullOrEmpty(PdfFooter.FooterRight)) args.Append($" --footer-right \"{PdfFooter.FooterRight}\"");

            // TOC
            if (PdfToc.IncludeToc) args.Append(" toc");
            if (!string.IsNullOrEmpty(PdfToc.TocHeaderText)) args.Append($" --toc-header-text \"{PdfToc.TocHeaderText}\"");
            if (!string.IsNullOrEmpty(PdfToc.TocLevelIndentation)) args.Append($" --toc-level-indentation {PdfToc.TocLevelIndentation}");
            if (!string.IsNullOrEmpty(PdfToc.TocTextSizeShrink)) args.Append($" --toc-text-size-shrink {PdfToc.TocTextSizeShrink}");

            // SSL
            if (IgnoreLoadErrors) args.Append(" --ignore-load-errors");
            if (EnableLocalFileAccess) args.Append(" --enable-local-file-access");
            if (DisableSslChecks) args.Append(" --disable-ssl-checks");
            if (!string.IsNullOrEmpty(CustomHeader)) args.Append($" --custom-header {CustomHeader}");
            if (!string.IsNullOrEmpty(CustomHeaderPropagation)) args.Append($" --custom-header-propagation {CustomHeaderPropagation}");

            // Outras opções
            if (PrintMediaType) args.Append(" --print-media-type");
            if (!EnableJavascript) args.Append(" --disable-javascript");
            if (DisableSmartShrinking) args.Append(" --disable-smart-shrinking");
            if (ImageQuality.HasValue) args.Append($" --image-quality {ImageQuality.Value}");
            if (JavascriptDelay.HasValue) args.Append($" --javascript-delay {JavascriptDelay.Value}");
            if (StopSlowScripts) args.Append($" --no-stop-slow-scripts");
            if (!string.IsNullOrEmpty(WindowStatus)) args.Append($" --window-status {WindowStatus}");
            if (EnableForms) args.Append($" --enable-forms");

            if (!string.IsNullOrEmpty(CustomArgs)) args.Append($" {CustomArgs}");

            // Input e output
            args.Append($" \"{input}\" \"{output}\"");

            return args.ToString();
        }
    }
}

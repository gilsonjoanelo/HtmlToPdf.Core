namespace HtmlToPdf.Core
{
    public sealed class PdfToc
    {
        /// <summary>
        /// Gera sumário automático
        /// </summary>
        public bool IncludeToc { get; set; }

        /// <summary>
        /// Texto do cabeçalho do sumário
        /// </summary>
        public string? TocHeaderText { get; set; }

        /// <summary>
        /// Indentação dos níveis
        /// </summary>
        public string? TocLevelIndentation { get; set; }

        /// <summary>
        /// Reduz tamanho da fonte
        /// </summary>
        public string? TocTextSizeShrink { get; set; }
    }
}

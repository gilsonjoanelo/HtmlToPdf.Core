using System.Diagnostics;

namespace HtmlToPdf.Core
{
    public sealed class HtmlToPdfParser : IDisposable
    {
        private readonly string _wkhtmlPath;

        public HtmlToPdfParser(string wkhtmlPath)
        {
            if (!File.Exists(wkhtmlPath))
                throw new FileNotFoundException("wkhtmltopdf não encontrado", wkhtmlPath);

            _wkhtmlPath = wkhtmlPath;
        }

        public void Convert(string input, string output, ConvertOptions options)
        {
            var arguments = options.BuildArguments(input, output);

            var startInfo = new ProcessStartInfo
            {
                FileName = _wkhtmlPath,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string outputMsg = process.StandardOutput.ReadToEnd();
                string errorMsg = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Erro ao gerar PDF: {errorMsg}");
                }
            }
        }

        public void Dispose()
        {
        }
    }
}

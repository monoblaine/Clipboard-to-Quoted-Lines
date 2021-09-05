//ş
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClipToQuotedLines {
    internal class Program {
        [STAThread]
        private static void Main (String[] args) {
            if (!Clipboard.ContainsText(TextDataFormat.UnicodeText)) {
                return;
            }

            var quotedText = String.Join(
                ",\r\n",
                Regex
                    .Split(
                        Clipboard.GetText(TextDataFormat.UnicodeText),
                        @"\r?\n"
                    )
                    .Select(line => $"\"{line}\"")
            );

            Clipboard.SetText(quotedText, TextDataFormat.UnicodeText);
        }
    }
}

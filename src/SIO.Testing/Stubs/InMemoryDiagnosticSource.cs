using System.Diagnostics;

namespace SIO.Testing.Stubs
{
    internal sealed class InMemoryDiagnosticSource : DiagnosticSource
    {
        public override bool IsEnabled(string name)
        {
            return true;
        }

        public override void Write(string name, object value)
        {
            return;
        }
    }
}

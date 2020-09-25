using System.Diagnostics;

namespace SIO.Testing.Stubs
{
    internal sealed class InMemoryDiagnosticListener : DiagnosticListener
    {
        public InMemoryDiagnosticListener(string name) : base(name)
        {
        }
    }
}
